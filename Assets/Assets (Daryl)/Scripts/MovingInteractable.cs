using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Crescendo.InitialCrescendo
{
    public class MovingInteractable : MonoBehaviour
    {
        [SerializeField] private Transform endpoint;
        [SerializeField] private MovingInteractableCollectible collectible;
        [SerializeField] private GameObject bird;
        [SerializeField] private float durationToPlatform; //speed of bird approaching
        [SerializeField] private float movePower;
        private bool doneMoving = false;
        private Rigidbody2D rgbd;

        void Start()
        {
            rgbd = GetComponent<Rigidbody2D>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                rgbd.velocity = new Vector2(movePower, rgbd.velocity.y);
                StartCoroutine("BirdToPlatformCoroutine");
            }

        }

        IEnumerator BirdToPlatformCoroutine()
        {
            bird.SetActive(true);
            Tween mytween = bird.transform.DOMove(transform.position, durationToPlatform);
            yield return mytween.WaitForCompletion();
            MovePlatform();
        }

        private void MovePlatform()
        {
            if (collectible)
            {
                collectible.transform.DOMove(endpoint.position, durationToPlatform);
            }
            bird.transform.DOMove(endpoint.position, durationToPlatform);
        }
    }
}