using System.Collections;
using System.Collections.Generic;
using Crescendo.InitialCrescendo;
using DG.Tweening;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class StartDoor : MonoBehaviour
    {

        [SerializeField]
        public float waitingTime = 1.5f;

        [SerializeField]
        private SpriteRenderer closedDoorSpite;

        [SerializeField]
        private PlayerMovementController playerMovementController;

        private void Start()
        {
            StartCoroutine(StartGame());
        }

        private IEnumerator StartGame()
        {
            float defaultRunPower = playerMovementController.RunPower;
            float defaultJumpPower = playerMovementController.JumpPower;
            playerMovementController.RunPower = 0f;
            playerMovementController.JumpPower = 0f;

            FadeOutDoor();

            yield return new WaitForSeconds(2f);

            playerMovementController.RunPower = defaultRunPower;
            playerMovementController.JumpPower = defaultJumpPower;
            playerMovementController.Jump();
        }

        private void FadeOutDoor()
        {
            closedDoorSpite.DOFade(0f, 1f).SetEase(Ease.Linear);
        }
    }
}