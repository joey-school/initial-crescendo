using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
    public class CheatManager : MonoBehaviour
    {

        public static CheatManager Instance { get; private set; }
        public bool LevelsUnlocked { get; set; }
		public bool GodMode { get; set; }
		public bool Bday { get; set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

		private void Update() {
			Debug.Log(GodMode);
		}
	}
}
