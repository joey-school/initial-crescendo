using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Crescendo.InitialCrescendo
{
    public class PlayerCollisionController : MonoBehaviour
    {
        public delegate void DieEventHandler();
        public static event DieEventHandler Died;
		[SerializeField] private float TimmyCanonForce;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Checkpoint":
                    CheckpointManager.Instance.UnlockCheckpoint();
                    break;
				case "TimmyCanon":
					Debug.Log("launch!");
					gameObject.GetComponent<Rigidbody2D>().AddForce(collision.GetComponent<Canon>().ForceLaunch);
					break;
            }
        }
    }
}