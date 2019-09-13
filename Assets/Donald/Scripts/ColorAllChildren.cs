using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorAllChildren : MonoBehaviour
{
    public Color Color;

    private Color prevColor;

    // Start is called before the first frame update
    void Start()
    {
        prevColor = Color;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevColor != Color)
        {
            Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
            foreach (Transform t in childrenTransforms)
            {
                t.GetComponentInChildren<SpriteRenderer>().color = Color;
            }
            prevColor = Color;
        }
    }
}
