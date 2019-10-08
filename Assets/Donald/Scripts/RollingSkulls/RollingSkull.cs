using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSkull : MonoBehaviour
{
	public GameObject rollingSkull;
	public float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
		rollingSkull.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player") {
			Debug.Log("rolling skull active yo");
			rollingSkull.SetActive(true);
		}
	}
}
