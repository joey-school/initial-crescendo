using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;
    [SerializeField] private float StartTimeSeconds;

    private void Start()
    {
        AudioSource.time = StartTimeSeconds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.Play();
    }
}
