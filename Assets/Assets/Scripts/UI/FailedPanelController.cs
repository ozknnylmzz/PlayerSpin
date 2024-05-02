using System;
using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class FailedPanelController : UIControllerBase
    {
        public override PanelType PanelType => PanelType.FailedPanel;
        [SerializeField] private Button _giveUpButton;
        [SerializeField] private Button _reviveButton;

        public override void Subscribe()
        {
            base.Subscribe();
            _giveUpButton.onClick.AddListener(ClickGiveUpButton);
            _reviveButton.onClick.AddListener(ClickReviveButton);
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
            _giveUpButton.onClick.RemoveListener(ClickGiveUpButton);
            _reviveButton.onClick.RemoveListener(ClickReviveButton);
        }

        private void ClickGiveUpButton()
        {
            DataManager.Instance.ResetData();
            EventManager.Execute(PanelType.FailedPanel);
            Close();
        }

        private void ClickReviveButton()
        {
            Close();
        }
    }
}

