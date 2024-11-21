using System;
using System.Security.Cryptography;
using c03.exercise;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour {
	[SerializeField]
	private float _casual_turn_speed = 1f;

	[SerializeField]
	private float _fight_turn_speed = 2f;

	[SerializeField]
	private float _tracking_radius = 30f;

	[SerializeField]
	private float _tracking_semi_angle = 30f;

	private Component _rotating_turret;

	private Component _barrel;

	private SimpleThirdPRigidbodyController _player;

	void Start() {
		_rotating_turret = FindChild("RotatingTower");
		_barrel = FindChild("RayOrigin");
		_player = FindObjectOfType<SimpleThirdPRigidbodyController>();

		if(!_rotating_turret) throw new System.Exception($"Tower {name} cannot find its \"RotatingTurret\" component");
		if(!_barrel) throw new System.Exception($"Tower {name} cannot find its \"RayOrigin\" component");
		if(!_player) throw new System.Exception($"Tower {name} cannot find the player");
	}

	void Update() {
		Vector3? dir = PlayerSight();
		if(dir == null)
			CasualTurn();
		else
			FightTurn(dir.Value);
	}

	private void CasualTurn() {
		Turn(_casual_turn_speed, _rotating_turret.transform.right);
	}

	private void FightTurn(Vector3 playerDir) {
		Turn(_fight_turn_speed, playerDir);
	}

	private void Turn(float speed, Vector3 towards) {
		Vector3 forward = _rotating_turret.transform.forward;
		Vector3 up = _rotating_turret.transform.up;

		Vector3 partialDir = Vector3.RotateTowards(forward, towards, speed * Time.deltaTime, 0);
		_rotating_turret.transform.rotation = Quaternion.LookRotation(partialDir, up);
	}

	private Component FindChild(string child_name) {
		foreach(Component comp in GetComponentsInChildren<Component>(true))
			if(comp.gameObject.name == child_name) return comp;
		return null;
	}

	private Vector3? PlayerSight() {
		Vector3 turret_to_player = _player.transform.position - transform.position;
		turret_to_player.y = 0;

		// First, check the distance between turret and player
		float dst_sqr = turret_to_player.sqrMagnitude;
		if(dst_sqr > Math.Pow(_tracking_radius, 2)) return null;

		// Then, check the angle
		float angle = Vector3.Angle(_rotating_turret.transform.forward, turret_to_player);
		if(Math.Abs(angle) > _tracking_semi_angle) return null;

		// Only if those are ok (player is in the visibility area) check with the ray
		Vector3 barrel_to_player = _player.transform.position - _barrel.transform.position;
		barrel_to_player.y = 0;

		Ray ray = new(_barrel.transform.position, barrel_to_player);
		if(Physics.Raycast(ray, out RaycastHit hit, _tracking_radius))
			if(hit.transform != _player.transform) return null;

		// If the turret can shoot the player, return the direction towards the player
		return barrel_to_player.normalized;
	}
}
