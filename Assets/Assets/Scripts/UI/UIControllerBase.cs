using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.UI
{
    public abstract class UIControllerBase : MonoBehaviour
    {
        public abstract PanelType PanelType { get; }

        public virtual void Open()
        {
            gameObject.SetActive(true);   
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);   
        }
    
        public virtual void Subscribe()
        {

        }
        
        public virtual void Unsubscribe()
        {

        }

    }
}

