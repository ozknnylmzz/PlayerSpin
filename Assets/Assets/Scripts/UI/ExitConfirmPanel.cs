
using Player.Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class ExitConfirmPanel : UIControllerBase
    {
        [SerializeField] private Button _collectButton;
        [SerializeField] private Button _gotToBackButton;

        public override PanelType PanelType => PanelType.ExitConfirmPanel;
        
        public override void Open()
        {
            base.Open();
            Debug.Log("exit panel acıldı");
        }

        public override void Close()
        {
            base.Close();
            Debug.Log("exit panel kapandı");
        }

        public override void Subscribe()
        {
            base.Subscribe();
            _collectButton.onClick.AddListener(ClickCollectButton);
            _gotToBackButton.onClick.AddListener(Close);
        }

        public override void Unsubscribe()
        {
            base.Unsubscribe();
            _collectButton.onClick.RemoveListener(ClickCollectButton);
            _gotToBackButton.onClick.RemoveListener(Close);
        }

        private void ClickCollectButton()
        {
            EventManager<PanelType>.Execute(UIEvents.OnOpenPanel, PanelType.SuccesPanel);
            Close();
        }
    }
}

