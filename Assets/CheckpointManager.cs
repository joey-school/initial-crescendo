using System.Collections;
using System.Collections.Generic;
using Crescendo.SymphoSprint;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class CheckpointManager : MonoBehaviour
    {
        [SerializeField]
        private Transform player;

        public static CheckpointManager Instance { get; private set; }

        private List<Transform> checkpoints = new List<Transform>();
        private int activeCheckpointIndex = -1;

        private void Awake()
        {
            Instance = this;

            foreach (Transform checkpoint in transform)
            {
                checkpoints.Add(checkpoint);
            }

            if (PlayerPrefs.HasKey("ActiveCheckpointIndex"))
            {
                activeCheckpointIndex = PlayerPrefs.GetInt("ActiveCheckpointIndex");

                SpawnPlayerAtActiveCheckpoint();
                ActivateUnlockedCheckpoints();
            }
        }

        public void UnlockCheckpoint()
        {
            activeCheckpointIndex++;

            SaveCheckpoint();
            ActivateCheckpoint();
        }

        private void SaveCheckpoint()
        {
            PlayerPrefs.SetInt("ActiveCheckpointIndex", activeCheckpointIndex);
        }

        private void ActivateCheckpoint()
        {
            checkpoints[activeCheckpointIndex].GetChild(0).GetComponent<PlayerSpawnPoint>().Activate();
        }

        private void ActivateUnlockedCheckpoints()
        {
            for (int i = 0; i < activeCheckpointIndex + 1; i++)
            {
                checkpoints[i].GetChild(0).GetComponent<PlayerSpawnPoint>().Activate();
            }
        }

        private void SpawnPlayerAtActiveCheckpoint()
        {
            player.position = checkpoints[activeCheckpointIndex].GetChild(0).position;
            Camera.main.transform.position = new Vector3(checkpoints[activeCheckpointIndex].GetChild(0).position.x + 6f, checkpoints[activeCheckpointIndex].GetChild(0).position.y, -10f);
        }
    }
}