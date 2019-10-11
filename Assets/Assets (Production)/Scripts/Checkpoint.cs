using System.Collections;
using System.Collections.Generic;
using Crescendo.InitialCrescendo;
using DG.Tweening;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    public class Checkpoint : MonoBehaviour
    {

        [SerializeField]
        private SpriteRenderer sprite;

        [SerializeField]
        private Sprite unlockedSprite;

        [SerializeField]
        private ParticleSystem unlockParticles;

        [SerializeField]
        private bool isUsedInDebugging;

        public bool IsUsedInDebugging
        {
            get
            {
                return isUsedInDebugging;
            }
        }

        public bool IsUnlocked { get; private set; }

        private void Awake()
        {
            CheckpointManagerLvl1 checkpointManager = GameObject.Find("CheckPointManager").GetComponent<CheckpointManagerLvl1>();

            if (isUsedInDebugging && !checkpointManager.IsDebugging)
            {
                Destroy(gameObject);
            }
            //else
            //{
            //    gameObject.SetActive(false);
            //}
        }

        public void Unlock()
        {
            IsUnlocked = true;

            Activate();
            unlockParticles.Simulate(1);
            unlockParticles.Play();
            unlockParticles.Stop();
            unlockParticles.Emit(130);
            SoundManager.Instance.PlaySoundFX(Sounds.UnlockCheckpoint);
            Camera.main.DOShakeRotation(1.5f, 8);
        }

        public void Activate()
        {
            sprite.sprite = unlockedSprite;
        }
    }
}