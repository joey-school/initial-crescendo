using System;
using System.Collections;
using System.Collections.Generic;
using Crescendo.SymphoSprint;
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
		[SerializeField] private Transform door;
		[SerializeField] private Vector3 doorPlayerOffset;
        [SerializeField] private ProgressMeter progressMeter;
        [SerializeField] private bool isDebugging;

        public bool IsDebugging { get { return isDebugging; } }

        public string PlayerPrefsNameCheckpLvl1;
		[SerializeField] int ForceCheckpointNumber;
		[SerializeField] int ChangePlayerPrefs;

		private List<GameObject> level1Checkpoints = new List<GameObject>();

        private void Awake()
        {
            // Start is already unlocked.
            if (!PlayerPrefs.HasKey(PlayerPrefsNameCheckpLvl1))
            {
                PlayerPrefs.SetInt(PlayerPrefsNameCheckpLvl1, 0);
            }

            ShowCheckpointsInProgressBar();
        }

        private void Start() {
            //PlayerPrefs.SetInt(PlayerPrefsNameCheckpLvl1, 1);
            if (isDebugging) {
				PlayerPrefs.SetInt(PlayerPrefsNameCheckpLvl1, ChangePlayerPrefs);
			}

			foreach(Transform checkpoint in checkpointParent.transform) {
				level1Checkpoints.Add(checkpoint.gameObject);
			};

			GameObject currentSpawnPoint = GetCurrentCheckpoint();
			currentSpawnPoint.GetComponent<CheckpointSoundManager>().isPlayerSpawnPoint = true;
			player.position = currentSpawnPoint.transform.GetChild(0).position;
			door.position = player.position + doorPlayerOffset;

            if (isDebugging)
            {
                DisableOtherSpawnPoints(currentSpawnPoint);
            }

            ActivateUnlockedCheckpoints();
        }

        private void Update()
        {
            if (Input.GetKeyDown("q"))
            {
                GenerateCheckpoint();
            }
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

        private void ShowCheckpointsInProgressBar()
        {
            foreach (Transform checkpoint in checkpointParent)
            {
                Debug.Log(checkpoint.GetSiblingIndex(), this);

                // Don't show the start checkpoint.
                if (checkpoint.GetSiblingIndex() == 0 || checkpoint.GetComponent<Checkpoint>().IsUsedInDebugging)
                {
                    continue;
                }

                float percentage = checkpoint.position.x / (progressMeter.Finish.position.x - progressMeter.Start.position.x);
                progressMeter.PlaceCheckpointMarker(percentage);
            }
        }

        public void UnlockCheckpoint(int index)
        {
            // Prevents double unlock on start.
            if (PlayerPrefs.GetInt(PlayerPrefsNameCheckpLvl1) == index)
            {
                return;
            }

            Debug.Log($"Unlock checkpoint: {index}", this);

            PlayerPrefs.SetInt(PlayerPrefsNameCheckpLvl1, index);
            checkpointParent.GetChild(index).GetComponent<Checkpoint>().Unlock();
            progressMeter.ActivateCheckpoint(index - 1);
        }

        private void ActivateUnlockedCheckpoints()
        {
            for (int i = 0; i < PlayerPrefs.GetInt(PlayerPrefsNameCheckpLvl1) + 1; i++)
            {
                Checkpoint checkpoint = level1Checkpoints[i].GetComponent<Checkpoint>();

                if (checkpoint.IsUsedInDebugging)
                {
                    continue;
                }

                level1Checkpoints[i].GetComponent<Checkpoint>().Activate();

                if (i < PlayerPrefs.GetInt(PlayerPrefsNameCheckpLvl1))
                {
                    progressMeter.ActivateCheckpoint(i);
                }
            }
        }
    }
}
