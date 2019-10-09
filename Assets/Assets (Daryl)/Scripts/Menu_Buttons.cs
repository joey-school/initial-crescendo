using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class Menu_Buttons : MonoBehaviour
    {
        [SerializeField] private string SceneName;
        [SerializeField]
        private GameObject
            LevelSelectPanel,
            OptionsPanel,
            MenuPanel,
            CheatsPanel,
            CreditsPanel;
        private bool Pressed;

        void Start()
        {
            StartCoroutine(LoadYourAsyncScene());
        }

        IEnumerator LoadYourAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                if (asyncLoad.progress >= 0.9f && Pressed)
                {
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }

        public void StartGame()
        {
            SoundManager.Instance.PlaySoundFX(Sounds.StartGame);
            Pressed = true;
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
