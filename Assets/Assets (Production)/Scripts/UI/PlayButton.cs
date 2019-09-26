using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(1.1f, 0.6f).SetEase(Ease.InOutSine));
        sequence.SetLoops(-1, LoopType.Yoyo);
        sequence.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
