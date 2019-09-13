using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditLine : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3[] positions = new Vector3[LineRenderer.positionCount - 300];
        for(int i = count; i < LineRenderer.positionCount; i++)
        {
            LineRenderer.SetPosition(i - count, LineRenderer.GetPosition(i));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
