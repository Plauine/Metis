using System.Collections.Generic;

namespace Metis.ItemMenu
{
    public static class CurrentlyWornWearables
    {
        private static Dictionary<WearableType, Wearable> _currentlyWorn = new Dictionary<WearableType, Wearable>() {
            { WearableType.HELMET, null},
            { WearableType.TOP, null},
            { WearableType.PANTS, null},
            { WearableType.SHOES, null},
            { WearableType.WEAPON, null},
        };

        private static Dictionary<WearableType, Wearable> _currentlyTried = new Dictionary<WearableType, Wearable>() {
            { WearableType.HELMET, null},
            { WearableType.TOP, null},
            { WearableType.PANTS, null},
            { WearableType.SHOES, null},
            { WearableType.WEAPON, null},
        };

        public static Dictionary<ModifierType, float> TotalModifiersApplied = new Dictionary<ModifierType, float>()
        {
            { ModifierType.HIT_FORCE, 0},
            { ModifierType.JUMP_FORCE, 0},
            { ModifierType.MOVING_SPEED, 0},
            { ModifierType.PROTECTION, 0},
        };

        public static Dictionary<ModifierType, float> TotalModifiersTried = new Dictionary<ModifierType, float>()
        {
            { ModifierType.HIT_FORCE, 0},
            { ModifierType.JUMP_FORCE, 0},
            { ModifierType.MOVING_SPEED, 0},
            { ModifierType.PROTECTION, 0},
        };

        public static void ApplyOutfit()
        {
            _currentlyWorn = _currentlyTried;
            UpdateTotalModifiersApplied();
        }

        public static void TryOnNewWearable(Wearable newWearable)
        {
            _currentlyTried[newWearable.Type]?.WearableGameObject?.SetActive(false);
            _currentlyTried[newWearable.Type] = newWearable;
            newWearable.WearableGameObject?.SetActive(true);
            UpdateTotalModifiersTried();
            Stats.AllStatsUpdator.UpdateTried();
        }

        private static void UpdateTotalModifiersApplied()
        {
            UpdateDictionary(ref TotalModifiersApplied, _currentlyWorn);
        }

        private static void UpdateDictionary(ref Dictionary<ModifierType, float> dicoToUpdate, Dictionary<WearableType, Wearable> reference)
        {
            dicoToUpdate.Clear();
            foreach (var wearable in reference.Values)
            {
                if (wearable == null)
                    continue;

                foreach (Modifier modifier in wearable?.Modifiers)
                {
                    if (dicoToUpdate.ContainsKey(modifier.Type))
                    {
                        dicoToUpdate[modifier.Type] += modifier.Value;
                    }
                    else
                    {
                        dicoToUpdate.Add(modifier.Type, modifier.Value);
                    }
                }
            }
        }

        private static void UpdateTotalModifiersTried()
        {
            UpdateDictionary(ref TotalModifiersTried, _currentlyTried);
        }
    }
}