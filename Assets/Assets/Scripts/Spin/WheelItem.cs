
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Spin
{
    public class WheelItem : MonoBehaviour
    {
        [SerializeField]  Image _wheelItemImage;
        [SerializeField]  TextMeshProUGUI _itemAmountText;

        public void SetWheelItemProp(Sprite wheelItemImage,int amount)
        {
            _wheelItemImage.sprite=wheelItemImage;
            _itemAmountText.text = "x" +amount;
        }
    }
}

