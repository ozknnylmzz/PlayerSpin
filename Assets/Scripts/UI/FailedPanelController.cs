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

        public override void Open()
        {
            base.Open();
            Debug.Log("failed panel open");
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }

        public override void Subscribe()
        {
            base.Subscribe();
            _giveUpButton.onClick.AddListener(ResetItem);
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
            _giveUpButton.onClick.RemoveListener(ResetItem);
        }

        private void ResetItem()
        {
            
            DataManager.Instance.ResetData();
            EventManager.Execute(PanelType.FailedPanel);
            Close();
        }
    }
}

