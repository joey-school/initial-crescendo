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

        public bool IsUnlocked { get; private set; }

        public void Unlock()
        {
            IsUnlocked = true;

            Activate();
            unlockParticles.Simulate(1);
            unlockParticles.Play();
            unlockParticles.Stop();
            unlockParticles.Emit(100);
            SoundManager.Instance.PlaySoundFX(Sounds.UnlockCheckpoint);
            Camera.main.DOShakeRotation(1f, 8);
        }

        public void Activate()
        {
            sprite.sprite = unlockedSprite;
        }
    }
}