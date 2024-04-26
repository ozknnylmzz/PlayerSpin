using UnityEngine;
using DG.Tweening;

namespace Player.Spin
{
    public class Spin : MonoBehaviour
    {
        [SerializeField] private SpinSettings _spinSettings;
        [SerializeField] private RectTransform _rectTransform;
        
        [ContextMenu("Play Spin")]
        public Tween PlaySpin(out float targetAngle)
        {
            float totalAnglePerSection = _spinSettings.RewardAngle + _spinSettings.GapAngle;

            int numberOfSpins = Random.Range(_spinSettings.MinSpins, _spinSettings.MaxSpins);

            int randomSectionIndex = Random.Range(0, (int)(360 / totalAnglePerSection));
           
             targetAngle = numberOfSpins * 360f + randomSectionIndex * totalAnglePerSection + _spinSettings.RewardAngle / 2f;

            targetAngle = -targetAngle+Random.Range(0,_spinSettings.RewardAngle);
            
            return  _rectTransform.DORotate(new Vector3(0, 0, targetAngle), _spinSettings.SpinTime, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCubic);
        }
    }
}