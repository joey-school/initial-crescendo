using System.Collections;
using System.Collections.Generic;
using Crescendo.InitialCrescendo;
using UnityEngine;

namespace Crescendo.SymphoSprint
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerSpawnPoint : MonoBehaviour
    {

        [SerializeField]
        private Sprite enabledSprite;

        private SpriteRenderer spriteRenderer;
        private new Collider2D collider;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            collider = GetComponent<Collider2D>();
        }

        public void Activate()
        {
            spriteRenderer.sprite = enabledSprite;
            collider.enabled = false;
        }
    }
}