using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamDrag : MonoBehaviour
{
    public float HorizontalSpeed;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeScale = Player.GetComponent<PlayerTime>().TimeScale;
        transform.position += new Vector3(HorizontalSpeed * timeScale, 0, 0);
    }
}
