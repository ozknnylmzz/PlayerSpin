using System;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory Data")]
    public class Inventory : ScriptableObject
    {
        public List<Reward> Rewards;
        public void AddReward( int amount,Sprite rewardIcon,SpinType rewardType)
        {
            var existingReward = Rewards.Find(r => r.RewardIcon.name == rewardIcon.name);
            if (existingReward != null)
            {
                existingReward.RewardAmount += amount;
            }
            else
            {
                Rewards.Add(new Reward { RewardAmount = amount,RewardIcon = rewardIcon,RewardType = rewardType});
            }
        }
        
        public Reward GetReward(string rewardName)
        {
            var reward = Rewards.Find(r => r.RewardIcon.name == rewardName);
            
            return reward ;
        }
        
        public void ResetItems()
        {
            Rewards.Clear();
        }
    }
    
    [Serializable]
    public class Reward
    {
        public int RewardAmount;
        public Sprite RewardIcon;
        public SpinType RewardType;
    }
}

