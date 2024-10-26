using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace c02.Risso.Francesco {
	public class RandomPositioning : MonoBehaviour {
		private SimpleThirdPersonController player;

		private Floor floor;

		private float radius;

		void Start() {
			player = FindObjectOfType<SimpleThirdPersonController>();
			floor = FindObjectOfType<Floor>();

			if(player == null) throw new System.Exception($"{gameObject.name} cannot find a player");
			if(floor == null) throw new System.Exception($"{gameObject.name} cannot find a floor");

			radius = gameObject.transform.localScale.x;

			PlaceInARandomLocation();
		}

		void Update() {
			if(PlayerInsideSphere()) PlaceInARandomLocation();
		}

		private void PlaceInARandomLocation() {
			float X = Random.Range(floor.GetMinX() + radius, floor.GetMaxX() - radius);
			float Z = Random.Range(floor.GetMinZ() + radius, floor.GetMaxZ() - radius);

			gameObject.transform.position = new Vector3(X, 0, Z);
		}

		private bool PlayerInsideSphere() {
			float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
			return distance < radius;
		}
	}
}
