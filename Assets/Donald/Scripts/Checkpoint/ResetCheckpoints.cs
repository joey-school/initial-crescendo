using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCheckpoints : MonoBehaviour
{
	[SerializeField] string playerPrefsNameCheckpLvl1;

    // Start is called before the first frame update
    void Start()
    {
		PlayerPrefs.SetInt(playerPrefsNameCheckpLvl1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
