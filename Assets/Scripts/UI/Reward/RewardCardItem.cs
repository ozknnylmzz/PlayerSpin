using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI.Reward
{
    public class RewardCardItem : MonoBehaviour
    {
        [SerializeField] private Image _cardIcon;
        [SerializeField] private Image _cardFrame;

        public void SetrCardIcon(Sprite cardIcon)
        {
            _cardIcon.sprite = cardIcon;
        }

        public void SetCardFrame(Color cardFrameColor)
        {
            _cardFrame.color = cardFrameColor;
        }
    }
}

