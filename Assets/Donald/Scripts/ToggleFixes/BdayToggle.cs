using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
	public class BdayToggle : MonoBehaviour
	{
		private void Awake() {
			GetComponent<Toggle>().isOn = CheatManager.Instance.Bday;
			GetComponent<Toggle>().onValueChanged.AddListener((boolean) => CheatManager.Instance.Bday = boolean);
		}
	}
}
