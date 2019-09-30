using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUIController : MonoBehaviour
{
	[SerializeField] private GameObject checkpointPanel;

	public void ShowCheckPointPanel() {
		checkpointPanel.SetActive(true);
		//Time.timeScale = 0;
	}

	public void HideCheckPointPanel() {
		checkpointPanel.SetActive(false);
		//Time.timeScale = 1.0f;
	}
}
