using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Metis.ItemMenu
{
    public class WearableFeeder : MonoBehaviour
    {
        [SerializeField]
        private WearableType _type;

        [SerializeField]
        private WearableStatsFeeder _wearableStats;

        [SerializeField]
        private Image _visualImage;

        private List<Wearable> _wearables = new List<Wearable>();

        private int currentIndex;

        public void AddWearable(Wearable newWearable)
        {
            if (newWearable.Type == _type)
            {
                _wearables.Add(newWearable);
                if (_wearables.Count == 1)
                    SelectDefault();
            }
        }

        private void SelectDefault()
        {
            currentIndex = 0;
            _wearableStats.FeedStatsValues(_wearables[0]);
        }

        public void OnNewWearableSelected(int indexModifier)
        {
            if (_wearables.Count == 1)
                return;

            _wearableStats.FeedStatsValues(_wearables[GetNewIndex(indexModifier)]);
        }

        private int GetNewIndex(int indexModifier)
        {
            currentIndex += indexModifier;
            if (currentIndex == -1)
                currentIndex = _wearables.Count - 1;
            else if (currentIndex == _wearables.Count)
                currentIndex = 0;
            return currentIndex;
        }
    }
}