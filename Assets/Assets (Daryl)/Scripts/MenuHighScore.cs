using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHighScore : MonoBehaviour
{
    [SerializeField]
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "High Score: 0/0";
        if(PlayerPrefs.HasKey("Score"))
        {
            txt.text = "High Score: " + PlayerPrefs.GetInt("Score");
        }
    }
}
