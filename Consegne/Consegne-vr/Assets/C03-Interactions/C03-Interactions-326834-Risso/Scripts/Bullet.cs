
using Unity.VisualScripting;
using UnityEngine;

namespace c03.exercise {


	public class Bullet : MonoBehaviour {
		[SerializeField]
		private GameObject _spawned_on_collision;
		[SerializeField]
		private float _spawn_force = 5.0f;

		void Update() {
			if(transform.position.y < 0) Destroy(gameObject);
		}

		void OnCollisionEnter(Collision collision) {
			if(!_spawned_on_collision) return;

			Vector3 cur_velocity = gameObject.GetComponent<Rigidbody>().velocity.normalized;

			for(int i = Random.Range(0, 5); i >= 0; i--) {
				Vector3 force_dir = Random.insideUnitSphere;
				if(Vector3.Dot(force_dir, cur_velocity) > 0) force_dir = -force_dir;

				GameObject child = Instantiate(_spawned_on_collision, transform.position, transform.rotation);
				child.GetComponent<Rigidbody>().AddForce(force_dir * _spawn_force, ForceMode.Impulse);
				Destroy(gameObject);
			}
		}
	}
}
