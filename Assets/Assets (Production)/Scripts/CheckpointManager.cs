//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Crescendo.SymphoSprint;
//using UnityEngine;

//namespace Crescendo.InitialCrescendo
//{
//    public class CheckpointManager : MonoBehaviour
//    {
//        [SerializeField]
//        private Transform player;

//        [SerializeField]
//        private ProgressMeter progressMeter;

//        public static CheckpointManager Instance { get; private set; }

//        private List<Transform> checkpoints = new List<Transform>();
//        private int activeCheckpointIndex = 0;

//        private void Awake()
//        {
//            Instance = this;

//            foreach (Transform checkpoint in transform)
//            {
//                checkpoints.Add(checkpoint);
//            }
//        }

//        private void Start()
//        {
//            if (PlayerPrefs.HasKey("ActiveCheckpointIndex"))
//            {
//                activeCheckpointIndex = PlayerPrefs.GetInt("ActiveCheckpointIndex");

//                SpawnPlayerAtActiveCheckpoint();
//                ActivateUnlockedCheckpoints();
//            }

//            AddCheckpointMarkersToProgressBar();
//        }

//        private void AddCheckpointMarkersToProgressBar()
//        {
//            for (int i = 0; i < checkpoints.Count; i++)
//            {
//                float percentage = checkpoints[i].position.x / (progressMeter.Finish.position.x - progressMeter.Start.position.x);
//                progressMeter.PlaceCheckpointMarker(percentage);
//            }
//        }

//        public void UnlockCheckpoint()
//        {
//            SaveCheckpoint();
//            ActivateCheckpoint();

//            activeCheckpointIndex++;
//        }

//        private void SaveCheckpoint()
//        {
//            PlayerPrefs.SetInt("ActiveCheckpointIndex", activeCheckpointIndex);
//        }

//        private void ActivateCheckpoint()
//        {
//            checkpoints[activeCheckpointIndex].GetChild(0).GetComponent<PlayerSpawnPoint>().Activate();
//        }

//        private void ActivateUnlockedCheckpoints()
//        {
//            for (int i = 0; i < activeCheckpointIndex; i++)
//            {
//                Debug.Log($"Activate checkpoint: {i}", this);
//                checkpoints[i].GetChild(0).GetComponent<PlayerSpawnPoint>().Activate();
//            }
//        }

//        private void SpawnPlayerAtActiveCheckpoint()
//        {
//            Debug.Log($"Spawn at checkpoint: {activeCheckpointIndex}", this);
//            player.position = checkpoints[activeCheckpointIndex].position;
//            Camera.main.transform.position = new Vector3(checkpoints[activeCheckpointIndex].position.x + 6f, checkpoints[activeCheckpointIndex].position.y, -10f);
//        }
//    }
//}