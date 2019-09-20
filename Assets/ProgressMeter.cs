using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.SymphoSprint
{
    public class ProgressMeter : MonoBehaviour
    {

        [SerializeField]
        private Transform start;

        [SerializeField]
        private Transform finish;

        [SerializeField]
        private Transform player;

        [SerializeField]
        private Image progressFill;

        private void Update()
        {

            float f = player.position.x / (finish.position.x - start.position.x);

            progressFill.fillAmount = f;
        }
    }
}