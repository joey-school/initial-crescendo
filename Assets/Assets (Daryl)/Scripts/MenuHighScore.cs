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
        private string levelName;

        // Start is called before the first frame update
        void Start()
        {
            txt.text = "High Score: 0/0";
            if (PlayerPrefs.HasKey(levelName + "score"))
            {
                txt.text = "High Score: " 
                    + PlayerPrefs.GetInt(levelName + "score") 
                    + "/"
                    + PlayerPrefs.GetInt(levelName + "totalObjects");
            }
        }
    }
}
