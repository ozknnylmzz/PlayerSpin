using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using Player.UI.Reward;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class SuccesPanelController : UIControllerBase
    {
        [SerializeField] private RewardUIData _rewardUIData;
        [SerializeField] private RectTransform _context;
        [SerializeField] private SuccessPanelData _successPanelData;
        [SerializeField] private Button _continueButton;

        public override PanelType PanelType => PanelType.SuccesPanel;

        private List<RewardCardItem> _rewardCardItem = new();

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

        public override void Subscribe()
        {
            base.Subscribe();
            _continueButton.onClick.AddListener(ClickContinueButton);
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
            _continueButton.onClick.AddListener(ClickContinueButton);
        }

        private void CreateRewards()
        {
            RewardCardItem rewardCardItem;
            foreach (var rewardItem in _rewardUIData.EarnedRewardItems)
            {
                rewardCardItem = Instantiate(_successPanelData.RewardCardPrefab, _context);
                rewardCardItem.SetCardProp(rewardItem.GetSprite(),rewardItem.GetRewardText());
                _rewardCardItem.Add(rewardCardItem);
            }
        }

        private void ClickContinueButton()
        {
            ClearRewardCard();
            DataManager.Instance.ResetData();
            EventManager.Execute(PanelType.FailedPanel);
            EventManager.Execute(SpinType.Purple);
            Close();
        }

        private void ClearRewardCard()
        {
            foreach (var rewardCard in _rewardCardItem)
            {
                Destroy(rewardCard.gameObject);
            }
            _rewardCardItem.Clear();
            _rewardUIData.DestroyRewardItems();
        }

        private void OnApplicationQuit()
        {
            _rewardUIData.DestroyRewardItems();
        }
    }
}