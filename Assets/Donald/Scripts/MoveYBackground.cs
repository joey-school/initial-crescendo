using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYBackground : MonoBehaviour
{
	[SerializeField] private Transform Player;
	[SerializeField] private float yRatio;
	[SerializeField] private GameObject anchorPoint;

    // Update is called once per frame
    void Update() {
		Vector2 distanceTimmyToAnchor = anchorPoint.transform.position - Player.position;
		float yPosition = anchorPoint.transform.position.y - yRatio * distanceTimmyToAnchor.y;
		transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
	}
}
