using System;
using System.Collections.Generic;
using Player.Enum;
using Player.Extensions;
using Player.Spin.Strategy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin.Creator
{
    public class SpinCreator : MonoBehaviour
    {
        [SerializeField] private Image _spineBaseImage;
        [SerializeField] private Image _indicatorImage;

        [SerializeField] private SpinCreatorData _spinCreatorData;

        [SerializeField] private List<SpinItem> _spinItems;

        private void OnEnable()
        {
            EventManager<SpinType>.Subscribe(SpinEvents.OnState, CreateSpin);
        }

        private void OnDisable()
        {
            EventManager<SpinType>.Unsubscribe(SpinEvents.OnState, CreateSpin);
        }

        private void CreateSpin(SpinType spinType)
        {
            ISpinTypeStrategy strategy = SpinTypeStrategyFactory.CreateStrategy(spinType, _spinCreatorData);
            var (spinBaseImage, spinIndicatorImage) = strategy.GetBaseAndIndicatorSprites();
            _spineBaseImage.sprite = spinBaseImage;
            _indicatorImage.sprite = spinIndicatorImage;

            Sprite[] spinTypeItems = strategy.GetSpinTypeItems();
            spinTypeItems.Shuffle();

            for (int i = 0; i < _spinItems.Count; i++)
            {
                _spinItems[i].SpinItemImage.sprite = spinTypeItems[i];
            }
        }
    }
}