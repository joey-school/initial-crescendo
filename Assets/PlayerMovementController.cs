using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class PlayerMovementController : MonoBehaviour
    {

        private float lineSpacing = 2f;

        private void Awake()
        {
            PlayerGestureController.SwipedUp += PlayerGestureController_SwipedUp;
            PlayerGestureController.SwipedDown += PlayerGestureController_SwipedDown;
        }

        private void JumpOnStaff()
        {
            transform.position += Vector3.up * lineSpacing;
        }

        private void DropOnStaff()
        {
            transform.position += Vector3.down * lineSpacing;
        }

        private void PlayerGestureController_SwipedUp()
        {
            JumpOnStaff();
        }

        private void PlayerGestureController_SwipedDown()
        {
            DropOnStaff();
        }
    }
}