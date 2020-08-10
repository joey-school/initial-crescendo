using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager Instance { get; private set; }

	public string MainMenuName;
	public string Level1Name;
	public string Level2Name;
	public string Level3Name;
	public string LevelIndianaJonesName;

	private void Awake() {
		if(Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public string GetLevelNameFromLevelNumber(int level_zeroIsMainMenu) {
		if(level_zeroIsMainMenu == 0) return MainMenuName;
		if(level_zeroIsMainMenu == 1) return Level1Name;
		if(level_zeroIsMainMenu == 2) return Level2Name;
		if(level_zeroIsMainMenu == 3) return Level3Name;
		if(level_zeroIsMainMenu == 4) return LevelIndianaJonesName;
		else return MainMenuName;
	}
}
