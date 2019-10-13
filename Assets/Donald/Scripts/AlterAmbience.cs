﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class AlterAmbience : MonoBehaviour
	{
		[SerializeField] private AudioSource audioSource;
		[SerializeField] private AudioClip newClip;

		private void OnTriggerEnter2D(Collider2D collision) {
			if(collision.CompareTag("Player")) {
				audioSource.Stop();
				audioSource.time = 0;
				audioSource.clip = newClip;
				audioSource.volume = 0.5f;
				audioSource.Play();
			}
		}
	}
}