using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	[SerializeField] private Transform Player;
	[SerializeField] private float xRatio;
	[SerializeField] private float yRatio;
	[SerializeField] private GameObject anchorPoint;

    void Update()
    {
		Vector2 distanceTimmyToAnchor = anchorPoint.transform.position - Player.position;
		float xPosition = anchorPoint.transform.position.x - xRatio * distanceTimmyToAnchor.x;
		float yPosition = anchorPoint.transform.position.y - yRatio * distanceTimmyToAnchor.y;
		transform.position = new Vector3(xPosition, yPosition, transform.position.z);
    }
}
