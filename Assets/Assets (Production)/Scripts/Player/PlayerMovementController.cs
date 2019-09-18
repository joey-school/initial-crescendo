using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Crescendo.SymphoSprint;

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
        public PlayerMovementTypes ActiveMovementType { get; set; } = PlayerMovementTypes.Running;
        private Dandelion activeDandelion;

        private void Awake()
        {
            inputController = GetComponent<PlayerInputController>();
            Rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            CheckGrounded();

            switch (ActiveMovementType)
            {
                case PlayerMovementTypes.Running:
                    Run();
                    break;
                case PlayerMovementTypes.Gliding:

                    break;
            }
        }

        private void Update()
        {
            UpdateAnimator();

            Debug.LogFormat("up: {0}", Rigidbody.velocity.y);
        }

        private void Run()
        {
            Rigidbody.velocity = new Vector2(runPower, Rigidbody.velocity.y);
        }

        public void Jump()
        {
            Rigidbody.AddForce(Vector2.up * jumpPower);
        }

        public void JumpFromGlider()
        {
            transform.DOKill();
            DetachFromGlider();
            Rigidbody.velocity = activeDandelion.Rigidbody.velocity;
            Rigidbody.AddForce(Vector2.up * jumpPower * 1.6f);

            Debug.Log("&&&&&&&", this);
            Debug.LogFormat("up: {0}", Rigidbody.velocity.y);
            Debug.Log("&&&&&&&", this);
        }

        public void AttachToGlider(Transform handle, Dandelion dandelion)
        {
            transform.parent = handle;
            activeDandelion = dandelion;

            // TODO: Calculate target position!
            transform.DOLocalMove(new Vector3(3.36f, -0.79f, 0f), 0.3f).SetEase(Ease.InOutSine);
            Rigidbody.simulated = false;
            ActiveMovementType = PlayerMovementTypes.Gliding;
        }

        public void DetachFromGlider()
        {
            transform.parent = null;
            Rigidbody.simulated = true;
            Rigidbody.bodyType = RigidbodyType2D.Dynamic;
            ActiveMovementType = PlayerMovementTypes.Running;
        }

        private void UpdateAnimator()
        {
            animator.SetBool("IsGrounded", IsGrounded);
            animator.SetBool("IsGliding", ActiveMovementType == PlayerMovementTypes.Gliding);
            animator.SetFloat("HorizontalVelocity", Rigidbody.velocity.x);//, 0.1f, Time.deltaTime);
            animator.SetFloat("VerticalVelocity", Rigidbody.velocity.y);//, 0.1f, Time.deltaTime);
        }

        private void CheckGrounded()
        {
            IsGrounded = false;

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

    public enum PlayerMovementTypes
    {
        Running,
        Gliding
    }
}