using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PlayerSpawnPoint;
    public GameObject GroundingObject;
    public LayerMask LayerMask;
    public bool Grounded = false;

    public float RunSpeed;
    public float JumpForce;

    public bool DrawLine = false;
    public LineRenderer LineRenderer;

    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = PlayerSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            float timeScale = GetComponent<PlayerTime>().TimeScale;
            transform.position += new Vector3(RunSpeed * timeScale, 0, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (running)
            {
                if (Grounded)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
                }
            }
            else
            {
                running = true;
            }
        }

        if (DrawLine)
        {
            Vector3[] positions = new Vector3[LineRenderer.positionCount + 1];
            LineRenderer.GetPositions(positions);
            positions[LineRenderer.positionCount] = transform.position;
            LineRenderer.positionCount = positions.Length;
            LineRenderer.SetPositions(positions);
        }
    }

    private void FixedUpdate()
    {
        Grounded = GroundingObject.GetComponent<BoxCollider2D>().IsTouchingLayers(LayerMask);
    }
}
