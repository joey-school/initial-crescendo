using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfScreen : MonoBehaviour
{
	private void OnBecameInvisible() {
		Debug.Log("bacame invissible");
		Destroy(gameObject);
	}
}
