using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAllChildren : MonoBehaviour
{
    public Color Color;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
        foreach(Transform t in childrenTransforms)
        {
            t.GetComponentInChildren<SpriteRenderer>().color = Color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
