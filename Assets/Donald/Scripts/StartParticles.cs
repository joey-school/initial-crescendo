using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticles : MonoBehaviour
{
	[SerializeField] private ParticleSystem particleSystem;

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.tag == "Player") {
			particleSystem.Simulate(1);
			particleSystem.Play();
		}
	}
}
