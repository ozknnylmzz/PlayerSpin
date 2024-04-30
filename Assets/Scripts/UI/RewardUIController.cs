
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI.Reward
{
    public class RewardUIController : MonoBehaviour
    {
        [SerializeField] private RewardUIData _rewardUIData;
        [SerializeField] private RectTransform _content;
        private List<RewardItem> _rewardItems=new ();
        private void OnEnable()
        {
            EventManager< Data.Reward>.Subscribe(UIEvents.OnEarnedReward,SetRewardText);
            EventManager.Subscribe(PanelType.FailedPanel,OpenFailedPanel);
        }

     
        private void OnDisable()
        {
            EventManager<Data.Reward>.Unsubscribe(UIEvents.OnEarnedReward,SetRewardText);
        }
    
        private void SetRewardText(Data.Reward reward)
        {
            if (_rewardUIData!=null)
            {
                Data.Reward rewardItem = DataManager.Instance.Inventory.GetReward(reward.RewardIcon.name);
                var existingItem = _rewardItems.Find(item => item.RewardIcon.sprite.name.Contains(rewardItem.RewardIcon.name));

                if ( reward.RewardIcon.name.Contains(Constants.Grenade))
                {
                    return;
                }
                
                if (existingItem == null)
                {
                    var newItem = Instantiate(_rewardUIData.RewardPrefab, _content);
                    newItem.RewardIcon.sprite = reward.RewardIcon;
                    newItem.RewardAmount.text = "x"+reward.RewardAmount;
                    _rewardItems.Add(newItem);
                }
                else
                {
                    existingItem.RewardAmount.text = "x" + reward.RewardAmount;
                }
            }
        }
        
        private void OpenFailedPanel()
        {
            foreach (var rewardItem in _rewardItems)
            {
               Destroy(rewardItem.gameObject);
            }
            _rewardItems.Clear();
        }

    }
}

