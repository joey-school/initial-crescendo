using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{	public class MainMenuCanvas : MonoBehaviour
	{
		public void OnClickStartGame() {
			SoundManager.Instance.PlaySoundFX(Sounds.StartGame);
		}
	}
}
