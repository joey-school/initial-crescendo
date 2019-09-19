using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class DevAudioCheckPoint : MonoBehaviour
	{
		[SerializeField] private float StartTimeSeconds;

		[HideInInspector]
		public bool Active;

		private AudioSource AudioSource;

		private void Start() {
			if(Active) {
				SoundManager.Instance.SetLevelThemeTime(StartTimeSeconds);
			}
		}

		private void OnTriggerEnter2D(Collider2D collision) {
			if(Active) {
				SoundManager.Instance.StartSong();
			}
		}
	}
}
