
using System;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "WheelData", menuName = "WheelData/Wheel Data")]
    public class WheelData : ScriptableObject
    {
        public WheelSlice[] items; 
        
        public WheelSlice FindWheelSliceByAngle(float targetAngle)
        {
            foreach (var slice in items)
            {
                if (slice.MinAngle <= targetAngle && targetAngle < slice.MaxAngle)
                {
                    return slice;
                }
            }

            return null;
        }
    }
    
    [Serializable]
    public class WheelSlice
    {
        [field: SerializeField] public int SlotNo { get; private set; }
        [field: SerializeField] public int MinAngle { get; private set; }
        [field: SerializeField] public int MaxAngle { get; private set; }
        public SpinType SpinType;
        public string ItemName;
        public Sprite ItemIcon;  
        public int Quantity;
      

        public WheelSlice(string name, Sprite icon, int quantity,SpinType spinType,int slotNo,int minAngle,int maxAngle)
        {
            ItemName = name;
            ItemIcon = icon;
            Quantity = quantity;
            SpinType = spinType;
            SlotNo = slotNo;
            MinAngle = minAngle;
            MaxAngle = maxAngle;
        }
    }
}

