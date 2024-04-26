using System;
using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIControllerBase[] _panels;

        private void OnEnable()
        {
            EventManager<PanelType>.Subscribe(UIEvents.OnOpenPanel,OpenPanel);
            EventManager<PanelType>.Subscribe(UIEvents.OnClosePanel,ClosePanel);
        }

        private void OnDisable()
        {
            EventManager<PanelType>.Unsubscribe(UIEvents.OnOpenPanel,OpenPanel);
            EventManager<PanelType>.Unsubscribe(UIEvents.OnClosePanel,ClosePanel);
        }

        public UIControllerBase GetPanel(PanelType panelType)
        {
            foreach (UIControllerBase panel in _panels)
            {
                if (panel.PanelType == panelType)
                {
                    return panel;
                }
            }

            Debug.LogError("Invalid panel type");

            return null;
        }
        
        public void OpenPanel(PanelType panelType)
        {
            GetPanel(panelType).Open();
        }
        
        public void ClosePanel(PanelType panelType)
        {
            GetPanel(panelType).Close();
        }
    }
    
    
}


