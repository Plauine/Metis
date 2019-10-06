using Metis.ItemMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Metis.Stats
{
    public class AllStatsUpdator : MonoBehaviour
    {
        [SerializeField] private Slider _movingSpeedSlider, _protectionSlider, _hitForceSlider, _jumpForceSlider;

        public static AllStatsUpdator Instance;

        private void Awake()
        {
            Instance = this;
            UpdateValues();
        }

        public static void UpdateValues()
        {
            if (Instance == null)
                return;

            Instance._movingSpeedSlider.value = CurrentlyWornWearables._totalModifiers[ModifierType.MOVING_SPEED];
            Instance._protectionSlider.value = CurrentlyWornWearables._totalModifiers[ModifierType.PROTECTION];
            Instance._hitForceSlider.value = CurrentlyWornWearables._totalModifiers[ModifierType.HIT_FORCE];
            Instance._jumpForceSlider.value = CurrentlyWornWearables._totalModifiers[ModifierType.JUMP_FORCE];
        }
    }
}