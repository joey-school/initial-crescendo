using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slides : MonoBehaviour
{
	public List<GameObject> ListSlidePanels;

	private GameObject currentSlide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ShowSlide(GameObject NewSlide) {
		NewSlide.SetActive(true);
		currentSlide.SetActive(false);
		currentSlide = NewSlide;
	}
}
