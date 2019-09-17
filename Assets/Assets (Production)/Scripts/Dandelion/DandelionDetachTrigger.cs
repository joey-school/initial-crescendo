using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class DandelionDetachTrigger : MonoBehaviour
    {

        private Dandelion dandelion;

        private void Awake()
        {
            dandelion = transform.parent.GetComponent<Dandelion>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                dandelion.Detach();
            }
        }
    }
}