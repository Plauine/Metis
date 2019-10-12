using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Metis.Stats
{
    public class StatBarsController : MonoBehaviour
    {
        [SerializeField]
        private Slider _backSlider;

        [SerializeField]
        private Slider _frontSlider;

        [SerializeField]
        private Image _backImage;

        private float _currentValue;

        private bool _backSliderNeedsUpdate, _frontSliderNeedsUpdate;

        public void CheckAndUpdate(float newValue, bool isFirst)
        {
            newValue /= 100;

            // if it is the initialisation
            if (isFirst)
            {
                _frontSlider.value = 0;
                _backSlider.value = newValue;
                _currentValue = newValue;
                _backImage.color = Color.white;
                return;
            }

            // The back slider always takes the biggest value between the current and the new value
            _backSlider.value = Mathf.Max(_currentValue, newValue);

            // The fron slider take the smallest one
            _frontSlider.value = Mathf.Min(_currentValue, newValue);

            // The color of the back image depends on weather the current value is equal, strictly superior or inferior to the new value
            _backImage.color = _currentValue == newValue ? Color.white : _currentValue > newValue ? Color.red : Color.green;

            _backSliderNeedsUpdate = _currentValue != newValue;
        }
    }
}