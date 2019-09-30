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
        Vector3 touchPosWorld;

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
                touchPosWorld = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
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
                        touchPosWorld = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane);
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
            Vector2 touchPosWorld2D = Camera.main.ScreenToWorldPoint(touchPosWorld);
            // selecting the collectible layer
            int layerMask = 1 << 9;
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward, Mathf.Infinity, layerMask);
            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);

                // Obtaining the collectible part
                MovingInteractableCollectible note = hitInformation.transform.gameObject.transform.GetChild(2).gameObject.GetComponent<MovingInteractableCollectible>();
                note.Collect();
            }
            else
            {
                HandleMovement();
            }
        }

        private void HandleMovement()
        {
            if (movementController.IsGrounded)
            {
                movementController.Jump();
            }
            else if (movementController.ActiveMovementType == PlayerMovementTypes.Gliding)
            {
                movementController.JumpFromGlider();
            }
        }

        private void HandleInputUp()
        {

        }

        private void HandleInputHold()
        {

        }

        // Fix with checking for either mouse or input, connect to Scoremanager and collectible
        private void CheckCollectible()
        {

        }
    }
}