
using Player.Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace  Player.UI.Reward
{
    public class RewardItem : MonoBehaviour
    {
        [field: SerializeField] public Image RewardIcon { get; private set; }
        [field: SerializeField] public TextMeshProUGUI RewardAmount{ get; private set; }
        [field: SerializeField] public SpinType RewardType{ get;private set; }
        
        public Sprite GetSprite()
        {
            return RewardIcon.sprite;
        }

        public string GetRewardText()
        {
            return RewardAmount.text;
        }

        public int GetRewardAmount()
        {
            int.TryParse(RewardAmount.text, out int rewardAmount);
            return  rewardAmount;
        }

        public void SetRewardItem(Sprite rewardIcon,string rewardAmount,SpinType rewardType)
        {
            RewardIcon.sprite = rewardIcon;
            RewardAmount.text = "x" + rewardAmount;
            RewardType = rewardType;
        }
    }
}

