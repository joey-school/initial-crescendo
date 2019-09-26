using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class SpawnPlayer : MonoBehaviour
	{
		public Transform SpawnPoint;

		void Start() {
			transform.position = SpawnPoint.position;
		}
	}
}
