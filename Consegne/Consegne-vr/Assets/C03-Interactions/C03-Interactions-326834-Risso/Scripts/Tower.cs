using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour {
	[SerializeField]
	private float _casual_turn_speed = .5f;

	private Component _rotating_turret;

	void Start() {
		_rotating_turret = FindChild("RotatingTower");

		if(!_rotating_turret) throw new System.Exception($"Tower {name} cannot find its \"RotatingTurret\" component");
	}

	void Update() {
		CasualTurn();
	}

	private void CasualTurn() {
		Turn(_casual_turn_speed, true);
	}

	private void Turn(float speed, bool towards_right) {
		Vector3 forward = _rotating_turret.transform.forward;
		Vector3 right = _rotating_turret.transform.right;
		Vector3 up = _rotating_turret.transform.up;

		Vector3 desiredDir = towards_right ? right : -right;
		Vector3 partialDir = Vector3.RotateTowards(forward, desiredDir, speed * Time.deltaTime, 0);
		_rotating_turret.transform.rotation = Quaternion.LookRotation(partialDir, up);
	}

	private Component FindChild(string child_name) {
		foreach(Component comp in GetComponentsInChildren<Component>(true))
			if(comp.gameObject.name == child_name) return comp;
		return null;
	}
}
