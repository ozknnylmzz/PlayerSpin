using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public class SilverSpinTypeStrategy : ISpinTypeStrategy
    {
        private SpinBaseItemData _spinBaseItemData;
        private Data.SpinItemData _spinItemData;


        public SilverSpinTypeStrategy(SpinBaseItemData spinBaseItemData,Data.SpinItemData spinItemData)
        {
            _spinBaseItemData = spinBaseItemData;
            _spinItemData = spinItemData;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_spinBaseItemData.UISpinSilver.UiSpinSilverBase, _spinBaseItemData.UISpinSilver.UiSpinSilverIndicator);
        }

        public List<Sprite> GetWheelItems()
        {
            return _spinItemData.GetSpritesByType(SpinType.Silver);
        }
    }
}

