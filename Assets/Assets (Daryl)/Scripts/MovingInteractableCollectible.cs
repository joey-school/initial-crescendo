using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class MovingInteractableCollectible : MonoBehaviour
    {
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private GameObject triggerForNote;
        public bool FirstTouched { get; set; }
        public bool Done { get; set; }

        // When player is near collectible
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("It entered");
                FirstTouched = true;
            }
        }

        // When player catches the collectible
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("It left");
                FirstTouched = false;
                Done = true;
            }
        }

        // When the player touches the object and is still available
        public void Collect()
        {
            if (FirstTouched)
            {
                Debug.Log("Succeeded");
                Destroy(gameObject);
                Destroy(triggerForNote);
                SoundManager.Instance.PlaySoundFX(Sounds.Collectible);
                scoreManager.Score++;
            }
            else
            {
                Debug.Log("Failed");
                Destroy(triggerForNote);
            }
        }
    }
}