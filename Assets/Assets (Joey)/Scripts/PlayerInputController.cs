using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    [RequireComponent(typeof(PlayerGestureController))]
    public class PlayerInputController : MonoBehaviour
    {

        public Vector3 TouchPosition { get; private set; }
        public Vector3 StartTouchPosition { get; private set; }
        public Vector3 PreviousTouchPosition { get; private set; }

        public bool BeganTouchThisRound { get; private set; }
        public bool IsDown { get; private set; }

        private PlayerGestureController gestureController;

        private void Awake()
        {
            gestureController = GetComponent<PlayerGestureController>();
        }

        private void Update()
        {
#if UNITY_EDITOR
            HandleMouseInput();
#else
            HandleTouchInput();
#endif
        }

        private void FixedUpdate()
        {
            if (IsDown && BeganTouchThisRound)
            {
                Vector3 distance = TouchPosition - PreviousTouchPosition;

                //playerMovementController.Move(new Vector2(distance.x, distance.y));
                //playerTouchRing.Move(new Vector3(touchPosition.x, touchPosition.y, 0f));

                PreviousTouchPosition = TouchPosition;
            }
        }

        private void HandleMouseInput()
        {
            TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            if (Input.GetMouseButtonDown(0))
            {
                HandleInputDown();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                HandleInputUp();
            }
            else if (Input.GetMouseButton(0))
            {
                HandleInputHold();
            }
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                TouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.z));

                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        HandleInputDown();
                        break;
                    case TouchPhase.Ended:
                        HandleInputUp();
                        break;
                    case TouchPhase.Canceled:

                        break;
                    // use case?
                    default:
                        HandleInputHold();
                        break;
                }
            }
        }

        private void HandleInputDown()
        {
            //Debug.Log("Down", this);

            StartTouchPosition = TouchPosition;
            PreviousTouchPosition = TouchPosition;

            BeganTouchThisRound = true;
        }

        private void HandleInputUp()
        {
            //Debug.Log("Up", this);

            gestureController.Reset();

            IsDown = false;
        }

        private void HandleInputHold()
        {
            //Debug.Log("Hold", this);

            if (BeganTouchThisRound)
            {
                IsDown = true;
            }
        }
    }
}