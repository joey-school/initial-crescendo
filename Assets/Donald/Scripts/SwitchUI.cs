using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUI : MonoBehaviour
{
    public GameObject[] UIToSwitchOff;
    public GameObject StartUI;

    private GameObject currentUI;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject UIGameObject in UIToSwitchOff)
        {
            UIGameObject.SetActive(false);
        }
        currentUI = StartUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNewUI(GameObject newUI)
    {
        currentUI.SetActive(false);
        newUI.SetActive(true);
        currentUI = newUI;
    }
}
