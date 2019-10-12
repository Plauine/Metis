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

        private float _currentValue, _originalBackValue, _originalFrontValue, _nextBackValue, _nextFrontValue, _stepBackSlider, _stepFrontSlider, _speed = 2.5f;

        private bool _backSliderNeedsUpdate, _frontSliderNeedsUpdate;

        public void CheckAndUpdate(float newValue, bool isFirst)
        {
            // if it is the initialisation
            if (isFirst)
            {
                _currentValue = newValue;
            }
            else
                // The color of the back image depends on weather the current value is equal, strictly superior or inferior to the new value
                _backImage.color = _currentValue > newValue ? Color.red : Color.green;

            // The back slider always takes the biggest value between the current and the new value
            _nextBackValue = isFirst ? newValue : Mathf.Max(_currentValue, newValue);
            if(_nextBackValue != _backSlider.value)
            {
                _originalBackValue = _backSlider.value;
                _backSliderNeedsUpdate = true;
                _stepBackSlider = 0;
            }

            _nextFrontValue = isFirst ? newValue : Mathf.Min(_currentValue, newValue);
            if (_nextFrontValue != _frontSlider.value)
            {
                _originalFrontValue = _frontSlider.value;
                _frontSliderNeedsUpdate = true;
                _stepFrontSlider = 0;
            }

        }

        private void Update()
        {
            if (_backSliderNeedsUpdate)
            {
                _backSlider.value = Mathf.Lerp(_originalBackValue, _nextBackValue, _stepBackSlider);
                _stepBackSlider += _speed * Time.deltaTime;

                if (_backSlider.value == _nextBackValue)
                    _backSliderNeedsUpdate = false;
            }

            if (_frontSliderNeedsUpdate)
            {
                _frontSlider.value = Mathf.Lerp(_originalFrontValue, _nextFrontValue, _stepFrontSlider);
                _stepFrontSlider += _speed * Time.deltaTime;

                if (_frontSlider.value == _nextFrontValue)
                    _frontSliderNeedsUpdate = false;
            }
        }
    }
}