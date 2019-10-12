using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxTransition : MonoBehaviour
{
	public List<GameObject> DestroyOnTrigger2D;
	public List<GameObject> GiantCoffinObjects;
	public int NextLayerGiantCoffin;

	private void OnTriggerEnter2D(Collider2D collision) {
		foreach(GameObject go in DestroyOnTrigger2D) {
			Destroy(go.gameObject);
		}
		foreach(GameObject go in GiantCoffinObjects) {
			go.GetComponent<Renderer>().sortingOrder = NextLayerGiantCoffin;
		}
	}
}
