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
            switch (collision.tag)
            {
                case "Collectible":
                    Destroy(collision.gameObject);
					SoundManager.Instance.PlaySoundFX(Sounds.Collectible);
                    scoreManager.Score++;
                    break;
            }
        }
    }
}