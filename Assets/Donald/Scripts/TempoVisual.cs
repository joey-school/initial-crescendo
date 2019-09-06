using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoVisual : MonoBehaviour
{
    public Color Color;
    public GameObject LinePrefab;
    public float XOfFirstLine;
    public float DistanceBetweenLines;
    public int AmountOfLines;
    public float YValueForAllLines;
    public float MusicBPM;
    public float PlayerDistancePer100Frames;
    public int FramesPerSecond;
    public ThickenCertainLines ThickenCertainLinesScript;

    float prevDistanceBetweenLines;
    float prevXOfFirstLine;

    // Start is called before the first frame update
    void Start()
    {
        FramesPerSecond = Application.targetFrameRate;
        float playerDistancePerSecond = PlayerDistancePer100Frames/100 * FramesPerSecond;
        float playerDistancePerMinute = playerDistancePerSecond * 60;
        float playerDistancePerBeat = playerDistancePerMinute / MusicBPM;
        DistanceBetweenLines = playerDistancePerBeat;

        for(int i = 0; i < AmountOfLines; i++)
        {
            GameObject newLine = Instantiate(LinePrefab, transform);
            newLine.transform.position = new Vector3(transform.position.x + XOfFirstLine + i * DistanceBetweenLines, YValueForAllLines, transform.position.z);
            newLine.GetComponentInChildren<SpriteRenderer>().color = Color;
            //newLine.transform.SetParent(transform);
        }

        prevDistanceBetweenLines = DistanceBetweenLines;
        prevXOfFirstLine = XOfFirstLine;

        if(ThickenCertainLinesScript != null)
        {
            ThickenCertainLinesScript.Thicken();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(prevDistanceBetweenLines != DistanceBetweenLines)
        {
            float differenceX = DistanceBetweenLines - prevDistanceBetweenLines;
            Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
            for (int i = 0; i < childrenTransforms.Length; i++)
            {
                Transform t = childrenTransforms[i];
                t.position = new Vector3(t.position.x + i * differenceX, t.position.y, t.position.z);
            }
            prevDistanceBetweenLines = DistanceBetweenLines;
        }
        if(prevXOfFirstLine != XOfFirstLine)
        {
            float differenceX = XOfFirstLine - prevXOfFirstLine;
            Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
            for (int i = 0; i < childrenTransforms.Length; i++)
            {
                Transform t = childrenTransforms[i];
                t.position = new Vector3(t.position.x + differenceX, t.position.y, t.position.z);
            }
            prevXOfFirstLine = XOfFirstLine;
        }
    }
}
