using Metis.ItemMenu;
using UnityEngine;

namespace Metis.Stats
{
    public class OutfitApplier : MonoBehaviour
    {
        public void ApplyOutfit()
        {
            CurrentlyWornWearables.ApplyOutfit();
            AllStatsUpdator.UpdateApplied(true);
        }
    }
}