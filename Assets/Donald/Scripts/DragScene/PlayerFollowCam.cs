using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    public float ConstantZ;
    public Vector2 Offset;
    public bool FollowCamX;
    public bool FollowCamY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowCamX)
        {
            transform.position = new Vector3(Camera.main.transform.position.x + Offset.x, transform.position.y, ConstantZ);
        }
        if (FollowCamY)
        {
            transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y + Offset.y, ConstantZ);
        }
    }
}
