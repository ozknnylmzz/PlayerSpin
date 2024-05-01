using System;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using Player.Spin.Strategy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player.Spin.Creator
{
    public class SpinCreator : MonoBehaviour
    {
        [SerializeField] private Image _spineBaseImage;
        [SerializeField] private Image _indicatorImage;

        [SerializeField] private SpinBaseItemData spinBaseItemData;
        [SerializeField] private SpinItemData _spinItemData;
        [SerializeField] private WheelData _wheelData;
       [SerializeField] private List<WheelItem> _wheelItems;

        private void Start()
        {
            SetWheelToStartSpin();
        }
        
        private void SetWheelToStartSpin()
        {
            for (int i = 0; i < _wheelItems.Count; i++)
            {
                if (CheckAvaibleWheelItem(_wheelData.WheelItems[i]))
                {
                    _wheelItems[i].SetWheelItemImage(_wheelData.WheelItems[i].ItemIcon);
                }
            }
        }

        private bool CheckAvaibleWheelItem(WheelSliceData wheelData)
        {
            if (_spinItemData.GetSpinTypeOfSprite(wheelData.ItemIcon)!=SpinType.Bronze)
            {
                return false;
            }
            
            return true;
        }

        public void CreateSpin(SpinType spinType)
        {
            ISpinTypeStrategy strategy = SpinTypeStrategyFactory.CreateStrategy(spinType, spinBaseItemData,_spinItemData);
            var (spinBaseImage, spinIndicatorImage) = strategy.GetBaseAndIndicatorSprites();
            _spineBaseImage.sprite = spinBaseImage;
            _indicatorImage.sprite = spinIndicatorImage;

            List<Sprite> wheelItems = strategy.GetWheelItems();
            
            wheelItems.Shuffle();

            for (int i = 0; i < _wheelItems.Count; i++)
            {
                _wheelItems[i].SetWheelItemImage(wheelItems[i]);
            }
        }
        
        private void OnEnable()
        {
            // EventManager<SpinType>.Subscribe(SpinEvents.OnState, CreateSpin);
        }

        private void OnDisable()
        {
            // EventManager<SpinType>.Unsubscribe(SpinEvents.OnState, CreateSpin);
        }
       
    }
}