using System;
using Player.Enum;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "WheelData", menuName = "WheelData/Wheel Data")]
    public class WheelData : ScriptableObject
    {
        public WheelSliceData[] WheelItems;
        public Sprite WheelGlow;
        [field:SerializeField] public float AnimationScale { get; private set; }
        [field:SerializeField] public float AnimationTime { get; private set; }
    }

    [Serializable]
    public class WheelSliceData
    {
        [field: SerializeField] public int SlotNo { get; private set; }
        [field: SerializeField] public Sprite ItemImage;
        [field: SerializeField] public Sprite BackgroundImage;
        [field: SerializeField] public SpinType SpinType;
        [field: SerializeField] public int Amount;
        
        public string ItemName
        {
            get
            {
                if (ItemImage == null)
                {
                    Debug.LogError("Sprite is missing. Please assign a Sprite to the ItemImage.");
                    return "";
                }
                
                return ItemImage.name;
            }
        }

        public bool CheckGrenadeItem()
        {
            if (ItemName.Contains(Constants.Grenade))
            {
                return true;
            }

            return false;
        }

        public void SetWheelProp(Sprite itemIcon, int amount)
        {
            ItemImage = itemIcon;
            Amount = amount;
        }
    }
}