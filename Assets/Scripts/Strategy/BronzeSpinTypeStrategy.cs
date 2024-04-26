using UnityEngine;

namespace Player.Spin.Strategy
{
    public class BronzeSpinTypeStrategy : ISpinTypeStrategy
    {
        private SpinCreatorData _data;

        public BronzeSpinTypeStrategy(SpinCreatorData data)
        {
            _data = data;
        }

        public (Sprite baseImage, Sprite indicatorImage) GetBaseAndIndicatorSprites()
        {
            return (_data.UISpinBronze.UiSpinBronzeBase, _data.UISpinBronze.UiSpinBronzeIndicator);
        }

        public Sprite[] GetSpinTypeItems()
        {
            return _data.UISpinBronze.UiSpinBronzeItems;
        }
    }
}

