using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class InitiateGodMode : MonoBehaviour
	{
		[SerializeField] private GameObject GodBranch; 

		private void Start() {
			GodBranch.SetActive(CheatManager.Instance.GodMode);
		}
	}
}

