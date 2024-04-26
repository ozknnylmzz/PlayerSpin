using System;
using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "InventoryData", menuName = "InventoryData/Inventory Data")]
    public class InventoryData : ScriptableObject
    {
        public ItemData[] Slots;
        public List<Sprite> GetSpritesByType(SpinType type)
        {
            List<Sprite> sprites = new List<Sprite>();
            
            foreach (ItemData item in Slots)
            {
                if (item.SpinType == type)
                {
                    sprites.Add(item.SpinItemImage);
                }
            }
            return sprites;
        }
    }

    [Serializable]
    public class ItemData
    {
        public SpinType SpinType;
        public Sprite SpinItemImage{ get; set; }
        public string Name;

        public ItemData(SpinType spinType,Sprite spinItemImage,string name)
        {
            SpinType = spinType;
            SpinItemImage = spinItemImage;
            Name = name;
        }
    }
}