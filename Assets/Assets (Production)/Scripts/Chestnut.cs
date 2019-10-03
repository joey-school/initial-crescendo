using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Chestnut : MonoBehaviour
    {

        private new Rigidbody2D rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            //rigidbody.AddForce(Vector2.left * 30f, ForceMode2D.Impulse);
        }
    }
}