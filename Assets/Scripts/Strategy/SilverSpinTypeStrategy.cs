using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public class SilverSpinTypeStrategy : ISpinTypeStrategy
    {
        private SpinCreatorData _spinCreatorData;
        private InventoryData _inventoryData;


        public SilverSpinTypeStrategy(SpinCreatorData spinCreatorData,InventoryData inventoryData)
        {
            _spinCreatorData = spinCreatorData;
            _inventoryData = inventoryData;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_spinCreatorData.UISpinSilver.UiSpinSilverBase, _spinCreatorData.UISpinSilver.UiSpinSilverIndicator);
        }

        public List<Sprite> GetWheelItems()
        {
            return _inventoryData.GetSpritesByType(SpinType.Silver);
        }
    }
}

