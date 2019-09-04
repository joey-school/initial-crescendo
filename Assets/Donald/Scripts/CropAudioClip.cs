using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropAudioClip : MonoBehaviour
{
    public AudioSource AudioSource;
    public float StartTimeSeconds;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.time = StartTimeSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
