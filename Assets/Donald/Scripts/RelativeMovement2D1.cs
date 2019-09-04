using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement2D1 : MonoBehaviour
{
    public AnimationCurve CurveHorizontalMovement;
    public float HorizontalSpeed;
    public AnimationCurve CurveVerticalMovement;
    public float VerticalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurveHorizontalMovement != null)
        {
            transform.position += new Vector3(HorizontalSpeed * CurveHorizontalMovement.Evaluate(Time.time % 1), 0, 0);
        }

        if (CurveHorizontalMovement != null)
        {
            transform.position += new Vector3(0, VerticalSpeed * CurveVerticalMovement.Evaluate(Time.time % 1), 0);
        }
    }
}
