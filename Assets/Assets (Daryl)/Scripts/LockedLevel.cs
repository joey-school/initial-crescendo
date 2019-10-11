using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crescendo.InitialCrescendo
{
    public class LockedLevel : MonoBehaviour
    {
        [SerializeField] private string previousLevelName;
        [SerializeField] private Button button;
        [SerializeField] private GameObject lockedGraphic;
        private int finishedPrevious = 0;
        void Start()
        {
            if (PlayerPrefs.HasKey(previousLevelName + "finished"))
            {
                finishedPrevious = PlayerPrefs.GetInt(previousLevelName + "finished");
            }

            if (finishedPrevious == 1)
            {
                button.interactable = true;
                lockedGraphic.SetActive(false);
            }
        }

        // If the level is locked, only then is needed to see if the cheat is enabled
        void Update()
        {
            if(finishedPrevious == 0)
            {
                button.interactable = CheatManager.Instance.LevelsUnlocked;
                lockedGraphic.SetActive(!CheatManager.Instance.LevelsUnlocked);
            }
        }
    }
}
