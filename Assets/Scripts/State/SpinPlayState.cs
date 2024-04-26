using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin.State
{
    public class SpinPlayState : IState
    {
        private SpinController _spinController;
        private Spin _spin;
        private Button _spinButton;
        private WheelData _wheelData;
        public SpinPlayState(SpinController spinController,Spin spin,Button spinButton,WheelData wheelData)
        {
            _spinController = spinController;
            _spin = spin;
            _spinButton = spinButton;
            _wheelData = wheelData;
        }
        
        public void Enter()
        {
            _spinButton.interactable = false;
            DataManager.Instance.IncreaseRound();
            _spin.PlaySpin(out var targetAngle).OnComplete(()=>CheckSafeArea());
           WheelSlice wheelInfo= _wheelData.FindWheelSliceByAngle(targetAngle);
        }

        public void Exit()
        {
            _spinButton.interactable = true;
        }

        private void CheckSafeArea()
        {
            if (DataManager.Instance.CheckBronzeRoundData())
            { 
                _spinController.ChangeState(_spinController.SpinBronzeState);
            }

            if (DataManager.Instance.CheckGoldenRoundData())
            {
                _spinController.ChangeState(_spinController.SpinGoldenState);
            }
        }
    }
}