using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Spin.Creator
{
    public class SpinCreator : MonoBehaviour
    {
        [field: SerializeField] public List<WheelItem> WheelItems;
        [SerializeField] private SpinSettings _spinSettings;
        
        private void Start()
        {
            SetWheelToStartSpin();
        }

        private void SetWheelToStartSpin()
        {
            // WheelItems.Shuffle();
            DataManager.Instance.WheelData.WheelItems.Shuffle();
            for (int i = 0; i < WheelItems.Count; i++)
            {
                WheelSliceData sliceData= DataManager.Instance.WheelData.WheelItems[i];
                WheelItems[i].SetWheelItemProp(sliceData.ItemImage,sliceData.BackgroundImage,DataManager.Instance.WheelData.WheelGlow,sliceData.Amount);
            }
        }
        
       
    }
}