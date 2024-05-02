using System;
using System.Collections.Generic;
using System.Linq;
using Player.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "WheelData", menuName = "WheelData/Wheel Data")]
    public class WheelData : ScriptableObject
    {
        public WheelSliceData[] WheelItems;

        public WheelSliceData FindWheelSliceByAngle(float targetAngle)
        {
            foreach (var slice in WheelItems)
            {
                if (slice.MinAngle <= targetAngle && targetAngle < slice.MaxAngle)
                {
                    return slice;
                }
            }

            if (targetAngle>350 &&targetAngle <360)
            {
                return WheelItems[0];
            }

            return null;
        }
    }

    [Serializable]
    public class WheelSliceData
    {
        [field: SerializeField] public int SlotNo { get; private set; }
        [field: SerializeField] public int MinAngle { get; private set; }
        [field: SerializeField] public int MaxAngle { get; private set; }

        [FormerlySerializedAs("itemIcon")] [SerializeField] private Sprite _itemIcon;

        public SpinType SpinType;
        [FormerlySerializedAs("Quantity")] public int Amount;

        public string ItemName
        {
            get
            {
                if (_itemIcon == null)
                {
                    Debug.LogError("Sprite is missing. Please assign a Sprite to the ItemIcon.");
                    return "";
                }
                return _itemIcon.name;
            }
        }

        public Sprite ItemIcon
        {
            get { return _itemIcon; }
            set { _itemIcon = value; }
        }

        public bool CheckGrenadeItem()
        {
            if (ItemName.Contains(Constants.Grenade))
            {
                return true;
            }

            return false;
        }

        public void SetWheelProp(Sprite itemIcon,int amount)
        {
            ItemIcon = itemIcon;
            Amount = amount;
        }
    }
}