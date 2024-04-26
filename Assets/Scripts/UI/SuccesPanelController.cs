using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.UI
{
    public class SuccesPanelController : UIControllerBase
    {
        public override PanelType PanelType => PanelType.SuccesPanel;
        public override void Open()
        {
            Debug.Log("succes panel acıldı");
        }

        public override void Close()
        {
            Debug.Log("succes panel kapandı");
        }
    }
}

