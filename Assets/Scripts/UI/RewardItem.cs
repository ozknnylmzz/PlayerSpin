using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace  Player.UI.Reward
{
    public class RewardItem : MonoBehaviour
    {
        [field: SerializeField] public Image RewardIcon { get; set; }
        [field: SerializeField] public TextMeshProUGUI RewardAmount{ get; set; }

    }
}

