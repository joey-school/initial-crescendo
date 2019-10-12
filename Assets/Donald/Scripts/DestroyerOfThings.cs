using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerOfThings : MonoBehaviour
{
	public List<GameObject> DestroyOnTrigger2D;

	private void OnTriggerEnter2D(Collider2D collision) {
		foreach(GameObject go in DestroyOnTrigger2D) {
			Destroy(go.gameObject);
		}
	}
}
