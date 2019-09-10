using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField]
    private float effect;

    private float length;
    private float defaultPosition;

    private void Awake()
    {
        defaultPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (Camera.main.transform.position.x * (1 - effect));
        float dist = (Camera.main.transform.position.x * effect);

        transform.position = new Vector3(defaultPosition + dist, transform.position.y, transform.position.z);

        if (temp >  (defaultPosition + length))
        {
            defaultPosition += length;
        }
        else if (temp < (defaultPosition - length))
        {
            defaultPosition -= length;
        }
    }
}
