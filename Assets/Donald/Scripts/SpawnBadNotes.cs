using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBadNotes : MonoBehaviour
{
    public GameObject BadNotePrefab;
    public Vector3 SpawnPosition;
    public float TimeBetweenSpawnsInSeconds;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > TimeBetweenSpawnsInSeconds)
        {
            Instantiate(BadNotePrefab, SpawnPosition, Quaternion.identity);
            time = 0;
        }
    }
}
