using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class Menu_Buttons : MonoBehaviour
    {
        [SerializeField] private string SceneName;
        
        public void StartGame()
        {
            SceneManager.LoadScene(SceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
