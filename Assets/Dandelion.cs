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

        private new Rigidbody2D rigidbody;
        private PlayerMovementController playerMovementController;
        private Animator animator;
        private bool isActive = false;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        public void Attach(GameObject player)
        {
            if (!isActive)
            {
                playerMovementController = player.GetComponent<PlayerMovementController>();

                rigidbody.bodyType = RigidbodyType2D.Dynamic;
                rigidbody.velocity = new Vector3(playerMovementController.Rigidbody.velocity.x, -fallFactor, 0f);
                animator.SetBool("IsGliding", true);

                playerMovementController.AttachToGlider(handle);

                isActive = true;
            }
        }

        public void Detach()
        {
            playerMovementController.DetachFromGlider();
        }
    }
}