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

        public AudioSource LevelThemeAudioSource
        {
            get
            {
                return levelThemeAudioSource;
            }
        }

        [SerializeField]
		private AudioSource soundFXAudioSource;

		[SerializeField] private Ease easingOfDeath;
		[SerializeField] private float easingLength;
		

		[SerializeField]
		private AudioClip
			mainMenuTheme,
			level1Theme,
			level2Theme,
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
		private string collectibleSoundAndroidFileName,
			startGameButtonAndroidFileName,
			pauseButtonAndroidFileName
		,resumeButtonAndroidFileName
		,restartButtonAndroidFileName
		,quitButtonAndroidFileName
		,deadRestartButtonAndroidFileName
		,deadQuitLevelButtonAndroidFileName
		,levelCompletedAndroidFileName
		,endLevelRestartButtonAndroidFileName
		,endLevelQuitLevelButtonAndroidFileName;

		private int collectibleSoundAndroidID;
		private int startGameButtonAndroidID;
		private int pauseButtonAndroidID;
		private int resumeButtonAndroidID;
		private int restartButtonAndroidID;
		private int quitButtonAndroidID;
		private int deadRestartButtonAndroidID;
		private int deadQuitLevelButtonAndroidID;
		private int levelCompletedAndroidID;
		private int endLevelRestartButtonAndroidID;
		private int endLevelQuitLevelButtonAndroidID;

		private float timeOnPause;

		private void Awake() {
			if(Instance != null && Instance != this) {
				Destroy(gameObject);
			} else {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}

#if UNITY_ANDROID && !UNITY_EDITOR
        collectibleSoundAndroidID = AudioCenter.loadSound (collectibleSoundAndroidFileName);
		startGameButtonAndroidID = AudioCenter.loadSound (startGameButtonAndroidFileName);
		pauseButtonAndroidID = AudioCenter.loadSound (pauseButtonAndroidFileName);
		resumeButtonAndroidID = AudioCenter.loadSound (resumeButtonAndroidFileName);
		restartButtonAndroidID = AudioCenter.loadSound (restartButtonAndroidFileName);
		quitButtonAndroidID = AudioCenter.loadSound (quitButtonAndroidFileName);
		deadRestartButtonAndroidID = AudioCenter.loadSound (deadRestartButtonAndroidFileName);
		deadQuitLevelButtonAndroidID = AudioCenter.loadSound (deadQuitLevelButtonAndroidFileName);
		levelCompletedAndroidID = AudioCenter.loadSound (levelCompletedAndroidFileName);
		endLevelRestartButtonAndroidID = AudioCenter.loadSound (endLevelRestartButtonAndroidFileName);
		endLevelQuitLevelButtonAndroidID = AudioCenter.loadSound (endLevelQuitLevelButtonAndroidFileName);
#endif
		}

		private void Start() {


			string levelName = SceneManager.GetActiveScene().name;

			if(levelName == LevelManager.Instance.MainMenuName) {
				levelThemeAudioSource.clip = mainMenuTheme;
				levelThemeAudioSource.loop = true;
				StartSong();
			} else if(levelName == LevelManager.Instance.Level1Name) {
				levelThemeAudioSource.Stop();
				levelThemeAudioSource.clip = level1Theme;
				//DON'T PLAY HERE. PlayerSpawnPoint handles that.
			} else if(levelName == LevelManager.Instance.Level2Name) {
				levelThemeAudioSource.Stop();
				levelThemeAudioSource.clip = level2Theme;
				//DON'T PLAY HERE. PlayerSpawnPoint handles that.
			} else {
				levelThemeAudioSource.Stop();
			}
		}

		private void OnLevelWasLoaded(int level) {

			string levelName = SceneManager.GetActiveScene().name;

			if(levelName == LevelManager.Instance.MainMenuName) {
				levelThemeAudioSource.clip = mainMenuTheme;
				levelThemeAudioSource.loop = true;
				StartSong();
			} else if(levelName == LevelManager.Instance.Level1Name) {
				levelThemeAudioSource.Stop();
				levelThemeAudioSource.clip = level1Theme;
				//DON'T PLAY HERE. PlayerSpawnPoint handles that.
			} else if(levelName == LevelManager.Instance.Level2Name) {
				levelThemeAudioSource.Stop();
				levelThemeAudioSource.clip = level2Theme;
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
				case Sounds.StartGame:
					ID = startGameButtonAndroidID;
					break;
				case Sounds.Pause:
					ID = pauseButtonAndroidID;
					break;
				case Sounds.Resume:
					ID = resumeButtonAndroidID;
					break;
				case Sounds.Restart:
					ID = restartButtonAndroidID;
					break;
				case Sounds.QuitLevel:
					ID = quitButtonAndroidID;
					break;
				case Sounds.DeadRestart:
					ID = deadRestartButtonAndroidID;
					break;
				case Sounds.DeadQuitLevel:
					ID = deadQuitLevelButtonAndroidID;
					break;
				case Sounds.LevelCompleted:
					ID = levelCompletedAndroidID;
					break;
				case Sounds.EndLevelRestart:
					ID = endLevelRestartButtonAndroidID;
					break;
				case Sounds.EndLevelQuitLevel:
					ID = endLevelQuitLevelButtonAndroidID;
					break;
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