using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateByAnchor : MonoBehaviour
{
    public float AnchorX;
    public float Ratio;

    private float prevRatio;

    // Start is called before the first frame update
    void Start()
    {
        Ratio = 1;
        prevRatio = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Ratio != prevRatio)
        {
            Transform[] childrenTransforms = GetComponentsInChildren<Transform>();
            foreach (Transform t in childrenTransforms)
            {
                if (t.transform.position.x > AnchorX & Ratio > 0)
                {
                    float initialDistanceToAnchor = t.position.x - AnchorX;
                    float newDistanceToAnchor = Ratio / prevRatio * initialDistanceToAnchor;

                    float newX = AnchorX + newDistanceToAnchor;
                    if (newX > 0 + AnchorX)
                    {
                        t.transform.position = new Vector3(AnchorX + newDistanceToAnchor, t.transform.position.y, t.transform.position.z);
                    }
                }
            }
            prevRatio = Ratio;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
}
