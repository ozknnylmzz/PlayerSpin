
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin
{
    public class WheelItem : MonoBehaviour
    {
        [SerializeField]  Image _wheelItemImage;
        public void SetWheelItemImage(Sprite wheelItemImage)
        {
            _wheelItemImage.sprite=wheelItemImage;
        }
    }
}

