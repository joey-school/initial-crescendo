using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineByButton : MonoBehaviour
{
	public Transform playerTransform;
	public GameObject objectToSpawn;

    public void GenerateLine() {
		Instantiate(objectToSpawn, playerTransform.position, Quaternion.identity, transform);
	}
}
