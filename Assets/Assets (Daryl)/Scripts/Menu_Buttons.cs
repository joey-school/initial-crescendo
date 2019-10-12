using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class Menu_Buttons : MonoBehaviour
    {
        [SerializeField]
        private GameObject
            LevelSelectPanel,
            OptionsPanel,
            MenuPanel,
            CheatsPanel,
            CreditsPanel;
        private bool level1Activated, level2Activated;

        void Start() {
			//StartCoroutine(LoadLevels());
			//StartCoroutine(LoadLevel1());
			//StartCoroutine(LoadLevel2());
		}

		IEnumerator LoadLevels() {
			AsyncOperation asyncLoad1 = SceneManager.LoadSceneAsync(LevelManager.Instance.Level1Name);
			asyncLoad1.allowSceneActivation = false;

			AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync(LevelManager.Instance.Level2Name);
			asyncLoad2.allowSceneActivation = false;

			while(!asyncLoad1.isDone && !asyncLoad2.isDone) {
				if(asyncLoad1.progress >= 0.9f && level1Activated) {
					asyncLoad1.allowSceneActivation = true;
				}
				if(asyncLoad2.progress >= 0.9f && level2Activated) {
					asyncLoad2.allowSceneActivation = true;
				}

				yield return null;
			}
		}

		IEnumerator LoadLevel1()
        {
            AsyncOperation asyncLoad1 = SceneManager.LoadSceneAsync(LevelManager.Instance.Level1Name);
            asyncLoad1.allowSceneActivation = false;

            while (!asyncLoad1.isDone)
            {
                if (asyncLoad1.progress >= 0.9f && level1Activated)
                {
                    asyncLoad1.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        IEnumerator LoadLevel2()
        {
            AsyncOperation asyncLoad2 = SceneManager.LoadSceneAsync(LevelManager.Instance.Level2Name);
            asyncLoad2.allowSceneActivation = false;

            while (!asyncLoad2.isDone)
            {
                if (asyncLoad2.progress >= 0.9f && level2Activated)
                {
                    asyncLoad2.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        public void StartLevel1()
        {
			//if playerprefs bool storyseen:

            SoundManager.Instance.PlaySoundFX(Sounds.StartGame);
			//level1Activated = true;

			//else:
			//show story

			SceneManager.LoadSceneAsync(LevelManager.Instance.Level1Name);
		}

        public void StartLevel2()
        {
			SoundManager.Instance.PlaySoundFX(Sounds.StartGame);
            //level2Activated = true;

			SceneManager.LoadSceneAsync(LevelManager.Instance.Level2Name);
        }

        public void MainMenuActive()
        {
            SoundManager.Instance.PlaySoundFX(Sounds.Pause);
            MenuPanel.SetActive(true);
            OptionsPanel.SetActive(false);
            LevelSelectPanel.SetActive(false);
            CheatsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
        }

        public void OptionsActive()
        {
            SoundManager.Instance.PlaySoundFX(Sounds.Pause);
            MenuPanel.SetActive(false);
            CreditsPanel.SetActive(false);
            CheatsPanel.SetActive(false);
            OptionsPanel.SetActive(true);
        }

        public void CreditsActive()
        {
            SoundManager.Instance.PlaySoundFX(Sounds.Pause);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(true);
        }

        public void LevelSelectActive()
        {
            SoundManager.Instance.PlaySoundFX(Sounds.Pause);
            MenuPanel.SetActive(false);
            LevelSelectPanel.SetActive(true);
        }

        public void CheatsActive()
        {
            SoundManager.Instance.PlaySoundFX(Sounds.Pause);
            OptionsPanel.SetActive(false);
            CheatsPanel.SetActive(true);
        }
    }
}
