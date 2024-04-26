using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public class BronzeSpinTypeStrategy : ISpinTypeStrategy
    {
        private SpinCreatorData _spinCreatorData;
        private InventoryData _inventoryData;
        public BronzeSpinTypeStrategy(SpinCreatorData spinCreatorData,InventoryData inventoryData)
        {
            _spinCreatorData = spinCreatorData;
            _inventoryData = inventoryData;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_spinCreatorData.UISpinBronze.UiSpinBronzeBase, _spinCreatorData.UISpinBronze.UiSpinBronzeIndicator);
        }

        public List<Sprite>GetWheelItems()
        {
            return _inventoryData.GetSpritesByType(SpinType.Bronze);
        }
    }
}

