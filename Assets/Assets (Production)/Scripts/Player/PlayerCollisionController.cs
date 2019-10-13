using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class PlayerCollisionController : MonoBehaviour
    {
        public delegate void DieEventHandler();
        public static event DieEventHandler Died;

        [SerializeField]
        private ScoreManager scoreManager;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            switch (collision.transform.tag)
            {
                case "Hazard":

                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log($"[Player] OnTriggerEnter2D(): Tag: {collision.tag}", this);

            switch (collision.tag)
            {
                case "Checkpoint":
                    //CheckpointManager.Instance.UnlockCheckpoint();
                    break;
				case "TimmyCanon":
					//gameObject.GetComponent<PlayerMovementController>().IsGrounded = false;
					gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					gameObject.GetComponent<Rigidbody2D>().AddForce(collision.GetComponent<Canon>().ForceLaunch);
					break;
                case "Collectible":
                    Destroy(collision.gameObject);
                    SoundManager.Instance.PlaySoundFX(Sounds.Collectible);
                    scoreManager.Score++;
                    break;
            }
        }
    }
}