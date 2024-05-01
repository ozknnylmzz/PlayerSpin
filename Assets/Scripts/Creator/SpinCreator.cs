using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using Player.Spin.Strategy;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin.Creator
{
    public class SpinCreator : MonoBehaviour
    {
        [SerializeField] private Image _spineBaseImage;
        [SerializeField] private Image _indicatorImage;

        [SerializeField] private SpinBaseItemData spinBaseItemData;
        [SerializeField] private SpinItemData _spinItemData;
        [SerializeField] private List<WheelItem> _wheelItems;

        private void Start()
        {
            SetWheelToStartSpin();
        }

        private void SetWheelToStartSpin()
        {
            for (int i = 0; i < _wheelItems.Count; i++)
            {
                if (CheckAvaibleWheelItem(DataManager.Instance.WheelData.WheelItems[i]))
                {
                    _wheelItems[i].SetWheelItemImage(DataManager.Instance.WheelData.WheelItems[i].ItemIcon);
                }
            }
        }

        private bool CheckAvaibleWheelItem(WheelSliceData wheelData)
        {
            if (_spinItemData.GetSpinTypeOfSprite(wheelData.ItemIcon) != SpinType.Bronze)
            {
                return false;
            }

            return true;
        }

        public void CreateSpin(SpinType spinType)
        {
            ISpinTypeStrategy strategy =
                SpinTypeStrategyFactory.CreateStrategy(spinType, spinBaseItemData, _spinItemData);
            var (spinBaseImage, spinIndicatorImage) = strategy.GetBaseAndIndicatorSprites();
            _spineBaseImage.sprite = spinBaseImage;
            _indicatorImage.sprite = spinIndicatorImage;
            
            UpdateWheelData(strategy);
        }

        private void UpdateWheelData(ISpinTypeStrategy strategy)
        {
            List<Sprite> wheelItems = strategy.GetWheelSpites();
            // List<int> wheelAmounts= strategy.GetWheelAmount();
            wheelItems.Shuffle();

            for (int i = 0; i < _wheelItems.Count; i++)
            {
                _wheelItems[i].SetWheelItemImage(wheelItems[i]);
                DataManager.Instance.WheelData.WheelItems[i].ItemIcon = wheelItems[i];
                // DataManager.Instance.WheelData.WheelItems[i].Amount = wheelAmounts[i];
            }
        }
    }
}