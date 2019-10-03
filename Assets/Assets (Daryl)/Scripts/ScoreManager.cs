using System;
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
        private float percentage;

        public int Score 
        {
            get { return score; }
            set
            {
                score = value;
                Percentage = score;
                scoreText.text = "Completion: " + Math.Round(Percentage) + "%";
            }
        }

        public float Percentage
        {
            get { return percentage; }
            set
            {
                percentage = (100.2f / totalObjects) * value;
            }
        }

        void Start()
        {
            int totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
            int totalInteractables = GameObject.FindGameObjectsWithTag("InteractableCollectible").Length;
            totalObjects = totalCollectibles + totalInteractables;
            score = 0;
            scoreText.text = "Completion: " + score + "%";
        }

    }
}
