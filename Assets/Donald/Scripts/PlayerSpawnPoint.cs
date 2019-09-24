using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class PlayerSpawnPoint : MonoBehaviour
	{
		public GameObject SpawnPoint;

		// Start is called before the first frame update
		void Start() {
			transform.position = SpawnPoint.transform.position;

			SpawnPoint.GetComponentInChildren<DevAudioCheckPoint>().Active = true;
		}

		// Update is called once per frame
		void Update() {

		}
	}
}
