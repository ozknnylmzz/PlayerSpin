using UnityEngine;

namespace Player.Spin.Strategy
{
    public interface ISpinTypeStrategy
    {
        (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites();
        Sprite[] GetSpinTypeItems();
    }
}

