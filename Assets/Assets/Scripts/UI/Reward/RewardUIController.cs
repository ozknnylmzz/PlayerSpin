
using System;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI.Reward
{
    public class RewardUIController : MonoBehaviour
    {
        // [SerializeField] private RewardUIData _rewardUIData;
        [SerializeField] private Button _exitButton;
        [SerializeField] private List<RewardItem> _rewardItems;
        [SerializeField] private RewardUIData _rewardUIData;
        private void SetRewardItem(Data.Reward reward)
        {
            if (_rewardUIData!=null)
            {
                foreach (var item in _rewardItems)
                {
                    Data.Reward rewardItem = DataManager.Instance.Inventory.GetReward(reward.RewardIcon.name);
                    // item.SetRewardItem();
                }
                
               
                // var existingItem = _rewardUIData.EarnedRewardItems.Find(item => item.RewardIcon.sprite.name.Contains(rewardItem.RewardIcon.name));
                //
                // if (reward.RewardIcon.name.Contains(Constants.Grenade))return;
                //
                // if (existingItem == null)
                // {
                //     var newEarnedItem = Instantiate(_rewardUIData.RewardPrefab, _content);
                //     newEarnedItem.SetRewardItem(reward.RewardIcon,reward.RewardAmount.ToString(),reward.RewardType);
                //      _rewardUIData.EarnedRewardItems.Add(newEarnedItem);
                // }
                // else
                // {
                //     int rewardAmount = reward.RewardAmount + existingItem.GetRewardAmount();
                //     existingItem.RewardAmount.text = "x" + rewardAmount;
                // }
            }
        }
        
        private void OpenFailedPanel()
        {
            foreach (var rewardItem in _rewardUIData.EarnedRewardItems)
            {
               Destroy(rewardItem.gameObject);
            }
            _rewardUIData.DestroyRewardItems();
        }

        private void ClickExitButton()
        {
            EventManager<PanelType>.Execute(UIEvents.OnOpenPanel,PanelType.ExitConfirmPanel);
        }

        private void SetExitButton(bool active)
        {
            _exitButton.interactable = active;
        }
        
        private void OnEnable()
        {
            EventManager< Data.Reward>.Subscribe(UIEvents.OnEarnedReward,SetRewardItem);
            EventManager.Subscribe(PanelType.FailedPanel,OpenFailedPanel);
            EventManager<bool>.Subscribe(UIEvents.OnLockExitButton,SetExitButton);
            _exitButton.onClick.AddListener(ClickExitButton);
        }
     
        private void OnDisable()
        {
            EventManager<Data.Reward>.Unsubscribe(UIEvents.OnEarnedReward,SetRewardItem);
            EventManager.Unsubscribe(PanelType.FailedPanel,OpenFailedPanel);
            EventManager<bool>.Unsubscribe(UIEvents.OnLockExitButton,SetExitButton);
            _exitButton.onClick.RemoveListener(ClickExitButton);
        }

        private void OnApplicationQuit()
        {
            _rewardUIData.DestroyRewardItems();
        }
    }
}

