using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform endpoint;
    [SerializeField] private float duration;
    [SerializeField] private float timer; //decides after which time the platform moves, can happen while player walks over platform
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("MovePlatform", timer);
        }
    }

    private void MovePlatform()
    {
        transform.DOMove(endpoint.position, duration);
    }
}
