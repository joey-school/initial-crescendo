using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Crescendo.InitialCrescendo
{
    public class MovingHazard : MonoBehaviour
    {
        [SerializeField] private Transform endpoint;
        [SerializeField] private Transform goal;
        [SerializeField] private GameObject hazard;
        [SerializeField] private float speedToGoal;
        [SerializeField] private float speedToEnd;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                StartCoroutine("HazardCoroutine");
            }
        }

        IEnumerator HazardCoroutine()
        {
            Debug.Log("Start");
            Tween mytween = hazard.transform.DOMove(goal.position, speedToGoal);
            yield return mytween.WaitForCompletion();
            MoveToEnd();
        }

        private void MoveToEnd()
        {
            Debug.Log("Begin");
            hazard.transform.DOMove(endpoint.position, speedToEnd);
        }
    }
}
