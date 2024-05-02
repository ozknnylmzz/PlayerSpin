
using System.Collections.Generic;
using UnityEngine;


namespace Player.UI.Reward
{
    [CreateAssetMenu(fileName = "UI", menuName = "RewardUI/RewardUI Data")]

    public class RewardUIData : ScriptableObject
    {
        [field: SerializeField] public RewardItem RewardPrefab { get; private set; }
        public List<RewardItem> EarnedRewardItems = new();

        public void AddRewardItem(RewardItem rewardItem)
        {
            EarnedRewardItems.Add(rewardItem);
        }

        public void DestroyRewardItems()
        {
            EarnedRewardItems.Clear();
        }
    }
}

