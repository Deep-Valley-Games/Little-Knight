using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Root.Scripts.Signals
{
    public class MovementSignals : MonoBehaviour
    {
        public static MovementSignals Instance;

        public UnityAction<bool> OnAir = delegate { };
        public UnityAction OnUnableToMove = delegate { };

        private void Awake()
        {
            if (Instance != this && Instance != null) 
            {
                Destroy(this);
                return;
            }

            Instance = this;
            
        }
    }
    
}