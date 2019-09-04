using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class CameraMovementController : MonoBehaviour
    {

        [SerializeField]
        private Transform target;

        private Vector3 defaultPosition;
        private float xDistanceToTarget;

        private void Awake()
        {
            defaultPosition = transform.position;
            xDistanceToTarget = target.position.x - transform.position.x; 
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(target.position.x - xDistanceToTarget, transform.position.y, transform.position.z);
        }
    }
}