using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    [RequireComponent(typeof(PlayerInputController))]
    public class PlayerGestureController : MonoBehaviour
    {

        private PlayerInputController inputController;

        private bool hasSwipedUp = false;
        private bool hasSwipedDown = false;

        private float swipeDistance = 1f;

        public delegate void SwipeUpEventHandler();
        public static event SwipeUpEventHandler SwipedUp;
        public delegate void SwipeDownEventHandler();
        public static event SwipeDownEventHandler SwipedDown;

        private void Awake()
        {
            inputController = GetComponent<PlayerInputController>();
        }

        private void Update()
        {
            //Debug.LogFormat("$IsDown: {0}, $TouchPositionY: {1}, $StartTouchPosition: {2}", inputController.IsDown, inputController.TouchPosition, inputController.StartTouchPosition);
            //Debug.LogFormat("$HasSwipedUp: {0}, $HasSwipedDown: {1}", hasSwipedUp, hasSwipedDown);

            if (inputController.IsDown)
            {
                if (!hasSwipedUp)
                {
                    CheckForSwipeUp();
                }

                if (!hasSwipedDown)
                {
                    CheckForSwipeDown();
                }
            }
        }

        private void CheckForSwipeUp()
        {
            if (inputController.TouchPosition.y > inputController.StartTouchPosition.y + swipeDistance)
            {
                Debug.Log("Swipe up!", this);

                Reset();
                hasSwipedUp = true;

                SwipedUp?.Invoke();
            }
        }

        private void CheckForSwipeDown()
        {
            if (inputController.TouchPosition.y < inputController.StartTouchPosition.y - swipeDistance)
            {
                Debug.Log("Swipe down!", this);

                Reset();
                hasSwipedDown = true;

                SwipedDown?.Invoke();
            }
        }

        public void Reset()
        {
            hasSwipedUp = false;
            hasSwipedDown = false;
        }
    }
}