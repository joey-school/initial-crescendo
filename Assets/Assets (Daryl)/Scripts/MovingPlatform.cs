using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private bool willBeThieved;
    [SerializeField] private Transform endpoint; //where the platform has to move to after bird gets it
    [SerializeField] private GameObject bird;
    [SerializeField] private float duration; //speed of the platform and bird
    [SerializeField] private float timer; //decides after which time the bird comes to take the platform
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (willBeThieved && collision.tag == "Player")
        {
            Invoke("MoveBird", timer);
        }
    }

    // function to move the bird first, invokes the move of the platform after the bird is at the platform
    private void MoveBird()
    {
        bird.SetActive(true);
        bird.transform.DOMove(transform.position, duration);
        Invoke("MovePlatform", duration);
    }

    private void MovePlatform()
    {
        transform.DOMove(endpoint.position, duration);
        bird.transform.DOMove(endpoint.position, duration);
    }
}
