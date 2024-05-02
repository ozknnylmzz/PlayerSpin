using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.Strategy
{
public class GoldenSpinTypeStrategy : ISpinTypeStrategy
{
    private SpinBaseItemData _spinBaseItemData;
    private SpinItemData _spinItemData;

    public GoldenSpinTypeStrategy(SpinBaseItemData spinBaseItemData,SpinItemData spinItemData)
    {
        _spinBaseItemData = spinBaseItemData;
        _spinItemData = spinItemData;
    }
    
    public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
    {
        return (_spinBaseItemData.UISpinGolden.UiSpinGoldenBase, _spinBaseItemData.UISpinGolden.UiSpinGoldenIndicator);
    }

    public List<WheelInfo> GetWheelInfo()
    {
        return _spinItemData.GetSpritesByType(SpinType.Golden);
    }
}
}