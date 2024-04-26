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
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
