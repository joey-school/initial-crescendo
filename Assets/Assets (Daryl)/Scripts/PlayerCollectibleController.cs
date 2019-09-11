using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class PlayerCollectibleController : MonoBehaviour
    {

        public delegate void DieEventHandler();
        public static event DieEventHandler Died;
        
        [SerializeField]
        private ScoreManager scoreManager;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.tag, this);

            switch (collision.tag)
            {
                case "Collectible":
                    Destroy(collision.gameObject);
                    scoreManager.Score++;
                    break;
            }
        }
    }
}