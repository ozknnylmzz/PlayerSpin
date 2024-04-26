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

        [SerializeField] private SpinCreatorData _spinCreatorData;
        [SerializeField] private InventoryData _inventoryData;

        [FormerlySerializedAs("_spinInventoryData")] [SerializeField] private WheelData wheelData;
        [FormerlySerializedAs("_spinItems")] [SerializeField] private List<WheelItem> _wheelItems;

        private void Start()
        {
            CreateToStartSpin();
        }
        
        private void CreateToStartSpin()
        {
            for (int i = 0; i < _wheelItems.Count; i++)
            {
                _wheelItems[i].SetWheelItemImage(wheelData.items[i].ItemIcon);
            }
        }

        private void CreateSpin(SpinType spinType)
        {
            ISpinTypeStrategy strategy = SpinTypeStrategyFactory.CreateStrategy(spinType, _spinCreatorData,_inventoryData);
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
            EventManager<SpinType>.Subscribe(SpinEvents.OnState, CreateSpin);
        }

        private void OnDisable()
        {
            EventManager<SpinType>.Unsubscribe(SpinEvents.OnState, CreateSpin);
        }
       
    }
}