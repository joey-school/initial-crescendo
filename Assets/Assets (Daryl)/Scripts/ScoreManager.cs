using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private Text scoreText;
            
        private int score;
        private int totalObjects;
        private int percentage;

        public int Score 
        {
            get { return score; }
            set
            {
                score = value;
                Percentage = score;
                scoreText.text = "Completion: " + Percentage + "%";
            }
        }

        public int Percentage
        {
            get { return percentage; }
            set
            {
                percentage = (100 / totalObjects) * value;
            }
        }

        void Start()
        {
            totalObjects = GameObject.FindGameObjectsWithTag("Collectible").Length;
            score = 0;
            scoreText.text = "Completion: " + 0 + "%";
        }

    }
}
