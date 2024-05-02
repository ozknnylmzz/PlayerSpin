using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using Player.UI.Reward;
using UnityEngine;

namespace Player.UI
{
    public class SuccesPanelController : UIControllerBase
    {
        [SerializeField] private RewardUIData _rewardUIData;
        [SerializeField] private RectTransform _context;
        [SerializeField] private SuccessPanelData _successPanelData;

        public override PanelType PanelType => PanelType.SuccesPanel;

        private RewardCardItem _rewardCardItem;
        public override void Open()
        {
            base.Open();
            Debug.Log("succes panel acıldı");
            CreateRewards();
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("succes panel kapandı");
        }

        private void CreateRewards()
        {
            foreach (var rewardItem in _rewardUIData.EarnedRewardItems)
            {
                _rewardCardItem= Instantiate(_successPanelData.RewardCardPrefab, _context);
                _rewardCardItem.SetrCardIcon(rewardItem.GetSprite());
                _rewardCardItem.SetCardFrame(_successPanelData.GetCardFrame(rewardItem.RewardType));
            }
            
        }
    }
}

