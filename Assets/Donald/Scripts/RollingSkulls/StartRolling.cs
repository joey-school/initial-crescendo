using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRolling : MonoBehaviour
{
	public GameObject RollingSkull;

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Player") {
			Debug.Log("start rolling by player colision");
			RollingSkull.GetComponent<RollingSkull1>().StartRolling();
			Destroy(GetComponent<BoxCollider2D>());
		}
	}
}
