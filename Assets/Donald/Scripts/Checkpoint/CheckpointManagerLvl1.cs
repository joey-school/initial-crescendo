using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
	public class CheckpointManagerLvl1 : MonoBehaviour, ICheckpointManager
	{
		//public static CheckpointManager Instance { get; private set; }

		[SerializeField] private GameObject checkpointPrefab;
		[SerializeField] private Transform checkpointParent;
		[SerializeField] private Transform player;

		public string PlayerPrefsNameCheckpLvl1;
		[SerializeField] int ForceCheckpointNumber;
		[SerializeField] int ChangePlayerPrefs;

		private List<GameObject> level1Checkpoints;

		private void Start() {
			if(ChangePlayerPrefs >= 0) {
				PlayerPrefs.SetInt(PlayerPrefsNameCheckpLvl1, ChangePlayerPrefs);
			}

			level1Checkpoints = new List<GameObject>();
			foreach(Transform checkpoint in checkpointParent.transform) {
				level1Checkpoints.Add(checkpoint.gameObject);
			};
			GameObject currentSpawnPoint = GetCurrentCheckpoint();
			currentSpawnPoint.GetComponent<CheckpointSoundManager>().isPlayerSpawnPoint = true;
			player.position = currentSpawnPoint.transform.GetChild(0).position;
			DisableOtherSpawnPoints(currentSpawnPoint);
		}

		public void GenerateCheckpoint() {
			GameObject newCheckpoint = Instantiate(checkpointPrefab, player.position, Quaternion.identity, checkpointParent);
			CheckpointSoundManager checkpointSoundManager = newCheckpoint.GetComponent<CheckpointSoundManager>();
			checkpointSoundManager.time = SoundManager.Instance.GetLevelThemeTime();
		}

		public void ChangeCurrentSpawnPoint(int checkpointNumber) {
			GetCurrentCheckpoint().GetComponent<CheckpointSoundManager>().isPlayerSpawnPoint = false;
			PlayerPrefs.SetInt(PlayerPrefsNameCheckpLvl1, checkpointNumber);
		}

		public GameObject GetCurrentCheckpoint() {
			if(ForceCheckpointNumber > -1) {
				return level1Checkpoints[ForceCheckpointNumber];
			} else {
				return level1Checkpoints[PlayerPrefs.GetInt(PlayerPrefsNameCheckpLvl1)];
			}
		}

		void DisableOtherSpawnPoints(GameObject currentSpawnPoint) {
			foreach(GameObject spawnpoint in level1Checkpoints) {
				spawnpoint.SetActive(spawnpoint == currentSpawnPoint);
			}
		}
	}
}
