﻿using System.Collections;
using System.Collections.Generic;
using Crescendo.InitialCrescendo;
using DG.Tweening;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class StartDoor : MonoBehaviour
    {
        [SerializeField]
        public float waitingTime = 2f;

        [SerializeField]
        private SpriteRenderer closedDoorSprite;

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

            yield return new WaitForSeconds(waitingTime);

            playerMovementController.RunPower = defaultRunPower;
            playerMovementController.JumpPower = defaultJumpPower;
            playerMovementController.Jump();
        }

        private void FadeOutDoor()
        {
            closedDoorSprite.DOFade(0f, 1f).SetEase(Ease.Linear);
        }
    }
}