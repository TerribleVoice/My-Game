using System;
using Multiplayer;
using UnityEngine;

namespace Buildings
{
    public class Building : MonoBehaviour
    {
        [NonSerialized] public bool IsConflicted;
        [NonSerialized] public bool IsActive;
        private Renderer Renderer;
        protected Player Owner;
        private readonly Color acceptableColor;
        private readonly Color conflictedColor;

        public Building()
        {
            acceptableColor = new Color(0.34f, 0.74f, 0.32f, 0.84f);
            conflictedColor = new Color(0.75f, 0.31f, 0.38f, 0.84f);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Building>() != null)
            {
                IsConflicted = false;
                RenderAcceptable();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<Building>() != null)
            {
                IsConflicted = true;
                RenderConflicted();
            }
        }

        public void RenderAcceptable()
        {
            if (IsActive)
                Renderer.material.color = acceptableColor;
        }

        public void RenderConflicted()
        {
            if (IsActive)
                Renderer.material.color = conflictedColor;
        }

        public virtual void Place()
        {
            Owner = Local.Player;
            Owner.PlayerInfo.Buildings.Add(this);
            IsActive = false;
            Renderer.material.color = Color.white;
        }
    }

}
