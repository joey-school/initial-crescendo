using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class SoundManager : MonoBehaviour
    {
		[SerializeField]
        private new AudioSource audio;

		[SerializeField]
		private AudioSource soundFXContainer;

        private void Awake()
        {

        }

        public void StartSong()
        {
            audio.Play();
        }

        public void PauseSong()
        {
            audio.Pause();
        }

        public void UnpauseSong()
        {
            audio.UnPause();
        }

		public void PlaySound(AudioClip Sound) {
			soundFXContainer.clip = Sound;
			soundFXContainer.Play();
		}
    }
}