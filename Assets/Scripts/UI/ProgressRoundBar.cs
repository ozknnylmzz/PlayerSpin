using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Player.Data;
using Player.Enum;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.UI.Round
{
    public class ProgressRoundBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _roundTextPanel;

        [SerializeField] private List<TextMeshProUGUI> _roundTexts;
        [SerializeField] private ProgressRoundData _progressRoundData;

        private void CreateRoundText()
        {
            GameObject round = Instantiate(_progressRoundData.RoundTextPrefab, _roundTextPanel);
            TextMeshProUGUI text = round.GetComponent<TextMeshProUGUI>();
            text.text = (DataManager.Instance.CurrentRound + _progressRoundData.RoundTextCount).ToString();
            _roundTexts.Add(text); 
            UpdateTextColorBasedOnNumber(text, _roundTexts.Count ); 
        }

        public void SetIncreaseRound()
        {
            CreateRoundText();
            float startTop = _roundTextPanel.offsetMax.y;
            float startBottom = _roundTextPanel.offsetMin.y;

            float targetTop = startTop - _progressRoundData.RoundTextDistance; 
            float targetBottom = startBottom + _progressRoundData.RoundTextDistance;

            DOTween.To(() => _roundTextPanel.offsetMax.y, x => _roundTextPanel.offsetMax =
                new Vector2(_roundTextPanel.offsetMax.x, x), targetTop, _progressRoundData.RoundTourDuration);

            DOTween.To(() => _roundTextPanel.offsetMin.y, x => _roundTextPanel.offsetMin =
                new Vector2(_roundTextPanel.offsetMin.x, x), targetBottom, _progressRoundData.RoundTourDuration);
        }
        
        private void UpdateTextColorBasedOnNumber(TextMeshProUGUI text, int number)
        {
            if (number % 30 == 0)
            {
                text.font = _progressRoundData.GoldenFont;
            }
            else if (number % 5 == 0)
            {
                text.font = _progressRoundData.SilverFont;

            }
        }

        private void ResetRoundProgress()
        {
            _roundTextPanel.offsetMin = new Vector2(0, _progressRoundData.RoundStartPositon);
            _roundTextPanel.offsetMax = new Vector2(0, -_progressRoundData.RoundStartPositon);
        }
        
        private void OnEnable()
        {
            EventManager.Subscribe(UIEvents.OnPlaySpin,SetIncreaseRound);
            EventManager.Subscribe(PanelType.FailedPanel,ResetRoundProgress);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(UIEvents.OnPlaySpin,SetIncreaseRound);
            EventManager.Subscribe(PanelType.FailedPanel,ResetRoundProgress);
        }

    }
}