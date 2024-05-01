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
        private SpinItemData _spinItemData;


        public SilverSpinTypeStrategy(SpinBaseItemData spinBaseItemData,SpinItemData spinItemData)
        {
            _spinBaseItemData = spinBaseItemData;
            _spinItemData = spinItemData;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_spinBaseItemData.UISpinSilver.UiSpinSilverBase, _spinBaseItemData.UISpinSilver.UiSpinSilverIndicator);
        }

        public List<Sprite> GetWheelSpites()
        {
            return _spinItemData.GetSpritesByType(SpinType.Silver);
        }
    }
}

