using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class VolumeSlider : MonoBehaviour
    {

        [SerializeField] private GameObject SoundManager;
        [SerializeField] private bool MusicSelected;
        [SerializeField] private Slider slider;
        private AudioSource[] AudioSources;

        // Start is called before the first frame update
        void Start()
        {
            AudioSources = SoundManager.GetComponents<AudioSource>();
            if (MusicSelected)
            {
                slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
            } else
            {
                slider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
            }
        }

        public void SetVolume()
        {
            float sliderValue = slider.value;
            if(MusicSelected)
            {
                AudioSources[0].volume = sliderValue/10;
                PlayerPrefs.SetFloat("MusicVolume", sliderValue);
            }
            else
            {
                AudioSources[1].volume = sliderValue/10;
                PlayerPrefs.SetFloat("SFXVolume", sliderValue);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
