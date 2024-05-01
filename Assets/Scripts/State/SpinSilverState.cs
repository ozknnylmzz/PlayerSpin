using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using Player.Spin.Creator;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinSilverState : IState
    {
        private SpinController _spinController;
        private SpinCreator _spinCreator;
        private SpinType _spinType = SpinType.Silver;
        
        public SpinSilverState(SpinController spinController,SpinCreator spinCreator)
        {
            _spinController = spinController;
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