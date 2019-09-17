using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform endpoint;
    [SerializeField] private float duration;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Moving");
        if (collision.tag == "Player")
        {
            transform.DOMove(endpoint.position, duration);
        }
    }
}
