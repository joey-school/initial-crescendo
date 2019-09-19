using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class Menu_Buttons : MonoBehaviour
    {
        [SerializeField] private string SceneName;
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
            Pressed = true;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
