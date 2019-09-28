using System;
using System.Collections.Generic;
using UnityEngine;

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

        public static Dictionary<ModifierType, float> _totalModifiers = new Dictionary<ModifierType, float>();

        public static void PutOnNewWearable(Wearable newWearable)
        {
            _currentlyWorn[newWearable.Type]?.WearableGameObject?.SetActive(false);
            _currentlyWorn[newWearable.Type] = newWearable;
            newWearable.WearableGameObject?.SetActive(true);
            UpdateTotalModifiers();
            Stats.AllStatsUpdator.UpdateValues();
        }

        private static void UpdateTotalModifiers()
        {
            _totalModifiers.Clear();
            foreach(var wearable in _currentlyWorn.Values)
            {
                if (wearable == null)
                    continue;

                foreach(Modifier modifier in wearable?.Modifiers)
                {
                    if (_totalModifiers.ContainsKey(modifier.Type))
                    {
                        _totalModifiers[modifier.Type] += modifier.Value;
                    } else
                    {
                        _totalModifiers.Add(modifier.Type, modifier.Value);
                    }
                }
            }
        }
    }
}