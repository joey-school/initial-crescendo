using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICheckpointManager
{
	void ChangeCurrentSpawnPoint(int checkpointNumber);
	GameObject GetCurrentCheckpoint();
}
