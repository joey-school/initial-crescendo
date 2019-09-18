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

        public float RunPower
        {
            get
            {
                return runPower;
            }
            set
            {
                runPower = value;
            }
        }

        [SerializeField]
        private float jumpPower = 2f;

        [SerializeField]
        private LayerMask groundLayers;

        [SerializeField]
        private Transform feet;

        private PlayerInputController inputController;
        public Rigidbody2D Rigidbody { get; private set; }
        private Animator animator;

        public bool IsGrounded { get;  set; } = true;

        private void Awake()
        {
            inputController = GetComponent<PlayerInputController>();
            Rigidbody = GetComponent<Rigidbody2D>();
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

            //if (inputController.IsTouchingScreen)
            //{

            //}

            UpdateAnimator();
        }

        private void Run()
        {
            Rigidbody.velocity = new Vector2(runPower, Rigidbody.velocity.y);
        }

        public void Jump()
        {
            Rigidbody.AddForce(Vector2.up * jumpPower);
        }

        private void UpdateAnimator()
        {
            animator.SetBool("IsGrounded", IsGrounded);
            animator.SetFloat("HorizontalVelocity", Rigidbody.velocity.x);//, 0.1f, Time.deltaTime);
            animator.SetFloat("VerticalVelocity", Rigidbody.velocity.y);//, 0.1f, Time.deltaTime);
        }

        private void CheckGrounded()
        {
            IsGrounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(feet.position, 0.2f, groundLayers);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    IsGrounded = true;
                }
            }
        }
    }
}