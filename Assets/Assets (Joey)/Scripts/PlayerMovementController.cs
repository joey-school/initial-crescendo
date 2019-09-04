using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Crescendo.InitialCrescendo
{
    public class PlayerMovementController : MonoBehaviour
    {

        [SerializeField]
        private float runSpeed = 5f;

        private float lineSpacing = 2f;

        private bool gameIsRunning = false;

        private void OnEnable()
        {
            PlayerGestureController.SwipedUp += PlayerGestureController_SwipedUp;
            PlayerGestureController.SwipedDown += PlayerGestureController_SwipedDown;
        }

        private void OnDisable()
        {
            PlayerGestureController.SwipedUp -= PlayerGestureController_SwipedUp;
            PlayerGestureController.SwipedDown -= PlayerGestureController_SwipedDown;
        }

        private void Update()
        {
            if (!gameIsRunning)
            {
                return;
            }

            Run();
        }

        private void Run()
        {
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
        }

        public void JumpOnStaff()
        {
            //transform.position += Vector3.up * lineSpacing;
            transform.DOKill();
            transform.DOMoveY(transform.position.y + lineSpacing, 0.2f).SetEase(Ease.OutSine);
        }

        public void DropOnStaff()
        {
            //transform.position += Vector3.down * lineSpacing;
            transform.DOKill();
            transform.DOMoveY(transform.position.y - lineSpacing, 0.2f).SetEase(Ease.InSine);
        }

        public void StartGame()
        {
#if UNITY_EDITOR
            gameIsRunning = true;
#elif UNITY_ANDROID
            StartCoroutine(Foo());
#endif

        }

        private IEnumerator Foo()
        {
            float v = 0.3f;

            yield return new WaitForSeconds(v);

            gameIsRunning = true;
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