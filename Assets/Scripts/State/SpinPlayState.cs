using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player.Data;
using Player.Enum;
using TMPro;
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

        public SpinPlayState(SpinController spinController, Spin spin, Button spinButton, WheelData wheelData)
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
            Tween spinTween = _spin.PlaySpin();
            EventManager.Execute(UIEvents.OnPlaySpin);
            spinTween.OnComplete(
                () =>
                {
                    ResultSpin(_spin.SpinObject.localEulerAngles.z);
                });
        }

        public void Exit()
        {
            _spinButton.interactable = true;
        }

        private void ResultSpin(float spinRotate)
        {
            WheelSliceData wheelInfo = _wheelData.FindWheelSliceByAngle(spinRotate);

            if (wheelInfo.CheckGrenadeItem())
            {
                EventManager<PanelType>.Execute(UIEvents.OnOpenPanel, PanelType.FailedPanel);
                return;
            }

            DataManager.Instance.Inventory.AddReward(wheelInfo.Amount, wheelInfo.ItemIcon);

            Reward rewardItem = DataManager.Instance.Inventory.GetReward(wheelInfo.ItemIcon.name);
            EventManager<Reward>.Execute(UIEvents.OnEarnedReward, rewardItem);
            
            CheckSafeArea();
        }

        private void CheckSafeArea()
        {
            Debug.Log("current round"+DataManager.Instance.CurrentRound);
            if (DataManager.Instance.CheckSilverRoundData())
            {
                _spinController.ChangeState(_spinController.SpinSilverState);
                return;
            }

            if (DataManager.Instance.CheckGoldenRoundData())
            {
                _spinController.ChangeState(_spinController.SpinGoldenState);
                return;
            }
            
            _spinController.ChangeState(_spinController.SpinBronzeState);
        }
    }
}