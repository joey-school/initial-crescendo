using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    public AudioSource MyAudioSource;

    bool playing;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("keydown");
                MyAudioSource.Play();
                playing = true;
            }
        }
    }
}
