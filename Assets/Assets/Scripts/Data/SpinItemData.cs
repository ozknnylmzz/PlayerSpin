using System;
using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "SpinItemData", menuName = "SpinItemData/SpinItem Data")]
    public class SpinItemData : ScriptableObject
    {
        public UiSpinBronzeItems[] UiSpinBronzeItems;
        public UiSpinSilverItems[] UiSpinSilverItems;
        public UiSpinGoldenItems[] UiSpinGoldenItems;

        public List<WheelInfo> GetSpritesByType(SpinType spinType)
        {
            List<WheelInfo> sprites = new List<WheelInfo>();
            switch (spinType)
            {
                case SpinType.Bronze:
                    return GetSpritesFromItems(UiSpinBronzeItems);

                case SpinType.Silver:
                    return GetSpritesFromItems(UiSpinSilverItems);

                case SpinType.Golden:
                    return GetSpritesFromItems(UiSpinGoldenItems);
            }

            return sprites;
        }

        private List<WheelInfo> GetSpritesFromItems<T>(T[] spinItems) where T : IUiSpinItem
        {
            List<WheelInfo> wheelInfos = new List<WheelInfo>();
            foreach (var spinItem in spinItems)
            {
                wheelInfos.Add(spinItem.WheelInfo);
            }

            return wheelInfos;
        }

        public SpinType GetSpinTypeOfSprite(Sprite sprite)
        {
            foreach (var item in UiSpinBronzeItems)
            {
                if (item.WheelInfo.SpinItemImage == sprite)
                    return item.SpinType;
            }

            foreach (var item in UiSpinSilverItems)
            {
                if (item.WheelInfo.SpinItemImage == sprite)
                    return item.SpinType;
            }

            foreach (var item in UiSpinGoldenItems)
            {
                if (item.WheelInfo.SpinItemImage == sprite)
                    return item.SpinType;
            }
      
            Debug.LogError("Check the wheel data and assign appropriate sprites to the silver type.");
            throw new Exception("Sprite not found in any SpinType list.");
        }
    }

    public interface IUiSpinItem
    {
        WheelInfo WheelInfo { get; }
    }

    [Serializable]
    public class UiSpinBronzeItems : IUiSpinItem
    {
        public SpinType SpinType => SpinType.Bronze;
        [field: SerializeField] public WheelInfo WheelInfo { get; private set; }
    }
    
    [Serializable]
    public class UiSpinSilverItems : IUiSpinItem
    {
        public SpinType SpinType => SpinType.Silver;

        [field: SerializeField] public WheelInfo WheelInfo { get; private set; }
    }

    [Serializable]
    public class UiSpinGoldenItems : IUiSpinItem
    {
        public SpinType SpinType => SpinType.Golden;
        [field: SerializeField] public WheelInfo WheelInfo { get; private set; }
    }

    [Serializable]
    public class WheelInfo
    {
        [field: SerializeField] public Sprite SpinItemImage { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}
