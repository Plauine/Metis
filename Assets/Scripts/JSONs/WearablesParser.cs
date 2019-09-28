using System.IO;
using UnityEngine;

namespace Metis.ItemMenu
{
    public class WearablesParser : MonoBehaviour
    {
        [SerializeField]
        private string _fileName;

        [SerializeField]
        private WearablesDispatcher _dispatcher;

        private void Awake()
        {
            // Create empty Wearables to have the character "Naked"
            var emptyModifiers = new Modifier[4]
            {
                new Modifier(ModifierType.HIT_FORCE, 0f),
                new Modifier(ModifierType.JUMP_FORCE, 0f),
                new Modifier(ModifierType.MOVING_SPEED, 0f),
                new Modifier(ModifierType.PROTECTION, 0f),
            };

            _dispatcher.Dispatch(new Wearable("HNONE", "No helmet", WearableType.HELMET, emptyModifiers, ""));
            _dispatcher.Dispatch(new Wearable("TNONE", "No top", WearableType.TOP, emptyModifiers, ""));
            _dispatcher.Dispatch(new Wearable("PNONE", "No trousers", WearableType.PANTS, emptyModifiers, ""));
            _dispatcher.Dispatch(new Wearable("SNONE", "No shoes", WearableType.SHOES, emptyModifiers, ""));

            StartParsingJSON();
        }

        public void StartParsingJSON()
        {
            string path = Application.streamingAssetsPath + "/" + _fileName;
            JSONObject jsonFile = new JSONObject(File.ReadAllText(path));
            var wearablesList = jsonFile.GetField("Wearables");

            for (int i = 0; i < wearablesList.list.Count; i++)
            {
                JSONObject wearableJSONObject = wearablesList.list[i];
                _dispatcher.Dispatch(CreateWearable(wearableJSONObject));
            }
        }

        private Wearable CreateWearable(JSONObject wearableJSONObject)
        {
            string id = GetStringWithoutQuotes(wearableJSONObject.GetField("ID").ToString());
            string name = GetStringWithoutQuotes(wearableJSONObject.GetField("Name").ToString());
            WearableType type = GetWearableTypeFromString(wearableJSONObject.GetField("Type").ToString());
            Modifier[] modifiers = GetModifiers(wearableJSONObject.GetField("Modifiers"));
            string spriteName = GetStringWithoutQuotes(wearableJSONObject.GetField("SpriteName").ToString());

            return new Wearable(id, name, type, modifiers, spriteName);
        }

        private Modifier[] GetModifiers(JSONObject modifiersJSONObject)
        {
            Modifier[] result = new Modifier[modifiersJSONObject.list.Count];

            for (int i = 0; i < modifiersJSONObject.list.Count; i++)
            {
                ModifierType type = GetModifierTypeFromString(modifiersJSONObject.list[i].GetField("Type").ToString());
                float value = GetFloatWithoutQuotes(modifiersJSONObject.list[i].GetField("Value").ToString());
                Modifier currentModifier = new Modifier(type, value);
                result[i] = currentModifier;
            }
            return result;
        }

        public static ModifierType GetModifierTypeFromString(string modifierTypeString)
        {
            switch (GetStringWithoutQuotes(modifierTypeString))
            {
                case "HIT_FORCE":
                    return ModifierType.HIT_FORCE;
                case "JUMP_FORCE":
                    return ModifierType.JUMP_FORCE;
                case "MOVING_SPEED":
                    return ModifierType.MOVING_SPEED;
                case "PROTECTION":
                    return ModifierType.PROTECTION;
                default:
                    return ModifierType.NONE;
            }
        }

        public static WearableType GetWearableTypeFromString(string value)
        {
            switch (GetStringWithoutQuotes(value))
            {
                case "HELMET":
                    return WearableType.HELMET;
                case "TOP":
                    return WearableType.TOP;
                case "TROUSERS":
                    return WearableType.PANTS;
                case "SHOES":
                    return WearableType.SHOES;
                case "WEAPON":
                    return WearableType.WEAPON;
                default:
                    return WearableType.NONE;
            }
        }

        public static string GetStringWithoutQuotes(string value)
        {
            return value.Replace("\"", "");
        }

        public static float GetFloatWithoutQuotes(string value)
        {
            if (float.TryParse(GetStringWithoutQuotes(value), out float result))
            {
                return result;
            }
            return -1;

        }
    }
}