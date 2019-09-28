using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Metis.ItemMenu
{
    /// <summary>
    /// Script to collect the wearables of the character
    /// </summary>
    public class WearablesInScene : MonoBehaviour
    {
        private static Dictionary<string, GameObject> _helmets = new Dictionary<string, GameObject>();
        private static Dictionary<string, GameObject> _tops = new Dictionary<string, GameObject>();
        private static Dictionary<string, GameObject> _pants = new Dictionary<string, GameObject>();
        private static Dictionary<string, GameObject> _shoes = new Dictionary<string, GameObject>();
        private static Dictionary<string, GameObject> _weapon = new Dictionary<string, GameObject>();

        private const string REGEX_PATTERN = @"^[HTPSW][0-9]{2}$";

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                if(Regex.IsMatch(child.name, REGEX_PATTERN))
                {
                    GetDictionary(child.name.ToCharArray()[0]).Add(child.name, child.gameObject);
                    child.gameObject.SetActive(false);
                }
            }
        }

        private static Dictionary<string, GameObject> GetDictionary(char firstLetter)
        {
            switch (firstLetter)
            {
                case 'H':
                    return _helmets;
                case 'T':
                    return _tops;
                case 'P':
                    return _pants;
                case 'S':
                    return _shoes;
                case 'W':
                    return _weapon;
                default:
                    return null;
            }
        }

        public static GameObject GetGameObject(string wearableID)
        {
            var dico = GetDictionary(wearableID.ToCharArray()[0]);
            if (dico.ContainsKey(wearableID))
                return dico[wearableID];
            else return null;
        }
    }
}