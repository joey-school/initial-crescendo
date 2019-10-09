using System.Collections;
using System.Collections.Generic;
using Crescendo.SymphoSprint;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class CheckpointSoundManager : MonoBehaviour
	{
		public bool isPlayerSpawnPoint;

		public float time;

		private void OnTriggerEnter2D(Collider2D collision) {

            // TODO: Make CheckpointManagerLvl1 a singleton.
            CheckpointManagerLvl1 checkpointManager = GameObject.Find("CheckPointManager").GetComponent<CheckpointManagerLvl1>();

            if (collision.tag == "Player") {
                if (isPlayerSpawnPoint) {
					SoundManager.Instance.SetLevelThemeTime(time);
					SoundManager.Instance.StartSong();
                    //Debug.Log($"PlayerX: {collision.transform.position.x}", this);
                } else if (checkpointManager.IsDebugging) {
					AudioSource audioSource = SoundManager.Instance.gameObject.AddComponent<AudioSource>();
					audioSource.clip = SoundManager.Instance.GetThemeCurrentLevel();
					audioSource.time = time;
					audioSource.Play();
				}

                checkpointManager.UnlockCheckpoint(transform.GetSiblingIndex());
            }
		}
    }
}
