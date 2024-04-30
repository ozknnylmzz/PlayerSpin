using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.da
{
    [CreateAssetMenu(fileName = "SpinItemData", menuName = "Spin/Spin Item Data")]
    public class SpinItemData : ScriptableObject
    {
        [field:SerializeField] public Sprite[]  UiSpinBronzeItems{ get; private set; }
        [field:SerializeField] public Sprite[]  UiSpinSilverItems{ get; private set; }
        [field:SerializeField] public Sprite[]  UiSpinGoldenItems{ get; private set; }
    }
}

