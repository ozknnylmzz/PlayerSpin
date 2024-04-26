using System;
using Player.Enum;
using Player.Spin.State;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin
{
    public class SpinController : StateMachineBase
    {
        public SpinBronzeState SpinBronzeState { get; private set; }
        
        private void Awake()
        {
            SpinBronzeState = new SpinBronzeState(this);
        }

        private void Start()
        {
            
        }

        
    }
}

