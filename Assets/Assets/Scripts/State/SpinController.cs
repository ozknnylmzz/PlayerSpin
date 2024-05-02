using System.Threading.Tasks;
using DG.Tweening;
using Player.Data;
using Player.Enum;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI _spinBaseText;
        private SpinType _spinType=SpinType.Bronze;
        
        private void Play()
        {
            LockButtons(true);
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
                LockButtons(false);
                EventManager<PanelType>.Execute(UIEvents.OnOpenPanel, PanelType.FailedPanel);
                return;
            }

            DataManager.Instance.Inventory.AddReward(wheelInfo.Amount, wheelInfo.ItemIcon,wheelInfo.SpinType);

            Reward rewardItem = DataManager.Instance.Inventory.GetReward(wheelInfo.ItemIcon.name);
            EventManager<Reward>.Execute(UIEvents.OnEarnedReward, rewardItem);
            
            CheckSafeArea();
        }

        private async void CheckSafeArea()
        {
            await Task.Delay(_spinSettings.LockDelayTime);
            
            LockButtons(false);
            
            if (_spinType!=SpinType.Bronze)
            {
                _spinType = SpinType.Bronze;
                SetBaseText(_spinType);
                _spinState.ChangeState(_spinState.SpinBronzeState);
                return;
            }
            if (DataManager.Instance.CheckGoldenRoundData())
            {
                _spinType = SpinType.Golden;
                SetBaseText(_spinType);
                _spinState.ChangeState(_spinState.SpinGoldenState);
                return;
            }
            if (DataManager.Instance.CheckSilverRoundData())
            {
                _spinType = SpinType.Silver;
                SetBaseText(_spinType);
                _spinState.ChangeState(_spinState.SpinSilverState);
            }
        }

        private void LockButtons(bool isLock)
        {
            EventManager<bool>.Execute(UIEvents.OnLockExitButton, !isLock);
            _spinButton.interactable = !isLock;
        }

        private void SetBaseText(SpinType spinType)
        {
            _spinBaseText.text = spinType+ " Spin";
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