using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepYX : MonoBehaviour
{
	public bool keepY;
	public bool keepX;

	private float y;
	private float x;

	private void Start() {
		y = transform.position.y;
		x = transform.position.x;
	}

	// Update is called once per frame
	void Update() {
	}

	private void FixedUpdate() {
		if(keepY) {
			transform.position = new Vector3(transform.position.x, y, transform.position.z);
		}
		if(keepX) {
			transform.position = new Vector3(x, transform.position.y, transform.position.z);
		}
	}
}
