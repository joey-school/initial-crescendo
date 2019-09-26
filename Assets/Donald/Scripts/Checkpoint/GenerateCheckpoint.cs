using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class GenerateCheckpoint : MonoBehaviour
	{
		[SerializeField] private Transform checkpointParent;
		[SerializeField] private GameObject checkpointPrefab;
		[SerializeField] private Transform player;

		public void Generate() {
			GameObject newCheckpoint = Instantiate(checkpointPrefab, player.position, Quaternion.identity, checkpointParent);
			CheckpointSoundManager checkpointSoundManager = newCheckpoint.GetComponent<CheckpointSoundManager>();
			checkpointSoundManager.time = SoundManager.Instance.GetLevelThemeTime();
		}
	}
}
