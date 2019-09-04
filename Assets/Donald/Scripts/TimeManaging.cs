using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManaging : MonoBehaviour
{
    public float TimeScale;
    public GameObject Player;
    public AudioSource Audio;

    float prevTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<PlayerTime>().TimeScale = TimeScale;
        Audio.pitch = TimeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevTimeScale != TimeScale)
        {
            Player.GetComponent<PlayerTime>().TimeScale = TimeScale;
            Audio.pitch = TimeScale;
        }
    }
}
