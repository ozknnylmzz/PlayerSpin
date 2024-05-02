using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using Player.Spin.Creator;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinSilverState : IState
    {
        private SpinState _spinState;
        private SpinCreator _spinCreator;
        private SpinType _spinType = SpinType.Silver;
        
        public SpinSilverState(SpinState spinState,SpinCreator spinCreator)
        {
            _spinState = spinState;
            _spinCreator = spinCreator;
        }

        public void Enter()
        {
            Debug.Log("silver state enter");
            _spinCreator.CreateSpin(_spinType);
        }

        public void Exit()
        {
            Debug.Log("silver state exit");
        }
    }
}