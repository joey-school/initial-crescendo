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
            Debug.LogFormat("tag: {0}, active: {1}", other.tag, dandelion.IsActive);
            if (other.CompareTag("Ground") && dandelion.IsActive)
            {
                dandelion.Detach();
            }
        }
    }
}