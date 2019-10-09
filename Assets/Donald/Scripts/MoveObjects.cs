using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
	[SerializeField] private List<GameObject> objectList;
	[SerializeField] private Vector3 transformation;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in objectList) {
			go.transform.position += transformation;
		}
    }
}
