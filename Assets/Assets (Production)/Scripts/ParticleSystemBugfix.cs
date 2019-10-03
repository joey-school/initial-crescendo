using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class ParticleSystemBugfix : MonoBehaviour
    {

        private void Start()
        {
            // Bugfix: When we use sheet animation the 'play on awake' doesn't work.
            GetComponent<ParticleSystem>().Simulate(1);
            GetComponent<ParticleSystem>().Play();
        }
    }
}