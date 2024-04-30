using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinIdleState : IState
    {
        private SpinController _spinController;
        public SpinIdleState(SpinController spinController)
        {
            _spinController = spinController;
        }
        public void Enter()
        {
            Debug.Log("STATE CHANGE - Idle Enter");
        }

        public void Exit()
        {
            Debug.Log("STATE CHANGE - Idle Exit");
        }
    } 
}


