using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crescendo.InitialCrescendo
{
	public class MenuCanvas : MonoBehaviour
	{
		public void OnClickPauseButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.Pause);
			SoundManager.Instance.PauseSong(false);
		}
		public void OnClickResumeButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.Resume);
			SoundManager.Instance.UnpauseSong();
		}
		public void OnClickRestartButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.Restart);
		}
		public void OnClickQuitButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.QuitLevel);
		}

		//When dead
		public void OnClickDeadQuitButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.DeadQuitLevel);
		}
		public void OnClickDeadRestartButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.DeadRestart);
		}

		//When level completed
		public void OnClickEndLevelQuitButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.EndLevelQuitLevel);
		}
		public void OnClickEndLevelRestartButton() {
			SoundManager.Instance.PlaySoundFX(Sounds.EndLevelRestart);
		}
	}
}
