using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metis.ItemMenu
{
    public class WearablesDispatcher : MonoBehaviour
    {
        [SerializeField]
        private WearableFeeder _helmetFeeder, _topFeeder, _trousersFeeder, _shoesFeeder;

        private WearableFeeder GetFeeder(WearableType type)
        {
            switch (type)
            {
                case WearableType.HELMET:
                    return _helmetFeeder;
                case WearableType.TOP:
                    return _topFeeder;
                case WearableType.PANTS:
                    return _trousersFeeder;
                case WearableType.SHOES:
                    return _shoesFeeder;
                default:
                    return null;
            }
        }

        public void Dispatch(Wearable wearable)
        {
            GetFeeder(wearable.Type).AddWearable(wearable);
        }
    }
}