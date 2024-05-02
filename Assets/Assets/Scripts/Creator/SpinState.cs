using System;
using Player.Enum;
using Player.Spin.Creator;
using Player.Spin.State;
using UnityEngine;

namespace Player.Spin
{
    public class SpinState : StateMachineBase
    {
        public SpinSilverState SpinSilverState { get; private set; }
        public SpinBronzeState SpinBronzeState { get; private set; }
        public SpinGoldenState SpinGoldenState { get; private set; }

        [SerializeField] private SpinCreator _spinCreator;
        
        private void Awake()
        {
            SpinSilverState = new SpinSilverState(this,_spinCreator);
            SpinBronzeState = new SpinBronzeState(this,_spinCreator);
            SpinGoldenState = new SpinGoldenState(this,_spinCreator);
        }

        private void StartBronzeState()
        {
            ChangeState(SpinBronzeState);
        }
        private void OnEnable()
        {
            EventManager.Subscribe(SpinType.Bronze,StartBronzeState);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(SpinType.Bronze,StartBronzeState);
        }
    }
}

