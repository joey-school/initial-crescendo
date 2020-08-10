using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSpriteOnHit : MonoBehaviour
{
	public List<GameObject> old;
	public List<GameObject> neww;
	public float scaleSpeed = 1;
	public float scaleFactor = 2;

	private Vector3 initialScale;

	private void Start() {
		initialScale = transform.localScale;
	}

	public void ChangePlayerSprite() {
		old.ForEach((go) => go.SetActive(false));
		neww.ForEach((go) => go.SetActive(true));
		StartCoroutine(DissappearByGrowing());
		//gameObject.SetActive(false);
	}

	private IEnumerator DissappearByGrowing() {
		float progress = 0;
		while(progress < 100) {
			progress += Time.deltaTime * 100 * scaleSpeed;
			if(progress > 100) progress = 100;
			transform.localScale = initialScale + initialScale * scaleFactor * progress / 100;
			yield return new WaitForEndOfFrame();
		}
	}
}
