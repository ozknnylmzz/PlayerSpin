using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using Player.Spin.Creator;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinBronzeState :IState
    {
        private SpinState _spinState;
        private SpinCreator _spinCreator;

        private SpinType _spinType = SpinType.Bronze;
        public SpinBronzeState(SpinState spinState,SpinCreator spinCreator)
        {
            _spinState = spinState;
            _spinCreator = spinCreator;
        }

        public void Enter()
        {
            _spinCreator.CreateSpin(_spinType);
            Debug.Log("bronze state enter");
        }

        public void Exit()
        {
            Debug.Log("bronze state enter");

        }
    }
}

