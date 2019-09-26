using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class DevAudioCheckPoint : MonoBehaviour
	{
		[SerializeField] private float StartTimeSeconds;
		[SerializeField] AudioClip clip;
		[SerializeField] bool addAudioSource;

		private void OnTriggerEnter2D(Collider2D collision) {
			if(addAudioSource) {
				AudioSource audioSource = SoundManager.Instance.gameObject.AddComponent<AudioSource>();
				audioSource.clip = clip;
				audioSource.time = StartTimeSeconds;
				audioSource.Play();
			} else {
				SoundManager.Instance.SetLevelThemeTime(StartTimeSeconds);
				SoundManager.Instance.StartSong();
			}
		}
	}
}
