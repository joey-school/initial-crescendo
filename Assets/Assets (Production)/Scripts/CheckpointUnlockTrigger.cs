using System.Collections;
using System.Collections.Generic;
using Crescendo.SymphoSprint;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class CheckpointUnlockTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                //Debug.Log("Unlock checkpoint!", this);

                // TODO: Make CheckpointManagerLvl1 a singleton.
                //GameObject.Find("CheckPointManager").GetComponent<CheckpointManagerLvl1>().UnlockCheckpoint(transform.parent.GetSiblingIndex());
            }
        }
    }
}