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

        public Transform Start
        {
            get
            {
                return start;
            }
        }

        [SerializeField]
        private Transform finish;

        public Transform Finish
        {
            get
            {
                return finish;
            }
        }

        [SerializeField]
        private Transform player;

        [SerializeField]
        private Image progressFill;

        [SerializeField]
        private GameObject checkPointMarkerPrefab;

        [SerializeField]
        private Transform checkpointMarkerContainer;

        private void Update()
        {
            float f = player.position.x / (finish.position.x - start.position.x);

            progressFill.fillAmount = f;
        }

        public void PlaceCheckpointMarker(float percentage)
        {
            GameObject checkpointMarker = Instantiate(checkPointMarkerPrefab, checkpointMarkerContainer, false);

            float destinationXPosition = percentage * checkpointMarkerContainer.GetComponent<RectTransform>().sizeDelta.x;

            checkpointMarker.GetComponent<RectTransform>().anchoredPosition = new Vector2(destinationXPosition, 0f);
        }  
    }
}