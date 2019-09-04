using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayer : MonoBehaviour
{
    public bool VerticalMovementOnly;
    public float ConstantZ;

    bool moving;
    Vector3 playerOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            updatePlayerOffset();
            moving = true;
        }

        if (moving)
        {
            Vector3 pointerWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float prevX = transform.position.x;
            transform.position = pointerWorldPos + playerOffset;
            if (VerticalMovementOnly)
            {
                transform.position = new Vector3(prevX, transform.position.y, transform.position.z);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, ConstantZ);
        }

        if (Input.GetMouseButtonUp(0))
        {
            moving = false;
        }
    }
    private void updatePlayerOffset()
    {
        playerOffset = transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    }
}
