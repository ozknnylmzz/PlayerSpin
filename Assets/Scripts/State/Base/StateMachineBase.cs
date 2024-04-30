using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spin.State
{
    public abstract class StateMachineBase : MonoBehaviour
    {
        public IState CurrentState { get; private set; }
        public IState _previousState;

        public void ChangeState(IState newState)
        {
            if (CurrentState == newState )
                return;
            
            if (CurrentState != null)
                CurrentState.Exit();
            
            if (_previousState != null)
                _previousState = CurrentState;
            
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}

