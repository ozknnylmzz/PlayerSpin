using System.Collections.Generic;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public interface ISpinTypeStrategy
    {
        (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites();
        List<Sprite> GetWheelItems();
    }
}

