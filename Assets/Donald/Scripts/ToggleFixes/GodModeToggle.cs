using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
	public class GodModeToggle : MonoBehaviour
	{
		private void Awake() {
			GetComponent<Toggle>().isOn = CheatManager.Instance.GodMode;
			GetComponent<Toggle>().onValueChanged.AddListener((boolean) => CheatManager.Instance.GodMode = boolean);
		}
	}
}
