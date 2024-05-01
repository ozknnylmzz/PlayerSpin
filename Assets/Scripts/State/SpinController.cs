using System.Threading.Tasks;
using DG.Tweening;
using Player.Data;
using Player.Enum;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Player.Spin.State
{
    public class SpinController :MonoBehaviour
    {
        [SerializeField]  private SpinState _spinState;
        [SerializeField] private SpinSettings _spinSettings;
        [SerializeField] private RectTransform _spinObject;
        [SerializeField] private Button _spinButton;

        private SpinType _spinType=SpinType.Bronze;
        
        private void Play()
        {
            LockButton(true);
            DataManager.Instance.IncreaseRound();
            EventManager.Execute(UIEvents.OnPlaySpin);
            
            Tween spinTween = PlaySpin();
            
            spinTween.OnComplete(
                () =>
                {
                    ResultSpin(_spinObject.localEulerAngles.z);
                });
        }
        
        private Tween PlaySpin()
        {
            Sequence sequence = DOTween.Sequence();
            
            float totalAnglePerSection = _spinSettings.RewardAngle + _spinSettings.GapAngle;

            int numberOfSpins = Random.Range(_spinSettings.MinSpins, _spinSettings.MaxSpins);

            int randomSectionIndex = Random.Range(0, (int)(360 / totalAnglePerSection));
           
            float  targetAngle = numberOfSpins * 360f + randomSectionIndex * totalAnglePerSection + _spinSettings.RewardAngle / 2f;

            targetAngle = -targetAngle+Random.Range(0,_spinSettings.RewardAngle);
            
            sequence.Append(_spinObject.DORotate(new Vector3(0, 0, targetAngle), _spinSettings.SpinTime, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCubic));
           
            return sequence;
        }

        private void ResultSpin(float spinRotate)
        {

            WheelSliceData wheelInfo = DataManager.Instance.WheelData.FindWheelSliceByAngle(spinRotate);

            if (wheelInfo.CheckGrenadeItem())
            {
                LockButton(false);
                EventManager<PanelType>.Execute(UIEvents.OnOpenPanel, PanelType.FailedPanel);
                return;
            }

            DataManager.Instance.Inventory.AddReward(wheelInfo.Amount, wheelInfo.ItemIcon);

            Reward rewardItem = DataManager.Instance.Inventory.GetReward(wheelInfo.ItemIcon.name);
            EventManager<Reward>.Execute(UIEvents.OnEarnedReward, rewardItem);
            
            CheckSafeArea();
        }

        private async void CheckSafeArea()
        {
            await Task.Delay(_spinSettings.LockDelayTime);
            
            LockButton(false);
            
            if (_spinType!=SpinType.Bronze)
            {
                _spinState.ChangeState(_spinState.SpinBronzeState);
                return;
            }

            _spinButton.interactable = true;
            if (DataManager.Instance.CheckSilverRoundData())
            {
                _spinType = SpinType.Silver;
                _spinState.ChangeState(_spinState.SpinSilverState);
                return;
            }

            if (DataManager.Instance.CheckGoldenRoundData())
            {
                _spinType = SpinType.Golden;
                _spinState.ChangeState(_spinState.SpinGoldenState);
            }
        }

        private void LockButton(bool isLock)
        {
            _spinButton.interactable = !isLock;
        }

        private void OnEnable()
        {
            _spinButton.onClick.AddListener(Play);
        }

        private void OnDisable()
        {
            _spinButton.onClick.RemoveListener(Play);
        }
    }
}