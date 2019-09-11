using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ParallaxBackgroundLayer : MonoBehaviour
    {
        [SerializeField]
        [Range(-10, 10)]
        private float scrollPower = 2f;

        private Vector3 defaultPosition;
        private float spriteWidth;
        private int amountOfExistLeftOfScreen = 0;

        private float previousCameraXPosition;

        private void Awake()
        {
            defaultPosition = transform.position;
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;

            previousCameraXPosition = Camera.main.transform.position.x;
        }

        private void LateUpdate()
        {
            float targetXPosition = defaultPosition.x + (amountOfExistLeftOfScreen * spriteWidth * 2f) + (Camera.main.transform.position.x / scrollPower);
            float targetYPosition = defaultPosition.y + (Camera.main.transform.position.y / scrollPower);

            float diff = Camera.main.transform.position.x - previousCameraXPosition;

            transform.position = new Vector3(targetXPosition, targetYPosition, transform.position.z);

            if (transform.position.x <= (Camera.main.transform.position.x - spriteWidth))
            {
                amountOfExistLeftOfScreen++;
            }

            previousCameraXPosition = Camera.main.transform.position.x;
        }
    }
}