using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class End_Controller : MonoBehaviour
    {
        [SerializeField] private GameObject EndPanel;
        [SerializeField] private GameObject PauseButton;
        [SerializeField] private Text txt;
        [SerializeField] private ScoreManager scoreManager;

        private int currentHighscore = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Hazard":
                    txt.text = "You failed!";
                    Reset();
                    SaveScore();
                    break;
                case "Finish":
                    txt.text = "Complete!";
                    Reset();
                    SaveScore();
                    break;
            }
        }

        private void Reset()
        {
            Time.timeScale = 0f;
            EndPanel.SetActive(true);
            PauseButton.SetActive(false);
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PauseSong(); 
        }

        private void SaveScore()
        {
            if(PlayerPrefs.HasKey("Score"))
            {
                currentHighscore = PlayerPrefs.GetInt("Score");
            }
            if(currentHighscore < scoreManager.Percentage)
            {
                PlayerPrefs.SetInt("Score", scoreManager.Percentage);
            }
        }
    }
}
