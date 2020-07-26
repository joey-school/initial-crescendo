using System;
using System.Collections;
using System.Collections.Generic;
using Crescendo.SymphoSprint;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
	public class CheckpointManager : MonoBehaviour, ICheckpointManager
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

        public string PlayerPrefsNameCheckp;
		[SerializeField] int ForceCheckpointNumber;
		[SerializeField] int ChangePlayerPrefs;

		private List<GameObject> checkPoints = new List<GameObject>();

        private void Awake()
        {
            // Start is already unlocked.
            if (!PlayerPrefs.HasKey(PlayerPrefsNameCheckp))
            {
                PlayerPrefs.SetInt(PlayerPrefsNameCheckp, 0);
            }

            ShowCheckpointsInProgressBar();
			UpdateCheckpointSprites();
        }

        private void Start() {
            //PlayerPrefs.SetInt(PlayerPrefsNameCheckp, 1);
            if (isDebugging) {
				PlayerPrefs.SetInt(PlayerPrefsNameCheckp, ChangePlayerPrefs);
			}

			foreach(Transform checkpoint in checkpointParent.transform) {
				checkPoints.Add(checkpoint.gameObject);
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
			PlayerPrefs.SetInt(PlayerPrefsNameCheckp, checkpointNumber);
		}

		public GameObject GetCurrentCheckpoint() {
			if(ForceCheckpointNumber > -1) {
				return checkPoints[ForceCheckpointNumber];
			} else {
				return checkPoints[PlayerPrefs.GetInt(PlayerPrefsNameCheckp)];
			}
		}

		void DisableOtherSpawnPoints(GameObject currentSpawnPoint) {
			foreach(GameObject spawnpoint in checkPoints) {
				spawnpoint.SetActive(spawnpoint == currentSpawnPoint);
			}
		}

        private void ShowCheckpointsInProgressBar()
        {
            foreach (Transform checkpoint in checkpointParent)
            {
				int checkpointIndex = checkpoint.GetSiblingIndex();

                // Don't show the start checkpoint.
                if (checkpointIndex == 0 || checkpoint.GetComponent<Checkpoint>().IsUsedInDebugging)
                {
                    continue;
                }

				//show checkpoint unlocked sprite if checkpoint unlocked, else show locked sprite
				bool checkpointUnlocked = PlayerPrefs.GetInt(PlayerPrefsNameCheckp, checkpointIndex) >= checkpointIndex;

                float percentage = checkpoint.position.x / (progressMeter.Finish.position.x - progressMeter.Start.position.x);
                progressMeter.PlaceCheckpointMarker(percentage, checkpointUnlocked);
            }
        }

		private void UpdateCheckpointSprites() {
			foreach(Transform checkpoint in checkpointParent) {
				int checkpointIndex = checkpoint.GetSiblingIndex();

				// Skip the start checkpoint.
				if(checkpointIndex == 0 || checkpoint.GetComponent<Checkpoint>().IsUsedInDebugging) {
					continue;
				}

				//show checkpoint unlocked sprite if checkpoint unlocked, else show locked sprite
				bool checkpointUnlocked = PlayerPrefs.GetInt(PlayerPrefsNameCheckp, checkpointIndex) >= checkpointIndex;
				if(checkpointUnlocked) {
					checkpoint.GetComponent<Checkpoint>().Activate();
				}
			}
		}


		public void UnlockCheckpoint(int index)
        {
            // Prevents double unlock on start.
            if (PlayerPrefs.GetInt(PlayerPrefsNameCheckp) == index)
            {
                return;
            }

            Debug.Log($"Unlock checkpoint: {index}", this);

            PlayerPrefs.SetInt(PlayerPrefsNameCheckp, index);
            checkpointParent.GetChild(index).GetComponent<Checkpoint>().Unlock();
            progressMeter.ActivateCheckpoint(index - 1);
        }

        private void ActivateUnlockedCheckpoints()
        {
            //for (int i = 0; i < PlayerPrefs.GetInt(PlayerPrefsNameCheckpLvl1) + 1; i++)
            //{
            //    Checkpoint checkpoint = level1Checkpoints[i].GetComponent<Checkpoint>();

            //    if (checkpoint.IsUsedInDebugging)
            //    {
            //        continue;
            //    }

            //    level1Checkpoints[i].GetComponent<Checkpoint>().Activate();

            //    if (i < PlayerPrefs.GetInt(PlayerPrefsNameCheckpLvl1))
            //    {
            //        progressMeter.ActivateCheckpoint(i);
            //    }
            //}
        }
    }
}
