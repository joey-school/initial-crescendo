using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSkull : MonoBehaviour
{
	public GameObject rollingSkull;

    void Start()
    {
		rollingSkull.SetActive(false);
    }

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.tag == "Player") {
			Debug.Log("rolling skull active yo");
			rollingSkull.SetActive(true);
		}
	}
}
