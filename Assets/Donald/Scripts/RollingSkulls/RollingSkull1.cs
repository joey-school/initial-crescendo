using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSkull1 : MonoBehaviour
{
	public float RotationSpeed;
	public Transform StartPoint;
	public Transform EndPoint;
	public float RollingSpeed;

	private Vector3 speedPerFrame;

	private bool shouldRoll = false;

    // Start is called before the first frame update
    void Start()
    {
		speedPerFrame = (EndPoint.position - StartPoint.position);
		Debug.Log("speedperframe" + speedPerFrame);
    }

    // Update is called once per frame
    void Update()
    {
		if(shouldRoll) {
			transform.Rotate(Vector3.back, RotationSpeed);
			transform.position += speedPerFrame * Time.deltaTime * RollingSpeed;
		}
    }

	public void StartRolling() {
		shouldRoll = true;
		transform.position = StartPoint.position;
	}
}
