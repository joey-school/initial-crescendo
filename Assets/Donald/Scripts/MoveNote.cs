using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNote : MonoBehaviour
{

    public float Speed = 1;
    public Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Speed,0,0);
        if(transform.position.x < -12)
        {
            //transform.position = initialPos;
            Destroy(gameObject);
        }
    }
}
