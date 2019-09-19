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

		[SerializeField]
		private Ease EasingOfDeath;

		[SerializeField]
		private AudioClip
			mainMenuTheme,
			level1Theme,
			startGameButtonFX,
			pauseButtonFX, 
			resumeButtonFX,
			restartButtonFX,
			quitButtonFX,
			deadRestartButtonFX,
			deadQuitLevelButtonFX,
			endLevelRestartButtonFX,
			endLevelQuitLevelButtonFX;

		private float timeOnPause;

		private void Awake() {
			if(Instance != null && Instance != this) {
				Destroy(gameObject);
			} else {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
		}

		private void OnLevelWasLoaded(int level) {
			if(level == 1) {
				levelThemeAudioSource.clip = mainMenuTheme;
				levelThemeAudioSource.Play();
			} else if(level == 2) {
				levelThemeAudioSource.clip = level1Theme;
				//DON'T PLAY HERE. PlayerSpawnPoint handles that.
			} else {
				levelThemeAudioSource.Stop();
			}
		}

		public void SetLevelThemeTime(float time) {
			levelThemeAudioSource.time = time;
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
				levelThemeAudioSource.DOPitch(0, 1f).SetEase(EasingOfDeath).SetUpdate(true).OnComplete(() => { levelThemeAudioSource.Pause(); });
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
				case Sounds.EndLevelRestart:
					clipToPlay = endLevelRestartButtonFX;
					break;
				case Sounds.EndLevelQuitLevel:
					clipToPlay = endLevelQuitLevelButtonFX;
					break;
			}

			soundFXAudioSource.clip = clipToPlay;
			soundFXAudioSource.Play();
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
		EndLevelQuitLevel,
		EndLevelRestart
	}
}