using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Spin.Strategy
{
    public class SilverSpinTypeStrategy : ISpinTypeStrategy
    {
        private SpinCreatorData _data;

        public SilverSpinTypeStrategy(SpinCreatorData data)
        {
            _data = data;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_data.UISpinSilver.UiSpinSilverBase, _data.UISpinSilver.UiSpinSilverIndicator);
        }

        public Sprite[] GetSpinTypeItems()
        {
            return _data.UISpinSilver.UiSpinSilverItems;
        }
    }
}

