using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float RunSpeed;
    public float JumpForce;
    public Sprite JumpStickman;
    public Sprite RunStickman;

    bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = RunStickman;
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        float timeScale = GetComponent<PlayerTime>().TimeScale;
        transform.position += new Vector3(RunSpeed * timeScale,0,0);

        if (Input.GetMouseButtonDown(0))
        {
            if (!jumping)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
                GetComponent<SpriteRenderer>().sprite = JumpStickman;
                jumping = true;
            } else if (jumping)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -JumpForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains("barline"))
        {
            jumping = false;
            GetComponent<SpriteRenderer>().sprite = RunStickman;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("GoodNote"))
        {
            Destroy(collision.gameObject);
        }
    }
}
