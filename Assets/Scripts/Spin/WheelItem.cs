using System;
using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Player.Enum;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Player.Spin
{
    public class WheelItem : MonoBehaviour
    {
        [SerializeField]  Image _wheelItemImage;
        [SerializeField] private float _minRange;
        [SerializeField] private float _maxRange;
        [SerializeField] private Sprite[] _sprites;


        public void SetWheelItemImage(Sprite wheelItemImage)
        {
            _wheelItemImage.sprite=wheelItemImage;
        }
    }
}

