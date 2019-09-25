using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDrawLine : MonoBehaviour
{
	[SerializeField] GameObject objectToSpawn;
	[SerializeField] Transform playerTransform;

	[SerializeField] Vector3 firstPosition = Vector3.back;
	[SerializeField] Vector3 lastPosition = Vector3.back;
	[SerializeField] int clickCount = 0;

	public Vector3 FirstPosition { get { return firstPosition; } }
	public Vector3 LastPosition { get { return lastPosition; } }
	public int ClickCount { get { return clickCount; } }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButtonDown(0)) {
			if(firstPosition == Vector3.back) {
				firstPosition = playerTransform.position;
				transform.position = firstPosition;
			}
			lastPosition = playerTransform.position;
			Instantiate(objectToSpawn, playerTransform.position, Quaternion.identity, transform);
			clickCount++;
		}
    }
}
