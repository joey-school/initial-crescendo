using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float ConstantZ;
    public Transform Player;
    public Vector3 Offset;
    public bool FollowPlayerX;
    public bool FollowPlayerY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FollowPlayerX)
        {
            transform.position = new Vector3(Player.position.x + Offset.x, transform.position.y, ConstantZ);
        }
        if (FollowPlayerY)
        {
            transform.position = new Vector3(transform.position.x, Player.position.y + Offset.y, ConstantZ);
        }
    }
}
