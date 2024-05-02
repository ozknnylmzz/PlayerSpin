using UnityEngine;

namespace Player.Spin
{
    [CreateAssetMenu(fileName = "SpinSettings", menuName = "Spin/Spin Settings")]
    public class SpinSettings : ScriptableObject
    {
        [field:SerializeField] public float SpinTime { get; private set; }
        [field:SerializeField] public float RewardAngle { get; private set; }
        [field:SerializeField] public float GapAngle { get; private set; }
        [field:SerializeField] public int MinSpins { get; private set; }
        [field:SerializeField] public int MaxSpins { get; private set; }
        [field:SerializeField] public int LockDelayTime { get; private set; }

    }
}

