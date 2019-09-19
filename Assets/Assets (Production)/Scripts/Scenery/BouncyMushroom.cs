using System.Collections;
using System.Collections.Generic;
using Crescendo.InitialCrescendo;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class BouncyMushroom : MonoBehaviour
    {

        [SerializeField]
        [Range(1f, 10f)]
        private float bounceFactor = 2f;

        private Animation animation;

        private void Awake()
        {
            animation = GetComponent<Animation>();
            //Time.timeScale = 0.3f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerMovementController playerMovementController = collision.GetComponent<PlayerMovementController>();

                Debug.LogFormat("player y: {0}, mushroom y: {1}", playerMovementController.PreviousColliderBounds.min.y, GetComponent<SpriteRenderer>().bounds.max.y);

                if (playerMovementController.PreviousColliderBounds.min.y > GetComponent<SpriteRenderer>().bounds.max.y)
                {
                    StartCoroutine(playerMovementController.JumpFromMushroom(bounceFactor));
                    animation.Play();
                }
            }
        }
    }
}