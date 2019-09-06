using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit2 : MonoBehaviour
{
    Collider2D notecollision;

    // Start is called before the first frame update
    void Start()
    {
        notecollision = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(notecollision != null)
            {
                Color color = notecollision.GetComponent<SpriteRenderer>().color;
                color.a = 0.5f;
                notecollision.GetComponent<SpriteRenderer>().color = color;
                notecollision = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.ToLower().Contains("notejumpup"))
        {
            notecollision = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        notecollision = null;
    }
}
