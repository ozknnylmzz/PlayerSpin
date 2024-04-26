using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.UI
{
    public abstract class UIControllerBase : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        
        public abstract PanelType PanelType { get; }
        
        public virtual void Init()
        {
            float screenWidth = UnityEngine.Screen.width;
            Vector3 rootCanvasScale = _rectTransform.root.localScale;

            Vector2 sizeDelta = _rectTransform.sizeDelta;
            sizeDelta.x = screenWidth / rootCanvasScale.x;
            _rectTransform.sizeDelta = sizeDelta;
        }
    
        public abstract void Open();
    
        public abstract void Close();
    
        public virtual void Subscribe()
        {

        }
        
        public virtual void Unsubscribe()
        {

        }

    }
}

