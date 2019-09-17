using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Crescendo.InitialCrescendo
{
    [RequireComponent(typeof(PlayerMovementController))]
    public class PlayerInputController : MonoBehaviour
    {
    
        private PlayerMovementController movementController;

        private void Awake()
        {
            movementController = GetComponent<PlayerMovementController>();
        }

        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }

#if UNITY_EDITOR
            HandleMouseInput();
#else
            HandleTouchInput();
#endif
        }

        private void HandleMouseInput()
        {
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
            if (movementController.IsGrounded)
            {
                movementController.Jump();
            }
        }

        private void HandleInputUp()
        {

        }

        private void HandleInputHold()
        {

        }
    }
}