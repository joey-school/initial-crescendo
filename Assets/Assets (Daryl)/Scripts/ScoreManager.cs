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

        public int Score 
        {
            get { return score; }
            set
            {
                score = value;
                scoreText.text = "Completion: " + score + "/" + totalObjects;
            }
        }

        void Start()
        {
            totalObjects = GameObject.FindGameObjectsWithTag("Collectible").Length;
            score = 0;
            scoreText.text = "Completion: " + 0 + "/" + totalObjects;
        }

    }
}
