using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.Play();
    }
}
