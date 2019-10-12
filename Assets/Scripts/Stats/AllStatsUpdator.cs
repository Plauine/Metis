using Metis.ItemMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Metis.Stats
{
    public class AllStatsUpdator : MonoBehaviour
    {
        [SerializeField] private Stats.StatBarsController _movingSpeedController, _protectionController, _hitForceController, _jumpForceController;

        public static AllStatsUpdator Instance;

        private void Awake()
        {
            Instance = this;
            UpdateApplied(true);
        }

        public static void UpdateApplied(bool isFirst = false)
        {
            if (Instance == null)
                return;

            Instance._movingSpeedController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersApplied[ModifierType.MOVING_SPEED], isFirst);
            Instance._protectionController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersApplied[ModifierType.PROTECTION], isFirst);
            Instance._hitForceController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersApplied[ModifierType.HIT_FORCE], isFirst);
            Instance._jumpForceController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersApplied[ModifierType.JUMP_FORCE], isFirst);
        }

        public static void UpdateTried(bool isFirst = false)
        {
            if (Instance == null)
                return;

            Instance._movingSpeedController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersTried[ModifierType.MOVING_SPEED], isFirst);
            Instance._protectionController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersTried[ModifierType.PROTECTION], isFirst);
            Instance._hitForceController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersTried[ModifierType.HIT_FORCE], isFirst);
            Instance._jumpForceController.CheckAndUpdate(CurrentlyWornWearables.TotalModifiersTried[ModifierType.JUMP_FORCE], isFirst);
        }
    }
}