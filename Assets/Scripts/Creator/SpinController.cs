using System;
using Player.Data;
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
        public SpinIdleState SpinIdleState { get; private set; }

        [SerializeField] private Spin _spin;
        [SerializeField] private Button _spinButton;
        [SerializeField] private WheelData _wheelData;
        
        private void Awake()
        {
            SpinSilverState = new SpinSilverState(this);
            SpinBronzeState = new SpinBronzeState(this);
            SpinGoldenState = new SpinGoldenState(this);
            SpinIdleState = new SpinIdleState(this);
            SpinPlayState = new SpinPlayState(this, _spin,_spinButton,_wheelData);
        }

        private void Start()
        {
            ChangeState(SpinIdleState);
        }

        private void OnEnable()
        {
            _spinButton.onClick.AddListener(PlaySpinState);
            EventManager.Subscribe(SpinStateType.OnIdleState,SetIdleSpinState);
        }

        private void OnDisable()
        {
            _spinButton.onClick.RemoveListener(PlaySpinState);
            EventManager.Unsubscribe(SpinStateType.OnIdleState,SetIdleSpinState);
        }

        private void PlaySpinState()
        {
            ChangeState(SpinPlayState);
        }
        
        private void SetIdleSpinState()
        {
            ChangeState(SpinIdleState);
        }
        
    }
}

