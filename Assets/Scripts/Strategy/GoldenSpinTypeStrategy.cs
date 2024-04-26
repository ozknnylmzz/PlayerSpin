using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.Strategy
{
public class GoldenSpinTypeStrategy : ISpinTypeStrategy
{
    private SpinCreatorData _spinCreatorData;
    private InventoryData _inventoryData;

    public GoldenSpinTypeStrategy(SpinCreatorData spinCreatorData,InventoryData inventoryData)
    {
        _spinCreatorData = spinCreatorData;
        _inventoryData = inventoryData;
    }
    
    public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
    {
        return (_spinCreatorData.UISpinGolden.UiSpinGoldenBase, _spinCreatorData.UISpinGolden.UiSpinGoldenIndicator);
    }

    public List<Sprite> GetWheelItems()
    {
        return _inventoryData.GetSpritesByType(SpinType.Golden);
    }
}
}