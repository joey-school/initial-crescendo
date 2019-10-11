using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class MenuHighScore : MonoBehaviour
    {
        [SerializeField]
        private Text txt;
        [SerializeField]
        private int levelNumber;

        // Start is called before the first frame update
        void Start()
        {
            txt.text = "High Score: 0/0";
            if (PlayerPrefs.HasKey(LevelManager.Instance.GetLevelNameFromLevelNumber(levelNumber) + "score"))
            {
                txt.text = "High Score: " + PlayerPrefs.GetInt(LevelManager.Instance.GetLevelNameFromLevelNumber(levelNumber) + "score");
            }
        }
    }
}
