using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace c02.Risso.Francesco {
	public class Floor : MonoBehaviour {
		private float minX, minZ, maxX, maxZ;

		void Start() {
			Vector3 topRigth = gameObject.transform.TransformPoint(new Vector3(5, 0, 5));
			Vector3 topLeft = gameObject.transform.TransformPoint(new Vector3(-5, 0, 5));
			Vector3 bottomLeft = gameObject.transform.TransformPoint(new Vector3(-5, 0, -5));
			Vector3 bottomRight = gameObject.transform.TransformPoint(new Vector3(5, 0, -5));

			maxX = Mathf.Max(topLeft.x, bottomRight.x, topRigth.x, bottomLeft.x);
			maxZ = Mathf.Max(topLeft.z, bottomRight.z, topRigth.z, bottomLeft.z);
			minX = Mathf.Min(topLeft.x, bottomRight.x, topRigth.x, bottomLeft.x);
			minZ = Mathf.Min(topLeft.z, bottomRight.z, topRigth.z, bottomLeft.z);
		}

		public float GetMinX() {
			return minX;
		}

		public float GetMaxX() {
			return maxX;
		}

		public float GetMinZ() {
			return minZ;
		}

		public float GetMaxZ() {
			return maxZ;
		}
	}
}
