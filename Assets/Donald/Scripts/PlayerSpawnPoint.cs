using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = SpawnPoint.transform.position;
        SpawnPoint.GetComponentInChildren<DevAudioCheckPoint>().Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
