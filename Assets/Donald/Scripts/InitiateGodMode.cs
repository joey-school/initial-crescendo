using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class InitiateGodMode : MonoBehaviour
	{
		[SerializeField] private GameObject GodBranch; 

		private void Awake() {
			GodBranch.SetActive(CheatManager.Instance.GodMode);
		}
	}
}

