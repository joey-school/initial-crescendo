using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class LockedLevel : MonoBehaviour
    {
        [SerializeField] private string levelName;
        [SerializeField] private Button button;
        [SerializeField] private GameObject lockedText;
        private int locked = 1;
        void Start()
        {
            if (PlayerPrefs.HasKey(levelName + "locked"))
            {
                locked = PlayerPrefs.GetInt(levelName + "locked");
            }

            if (locked == 0)
            {
                button.interactable = true;
                lockedText.SetActive(false);
            }
        }

        // If the level is locked, only then is needed to see if the cheat is enabled
        void Update()
        {
            if(locked == 1)
            {
                button.interactable = CheatManager.Instance.LevelsUnlocked;
                lockedText.SetActive(!CheatManager.Instance.LevelsUnlocked);
            }
        }
    }
}
