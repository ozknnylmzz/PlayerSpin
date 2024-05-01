using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player.UI.Round
{
    [CreateAssetMenu(fileName = "ProgressRound", menuName = "UI/ProgressRound Data")]
    public class ProgressRoundData : ScriptableObject
    {
        [field: SerializeField] public float RoundTextDistance { get; private set; }
        [field: SerializeField] public float RoundTourDuration { get; private set; }
        [field: SerializeField] public int RoundTextCount { get; private set; }
        [field: SerializeField] public float RoundStartPositon { get; private set; }
        [field: SerializeField] public GameObject RoundTextPrefab { get; private set; }
        [field: SerializeField] public TMP_FontAsset SilverFont { get; private set; }
        [field: SerializeField] public TMP_FontAsset GoldenFont { get; private set; }

    }
}

