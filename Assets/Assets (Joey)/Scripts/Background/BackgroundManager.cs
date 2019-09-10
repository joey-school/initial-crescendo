using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class BackgroundManager : MonoBehaviour
    {
        private void Awake()
        {
            ExtendBackgroundLayers();
        }

        private void ExtendBackgroundLayers()
        {
            foreach (Transform backgroundLayer in transform.Cast<Transform>().ToArray())
            {
                float width = backgroundLayer.GetComponent<SpriteRenderer>().bounds.size.x;
                GameObject newBackroundLayer = Instantiate(backgroundLayer.gameObject, backgroundLayer.position + (Vector3.right * width), Quaternion.identity, transform);

                // TODO: Remove when we have final images!
                newBackroundLayer.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}