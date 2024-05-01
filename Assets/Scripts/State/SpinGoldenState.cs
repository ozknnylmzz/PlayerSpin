using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinGoldenState : IState
    {
        private SpinController _spinController;

        private SpinType _spinType = SpinType.Bronze;
        
        public SpinGoldenState(SpinController spinController)
        {
            _spinController = spinController;
        }
        public void Enter()
        {
            Debug.Log("golden state enter");
        }

        public void Exit()
        {
            Debug.Log("golden state exit");

        }
    }
}
