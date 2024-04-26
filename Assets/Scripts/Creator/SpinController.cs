using System;
using Player.Enum;
using Player.Spin.State;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin
{
    public class SpinController : StateMachineBase
    {
        public SpinSilverState SpinSilverState { get; private set; }
        public SpinBronzeState SpinBronzeState { get; private set; }
        public SpinGoldenState SpinGoldenState { get; private set; }
        public SpinPlayState SpinPlayState { get; private set; }


        [SerializeField] private Spin _spin;
        [SerializeField] private Button _spinButton;
        
        
        private void Awake()
        {
            SpinSilverState = new SpinSilverState(this);
            SpinBronzeState = new SpinBronzeState(this);
            SpinGoldenState = new SpinGoldenState(this);
            SpinPlayState = new SpinPlayState(this, _spin,_spinButton);
        }

        private void OnEnable()
        {
            _spinButton.onClick.AddListener(PlaySpinState);
        }

        private void OnDisable()
        {
            _spinButton.onClick.RemoveListener(PlaySpinState);
        }

        private void PlaySpinState()
        {
            ChangeState(SpinPlayState);
        }
        
        
    }
}

