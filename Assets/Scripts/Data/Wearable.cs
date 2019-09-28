using UnityEngine;

namespace Metis.ItemMenu
{
    public class Wearable
    {
        public string ID;

        public string Name;

        public GameObject WearableGameObject;

        public WearableType Type;

        public Modifier[] Modifiers;

        public string SpriteName;

        public Wearable(string id, string name, WearableType type, Modifier[] modifiers, string spriteName)
        {
            ID = id;
            Name = name;
            WearableGameObject = WearablesInScene.GetGameObject(id);
            Type = type;
            Modifiers = modifiers;
            SpriteName = spriteName;
        }

        public override string ToString()
        {
            return ID + " - " + Name;
        }
    }
}