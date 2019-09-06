using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickenCertainLines : MonoBehaviour
{
    public int ThickenEvery;
    public float NewXScale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Thicken()
    {
        Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
        for (int i = 1; i < childrenTransforms.Length + 1; i += ThickenEvery)
        {
            Transform t = childrenTransforms[i];
            t.localScale = new Vector3(NewXScale, t.localScale.y, t.localScale.z);
        }
    }
}
