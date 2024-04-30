
using UnityEngine;


namespace Player.UI.Reward
{
    [CreateAssetMenu(fileName = "UI", menuName = "RewardUI/RewardUI Data")]

    public class RewardUIData : ScriptableObject
    {
        [field: SerializeField] public RewardItem RewardPrefab { get; private set; }
    }
}

