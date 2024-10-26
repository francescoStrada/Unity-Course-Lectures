using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace c02.Risso.Francesco {
	public class SimpleThirdPersonController : MonoBehaviour {
		public float WalkSpeed = 10f;
		public float RotationSpeed = 10f;

		public bool SmoothMovement = true;

		private Floor floor;

		private Camera cam;

		void Start() {
			cam = Camera.main;
			floor = FindObjectOfType<Floor>();

			if(cam == null) throw new System.Exception($"{gameObject.name} cannot find a camera");
			if(floor == null) throw new System.Exception($"{gameObject.name} cannot find a floor");
		}

		void Update() {
			// Get direction of movement as selected from the keyboard
			Vector3 desiredDir = GetKeyboardMovementVector();

			// Quit if no movement was requested
			if(desiredDir.magnitude == 0) return;

			// Update movement direction according to camera view
			desiredDir = MakeDirectionRelativeToCamera(desiredDir);

			// Rotate character towards the desired dir
			OrientateTowardsDirection(desiredDir);

			// Translate in the direction of sight
			gameObject.transform.Translate(Time.deltaTime * WalkSpeed * Vector3.forward);
			// transform.Translate works in local coordinates, so you need to translate in dir (1,0,0) = Vector3.forward
			// transform.forward would be correct if Translate operated in global coordinates

			// Check to not exit from the plane
			float X = Mathf.Clamp(gameObject.transform.position.x, floor.GetMinX(), floor.GetMaxX());
			float Y = gameObject.transform.position.y;
			float Z = Mathf.Clamp(gameObject.transform.position.z, floor.GetMinZ(), floor.GetMaxZ());
			gameObject.transform.position = new Vector3(X, Y, Z);
		}

		private Vector3 GetKeyboardMovementVector() {
			Vector3 movement = new Vector3(0, 0, 0);

			if(SmoothMovement) {
				movement.x = Input.GetAxis("Horizontal");
				movement.z = Input.GetAxis("Vertical");

			} else {
				if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) movement.x += 1;
				if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) movement.x -= 1;
				if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) movement.z += 1;
				if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) movement.z -= 1;
			}

			movement.Normalize();
			return movement;
		}

		private Vector3 MakeDirectionRelativeToCamera(Vector3 dir) {
			if(cam == null) return dir;

			dir = cam.transform.TransformDirection(dir);
			dir.y = 0;
			dir.Normalize();
			return dir;
		}

		private void OrientateTowardsDirection(Vector3 dir) {
			Vector3 partialDir = Vector3.RotateTowards(gameObject.transform.forward, dir, RotationSpeed * Time.deltaTime, 0);
			gameObject.transform.rotation = Quaternion.LookRotation(partialDir, gameObject.transform.up);
		}
	}
}
