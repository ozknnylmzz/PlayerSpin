using System;
using System.Collections;
using System.Collections.Generic;
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

        public List<Sprite> GetSpritesByType(SpinType spinType)
        {
            List<Sprite> sprites = new List<Sprite>();
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
        
        private List<Sprite> GetSpritesFromItems<T>(T[] spinItems) where T : IUiSpinItem
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (var spinItem in spinItems)
            {
                sprites.Add(spinItem.SpinItemImage);
            }
            return sprites;
        }
        
        public SpinType GetSpinTypeOfSprite(Sprite sprite)
        {
            foreach (var item in UiSpinBronzeItems)
            {
                if (item.SpinItemImage == sprite)
                    return item.SpinType;
            }

            foreach (var item in UiSpinSilverItems)
            {
                if (item.SpinItemImage == sprite)
                    return item.SpinType;
            }

            foreach (var item in UiSpinGoldenItems)
            {
                if (item.SpinItemImage == sprite)
                    return item.SpinType;
            }

            throw new Exception("Sprite not found in any SpinType list.");
        }
    }
    
    public interface IUiSpinItem
    {
        SpinType SpinType { get; }
        Sprite SpinItemImage { get; }
        int  Amount { get; }
    }

    [Serializable]
    public class UiSpinBronzeItems:IUiSpinItem
    {
        public SpinType SpinType => SpinType.Bronze;
        [field: SerializeField]   public Sprite SpinItemImage { get; private set; }
        [field: SerializeField]    public int Amount{ get; private set; }
    }
    [Serializable]
    public class UiSpinSilverItems:IUiSpinItem
    {
        public SpinType SpinType => SpinType.Silver;
        [field: SerializeField] public Sprite SpinItemImage { get; private set; }
        [field: SerializeField] public int Amount{ get; private set; }
    }
    [Serializable]
    public class UiSpinGoldenItems:IUiSpinItem
    {
        public SpinType SpinType => SpinType.Golden;
        [field: SerializeField] public Sprite SpinItemImage { get; private set; }
        [field: SerializeField] public int Amount{ get; private set; }
    }
}