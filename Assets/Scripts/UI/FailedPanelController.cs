using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.UI
{
    public class FailedPanelController : UIControllerBase
    {
        public override PanelType PanelType => PanelType.FailPanel;
        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
}

