using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class CheckpointSoundManager : MonoBehaviour
	{
		public bool isPlayerSpawnPoint;

		public float time;

		private void OnTriggerEnter2D(Collider2D collision) {
			if(collision.tag == "Player") {
				if(isPlayerSpawnPoint) {
					SoundManager.Instance.SetLevelThemeTime(time);
					SoundManager.Instance.StartSong();
                    Debug.Log($"PlayerX: {collision.transform.position.x}", this);
                } else {
					AudioSource audioSource = SoundManager.Instance.gameObject.AddComponent<AudioSource>();
					audioSource.clip = SoundManager.Instance.GetThemeCurrentLevel();
					audioSource.time = time;
					audioSource.Play();
				}
			}
		}
    }
}
