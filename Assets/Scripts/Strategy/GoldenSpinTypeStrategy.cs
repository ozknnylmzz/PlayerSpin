using UnityEngine;

namespace Player.Spin.Strategy
{
public class GoldenSpinTypeStrategy : ISpinTypeStrategy
{
    private SpinCreatorData _data;

    public GoldenSpinTypeStrategy(SpinCreatorData data)
    {
        _data = data;
    }
    public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
    {
        return (_data.UISpinGolden.UiSpinGoldenBase, _data.UISpinGolden.UiSpinGoldenIndicator);
    }

    public Sprite[] GetSpinTypeItems()
    {
        return _data.UISpinGolden.UiSpinGoldenItems;
    }
}
}