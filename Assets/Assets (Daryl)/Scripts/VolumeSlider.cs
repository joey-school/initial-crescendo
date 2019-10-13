using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private bool MusicSelected;
        [SerializeField] private Slider slider;
        private AudioSource[] AudioSources;

        // Start is called before the first frame update
        void Start()
        {
            AudioSources = SoundManager.Instance.GetComponents<AudioSource>();
            if (MusicSelected)
            {
                slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f) * 10;
            } else
            {
                slider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f) * 10;
            }
        }

        public void SetVolume()
        {
            float sliderValue = slider.value;
            if(MusicSelected)
            {
                AudioSources[0].volume = sliderValue/10;
                PlayerPrefs.SetFloat("MusicVolume", sliderValue/10);
            }
            else
            {
                AudioSources[1].volume = sliderValue/10;
                PlayerPrefs.SetFloat("SFXVolume", sliderValue/10);
            }
        }
    }
}
