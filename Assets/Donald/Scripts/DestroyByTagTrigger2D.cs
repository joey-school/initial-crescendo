using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class DestroyByTagTrigger2D : MonoBehaviour
	{
		[SerializeField] private string tag;
		[SerializeField] private Transform player;

		private void OnTriggerEnter2D(Collider2D collision) {
			if(collision.tag == tag) {
				player.GetComponent<End_Controller>().TimmyDie();
				Destroy(gameObject);
			}
		}
	}
}

