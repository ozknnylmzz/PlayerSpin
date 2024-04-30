using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public class BronzeSpinTypeStrategy : ISpinTypeStrategy
    {
        private SpinBaseItemData _spinBaseItemData;
        private SpinItemData _spinItemData;
        public BronzeSpinTypeStrategy(SpinBaseItemData spinBaseItemData,SpinItemData spinItemData)
        {
            _spinBaseItemData = spinBaseItemData;
            _spinItemData = spinItemData;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_spinBaseItemData.UISpinBronze.UiSpinBronzeBase, _spinBaseItemData.UISpinBronze.UiSpinBronzeIndicator);
        }

        public List<Sprite>GetWheelItems()
        {
            return _spinItemData.GetSpritesByType(SpinType.Bronze);
        }
    }
}

