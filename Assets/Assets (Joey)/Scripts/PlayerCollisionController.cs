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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.tag, this);

            switch (collision.tag)
            {
                case "Collectible":
                    Destroy(collision.gameObject);
                    break;
                case "Hazard":
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
            }
        }
    }
}