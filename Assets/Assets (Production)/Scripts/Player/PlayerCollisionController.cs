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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("coll", this);
            Debug.Log(collision.transform.tag, this);

            switch (collision.transform.tag)
            {
                case "Hazard":


                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Checkpoint":
                    //CheckpointManager.Instance.UnlockCheckpoint();
                    break;
            }
        }
    }
}