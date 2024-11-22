using System;
using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using Player.UI.Reward;
using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "SuccessPanel", menuName = "UI/SuccessPanel Data")]
    public class SuccessPanelData : ScriptableObject
    {
        [field: SerializeField] public RewardCardItem RewardCardPrefab { get; private set; }
        [field: SerializeField] public Color BronzeCardColorFrame { get; private set; }
        [field: SerializeField] public Color SilverCardColorFrame { get; private set; }
        [field: SerializeField] public Color GoldenCardColorFrame { get; private set; }
        

        public Color GetCardFrame(SpinType cardType)
        {
            switch (cardType)
            {
                case SpinType.Blue:
                    return BronzeCardColorFrame;
                case SpinType.Purple:
                    return SilverCardColorFrame;
                case SpinType.Green:
                    return GoldenCardColorFrame;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null);
            }
        }
    }
}

