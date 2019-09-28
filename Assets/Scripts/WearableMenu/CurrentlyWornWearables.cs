using System.Collections.Generic;
using UnityEngine;

namespace Metis.ItemMenu
{
    public static class CurrentlyWornWearables
    {
        private static Dictionary<WearableType, GameObject> _currentlyWorn = new Dictionary<WearableType, GameObject>();

        public static void PutOnNewWearable(Wearable newWearable)
        {
            _currentlyWorn[newWearable.Type]?.SetActive(false);
            _currentlyWorn[newWearable.Type] = newWearable.WearableGameObject;
            newWearable.WearableGameObject?.SetActive(true);
        }
    }
}