using System.Collections;
using System.Collections.Generic;
using Player.Enum;
using UnityEngine;

namespace Player.Spin.State
{
    public class SpinBronzeState
    {
        private SpinController _spinController;

        private SpinType _spinType = SpinType.Bronze;
        public SpinBronzeState(SpinController spinController)
        {
            _spinController = spinController;
        }
    }
}

