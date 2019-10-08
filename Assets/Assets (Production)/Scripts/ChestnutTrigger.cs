using System.Collections;
using System.Collections.Generic;
using Crescendo.SymphoSprint;
using UnityEngine;

public class ChestnutTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.GetComponent<Chestnut>().OnChildTriggerEnter2D(collision);
    }
}
