using System;
using Player.Data;
using UnityEngine;

namespace Player.Spin
{
    [CreateAssetMenu(fileName = "SpinObjectsData", menuName = "Spin/Spin Objects Data")]
    public class SpinCreatorData : ScriptableObject
    {
        public UISpinBronze UISpinBronze;
        public UISpinSilver UISpinSilver;
        public UISpinGolden UISpinGolden;
    }
    
    [Serializable]
    public class UISpinBronze
    {
        [field:SerializeField] public Sprite UiSpinBronzeBase { get; private set; }
        [field:SerializeField] public Sprite UiSpinBronzeIndicator { get; private set; }
    }
    
    [Serializable]
    public class UISpinSilver
    {
        [field:SerializeField] public Sprite UiSpinSilverBase { get; private set; }
        [field:SerializeField] public Sprite UiSpinSilverIndicator { get; private set; }
    }
    
    [Serializable]
    public class UISpinGolden
    {
        [field:SerializeField] public Sprite UiSpinGoldenBase { get; private set; }
        [field:SerializeField] public Sprite UiSpinGoldenIndicator { get; private set; }
    }
    
}