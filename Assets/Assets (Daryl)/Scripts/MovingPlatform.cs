using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform endpoint;
    [SerializeField] private float duration;
    [SerializeField] private bool platformTimed; //if true this platform will move after 'timer' amount of seconds
    [SerializeField] private float timer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(droppingPlatform) 
            {
                Invoke("MovePlatform", timer);
            } else {
                MovePlatform();
            }
        }
    }

    private void MovePlatform()
    {
        transform.DOMove(endpoint.position, duration);
    }
}
