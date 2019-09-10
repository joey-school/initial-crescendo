using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class SoundManager : MonoBehaviour
    {

        private new AudioSource audio;

        private void Awake()
        {
            audio = GetComponent<AudioSource>();
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
    }
}