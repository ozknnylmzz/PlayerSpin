using System.Collections.Generic;
using Player.Data;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public interface ISpinTypeStrategy
    {
        (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites();
        List<WheelInfo> GetWheelInfo();
    }
}

