using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class Setup : MonoBehaviour
    {
    
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}