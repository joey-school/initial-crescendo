using Crescendo.InitialCrescendo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MobileAudioTest : MonoBehaviour
{
	[SerializeField] private AudioSource soundFXAudioSource;
	[SerializeField] private AudioClip testAudioClip;
	[SerializeField] private string testAudioFileName;
	[SerializeField] private Text debugText;


	private float time = 0;
	private float target = 0;
	private int testSoundAndroidID;


	private void Awake() {
#if UNITY_ANDROID && !UNITY_EDITOR
        testSoundAndroidID = AudioCenter.loadSound (testAudioFileName);
#endif
		Log("log test");
	}

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;
		if(time > target) {
			PlaySoundFX(Sounds.Pause);
			target += 1;
		}
    }

	public void PlaySoundFX(Sounds sound) {

#if !UNITY_ANDROID || UNITY_EDITOR
		AudioClip clipToPlay = null;

		switch(sound) {
			case Sounds.Pause:
				clipToPlay = testAudioClip;
				break;
		}

		soundFXAudioSource.clip = clipToPlay;
		soundFXAudioSource.Play();

#elif UNITY_ANDROID
            int ID = 0;

            switch (sound)
            {
				case Sounds.Pause:
					ID = testSoundAndroidID;
					break;
				default:
					Log("sound = default");
					break;
            }

		try{
            AudioCenter.playSound (ID);
		} catch (Exception e){
			Log(e.Message);
		}
#endif
	}

	private void Log(string txt) {
		debugText.text = txt;
	}
}
