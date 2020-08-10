using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSpriteOnHit : MonoBehaviour
{
	public List<GameObject> old;
	public List<GameObject> neww;

	public void ChangePlayerSprite() {
		old.ForEach((go) => go.SetActive(false));
		neww.ForEach((go) => go.SetActive(true));
	}
}
