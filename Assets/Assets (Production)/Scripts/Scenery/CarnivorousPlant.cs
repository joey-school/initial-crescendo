using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CarnivorousPlant : MonoBehaviour
{
    [SerializeField]
    private Transform stemHandle;

    [SerializeField]
    private Transform leftClaw;

    [SerializeField]
    private Transform rightClaw;

    private bool hasSpottedPlayer;

    private void Awake()
    {
        Ease inEase = Ease.InSine;
        float inDuration = 0.1f;

        Ease outEase = Ease.Linear;
        float outDuration = 0.2f;

        Sequence biteSequence = DOTween.Sequence();
        biteSequence.Append(leftClaw.DOLocalRotate(leftClaw.localEulerAngles + (Vector3.back * 20f), inDuration, RotateMode.Fast).SetEase(inEase));
        biteSequence.Insert(0f, rightClaw.DOLocalRotate(rightClaw.localEulerAngles + (Vector3.forward * 20f), inDuration, RotateMode.Fast).SetEase(inEase));
        biteSequence.Append(leftClaw.DOLocalRotate(leftClaw.localEulerAngles, outDuration, RotateMode.Fast).SetEase(outEase));
        biteSequence.Insert(inDuration, rightClaw.DOLocalRotate(rightClaw.localEulerAngles, outDuration, RotateMode.Fast).SetEase(outEase));
        biteSequence.AppendInterval(0.15f);
        biteSequence.SetLoops(-1, LoopType.Restart);
    }

    private void Update()
    {
        Vector3 targetPosition = GameObject.FindWithTag("Player").transform.position;
        //targetPosition += Vector3.left * 2f;



        if (targetPosition.y <= transform.position.y  + 13f)
        {
            targetPosition = new Vector3(targetPosition.x, transform.position.y + 13f, targetPosition.z);
        }

        //if ((stemHandle.position - targetPosition).magnitude <= 10f)
        //{
        //    hasSpottedPlayer = true;
        //}

        //if (hasSpottedPlayer)
        //{
            stemHandle.position = targetPosition;
        //}
    }
}
