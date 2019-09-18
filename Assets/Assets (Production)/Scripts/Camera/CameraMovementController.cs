using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class CameraMovementController : MonoBehaviour
    {

        [SerializeField]
        private float smoothFactor = 0.5f;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private float xPositionOffset = 2f;

        [SerializeField]
        private float yPositionOffset = 3.9f;

        private Vector3 smoothTargetPositionVelocity = Vector3.zero;

        private void Awake()
        {

        }

        private void Start()
        {

        }

        private void Update()
        {
            Vector3 targetPosition = Vector3.SmoothDamp(transform.position, player.position + (Vector3.right * xPositionOffset) + (Vector3.up * yPositionOffset), ref smoothTargetPositionVelocity, smoothFactor);
            UpdatePosition(new Vector3(targetPosition.x, targetPosition.y, transform.position.z));
        }

        private void UpdatePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}