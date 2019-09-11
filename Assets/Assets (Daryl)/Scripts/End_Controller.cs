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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Hazard":
                    txt.text = "You failed!";
                    Time.timeScale = 0f;
                    EndPanel.SetActive(true);
                    PauseButton.SetActive(false);
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().PauseSong();
                    break;
                case "Finish":
                    txt.text = "Complete!";
                    Time.timeScale = 0f;
                    EndPanel.SetActive(true);
                    PauseButton.SetActive(false);
                    GameObject.Find("SoundManager").GetComponent<SoundManager>().PauseSong();
                    break;
            }
        }
    }
}
