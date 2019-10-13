using Crescendo.InitialCrescendo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsToggle : MonoBehaviour
{

	private void Awake() {
		GetComponent<Toggle>().isOn = CheatManager.Instance.LevelsUnlocked;
		GetComponent<Toggle>().onValueChanged.AddListener((boolean) => CheatManager.Instance.LevelsUnlocked = boolean);
	}
}
