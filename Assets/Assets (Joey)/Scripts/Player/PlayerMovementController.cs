using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Crescendo.InitialCrescendo
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMovementController : MonoBehaviour
    {

        [SerializeField]
        private float runPower = 5f;

        [SerializeField]
        private float jumpPower = 2f;

        [SerializeField]
        private LayerMask groundLayers;

        [SerializeField]
        private Transform feet;

        private new Rigidbody2D rigidbody;
        private Animator animator;

        private bool isGrounded = true;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            CheckGrounded();

            Run();
        }

        private void Update()
        {
            //Debug.LogFormat("Velocity, $Y: {0}", rigidbody.velocity.y);

            UpdateAnimator();
        }

        private void Run()
        {
            rigidbody.velocity = new Vector2(runPower, rigidbody.velocity.y);
        }

        public void Jump()
        {
            rigidbody.AddForce(Vector2.up * jumpPower);
        }

        private void UpdateAnimator()
        {
            animator.SetBool("IsGrounded", isGrounded);
            animator.SetFloat("HorizontalVelocity", rigidbody.velocity.x);//, 0.1f, Time.deltaTime);
            animator.SetFloat("VerticalVelocity", rigidbody.velocity.y);//, 0.1f, Time.deltaTime);
        }

        private void CheckGrounded()
        {
            isGrounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.position, 0.2f, groundLayers);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isGrounded = true;
                }
            }
        }
    }
}