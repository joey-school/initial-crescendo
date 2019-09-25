using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRhythm : MonoBehaviour
{
	[SerializeField] ClickToDrawLine linesBase;
	//[SerializeField] Vector3 positionFirstLine;
	[SerializeField] GameObject linePrefab;
	[SerializeField] Transform parent;
	[SerializeField] int desiredLineCount;

    // Start is called before the first frame update
    void Start()
    {
		float xDifference = (linesBase.LastPosition.x - linesBase.FirstPosition.x) / linesBase.ClickCount;
		for(int i = 0; i < desiredLineCount; i++) {
			Instantiate(linePrefab, Vector3.right * xDifference * i, Quaternion.identity, parent);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
