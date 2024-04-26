using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spin.State
{
    public abstract class StateMachineBase : MonoBehaviour
    {
        public IState CurrentState { get; private set; }
        
        public void ChangeState(IState newState)
        {
            if (CurrentState == newState || CurrentState == null)
                return;
            
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}

