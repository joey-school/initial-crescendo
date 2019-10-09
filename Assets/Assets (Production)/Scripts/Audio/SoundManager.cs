using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace Crescendo.InitialCrescendo
{
    public class SoundManager : MonoBehaviour
    {
		public static SoundManager Instance { get; private set; }

		[SerializeField]
        private AudioSource levelThemeAudioSource;

		[SerializeField]
		private AudioSource soundFXAudioSource;

		[SerializeField] private Ease easingOfDeath;
		[SerializeField] private float easingLength;
		

		[SerializeField]
		private AudioClip
			mainMenuTheme,
			level1Theme,
			//levelClearTheme,
			startGameButtonFX,
			pauseButtonFX, 
			resumeButtonFX,
			restartButtonFX,
			quitButtonFX,
			deadRestartButtonFX,
			deadQuitLevelButtonFX,
			levelCompletedFX,
			endLevelRestartButtonFX,
			endLevelQuitLevelButtonFX,
			collectibleFX;

        [SerializeField]
        private string collectibleSoundAndroidFileName;

        private int collectibleSoundAndroidID;

        [SerializeField] string MainMenuName, Level1Name;

		private float timeOnPause;

		private void Awake() {
			if(Instance != null && Instance != this) {
				Destroy(gameObject);
			} else {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}

            levelThemeAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
            soundFXAudioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

#if UNITY_ANDROID && !UNITY_EDITOR
        collectibleSoundAndroidID = AudioCenter.loadSound (collectibleSoundAndroidFileName);
#endif
        }

        private void OnLevelWasLoaded(int level) {

			string levelName = SceneManager.GetActiveScene().name;

			if(levelName == MainMenuName) {
				levelThemeAudioSource.clip = mainMenuTheme;
				levelThemeAudioSource.loop = true;
				StartSong();
			} else if(levelName == Level1Name) {
				levelThemeAudioSource.Stop();
				levelThemeAudioSource.clip = level1Theme;
				//DON'T PLAY HERE. PlayerSpawnPoint handles that.
			} else {
				levelThemeAudioSource.Stop();
			}

		}

		public float GetLevelThemeTime() {
			return levelThemeAudioSource.time;
		}
		public void SetLevelThemeTime(float time) {
			levelThemeAudioSource.time = time;
		}

		public AudioClip GetThemeCurrentLevel() {
			return levelThemeAudioSource.clip;
		}

		public void StartSong()
        {
			levelThemeAudioSource.pitch = 1;
			levelThemeAudioSource.Play();
        }

        public void PauseSong(bool dead)
        {
			timeOnPause = levelThemeAudioSource.time;

			if(dead) {
				levelThemeAudioSource.DOPitch(0, easingLength).SetEase(easingOfDeath).SetUpdate(true).OnComplete(() => { levelThemeAudioSource.Pause(); });
			} else {
				levelThemeAudioSource.Pause();
			}
        }

        public void UnpauseSong()
        {
			levelThemeAudioSource.pitch = 1;
			levelThemeAudioSource.time = timeOnPause;

			levelThemeAudioSource.UnPause();
        }

		public void PlaySoundFX(Sounds sound) {

#if !UNITY_ANDROID || UNITY_EDITOR
            AudioClip clipToPlay = null;

			switch(sound) {
				case Sounds.StartGame:
					clipToPlay = startGameButtonFX;
					break;
				case Sounds.Pause:
					clipToPlay = pauseButtonFX;
					break;
				case Sounds.Resume:
					clipToPlay = resumeButtonFX;
					break;
				case Sounds.Restart:
					clipToPlay = restartButtonFX;
					break;
				case Sounds.QuitLevel:
					clipToPlay = quitButtonFX;
					break;
				case Sounds.DeadRestart:
					clipToPlay = deadRestartButtonFX;
					break;
				case Sounds.DeadQuitLevel:
					clipToPlay = deadQuitLevelButtonFX;
					break;
				case Sounds.LevelCompleted:
					clipToPlay = levelCompletedFX;
					break;
				case Sounds.EndLevelRestart:
					clipToPlay = endLevelRestartButtonFX;
					break;
				case Sounds.EndLevelQuitLevel:
					clipToPlay = endLevelQuitLevelButtonFX;
					break;
				case Sounds.Collectible:
					clipToPlay = collectibleFX;
					break;
			}

			soundFXAudioSource.clip = clipToPlay;
			soundFXAudioSource.Play();
#elif UNITY_ANDROID
            int ID = 0;

            switch (sound)
            {
                case Sounds.Collectible:
                    ID = collectibleSoundAndroidID;
                    break;
            }

            AudioCenter.playSound (ID);
#endif
        }
    }

	public enum Sounds
	{
		StartGame,
		Pause,
		Resume,
		Restart,
		QuitLevel,
		DeadRestart,
		DeadQuitLevel,
		LevelCompleted,
		EndLevelQuitLevel,
		EndLevelRestart,
		Collectible
	}
}