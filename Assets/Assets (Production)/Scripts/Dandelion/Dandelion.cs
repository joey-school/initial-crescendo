using System.Collections;
using System.Collections.Generic;
using Crescendo.InitialCrescendo;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class Dandelion : MonoBehaviour
    {

        [SerializeField]
        [Range(0, 100)]
        private float fallFactor;

        [SerializeField]
        private Transform handle;

        [SerializeField]
        private new ParticleSystem particleSystem;

        public Rigidbody2D Rigidbody { get; private set; }
        private PlayerMovementController playerMovementController;
        private Animator animator;
        private bool isActive = false;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        public void Attach(GameObject player)
        {
            if (!isActive)
            {
                playerMovementController = player.GetComponent<PlayerMovementController>();

                Rigidbody.bodyType = RigidbodyType2D.Dynamic;
                Rigidbody.velocity = new Vector3(playerMovementController.Rigidbody.velocity.x, -fallFactor, 0f);
                animator.SetBool("IsGliding", true);

                // Unity Bugfix: we need to simulate first otherwise it won't play.
                particleSystem.gameObject.SetActive(true);

                playerMovementController.AttachToGlider(handle, this);

                isActive = true;
            }
        }

        public void Detach()
        {
            playerMovementController.DetachFromGlider();
        }
    }
}