using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevAudioCheckPoint : MonoBehaviour
{
    [SerializeField] private float StartTimeSeconds;

    [HideInInspector]
    public bool Active;

    private AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.time = StartTimeSeconds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Active)
        {
            AudioSource.Play();
        }
    }
}
