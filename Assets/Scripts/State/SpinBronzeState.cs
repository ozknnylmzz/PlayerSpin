using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinBronzeState :IState
    {
        private SpinController _spinController;

        private SpinType _spinType = SpinType.Bronze;
        public SpinBronzeState(SpinController spinController)
        {
            _spinController = spinController;
        }

        public void Enter()
        {
            EventManager<PanelType>.Execute(UIEvents.OnOpenPanel,PanelType.SuccesPanel);
        }

        public void Exit()
        {
            EventManager<PanelType>.Execute(UIEvents.OnClosePanel,PanelType.SuccesPanel);
        }
    }
}

