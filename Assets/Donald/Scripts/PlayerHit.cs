using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public AnimationCurve ColorCurve;
    public float FlashDuration;
    public float FlashSpeed;

    float hitTimer;
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        hitTimer = 0;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitTimer > 0)
        {
            AnimateHit();
            Debug.Log(hitTimer);
            hitTimer += Time.deltaTime;
            if(hitTimer > FlashDuration)
            {
                Debug.Log("DONE--------------------------------------");
                hitTimer = 0;
                GetComponent<SpriteRenderer>().color = originalColor;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("BadNote"))
        {
            hitTimer = Time.deltaTime;
        }
    }

    void AnimateHit()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = ColorCurve.Evaluate(Time.time % 1) / FlashSpeed;
        GetComponent<SpriteRenderer>().color = tmp;
    }
}
