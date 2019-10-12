using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Metis.ItemMenu
{
    public class WearableStatsFeeder : MonoBehaviour
    {
        [SerializeField]
        private WearableType _type;

        [SerializeField]
        private TextMeshProUGUI _nameValue;

        [SerializeField]
        private TextMeshProUGUI _movingSpeedValue;

        [SerializeField]
        private TextMeshProUGUI _protectionValue;

        [SerializeField]
        private TextMeshProUGUI _hitForceValue;

        [SerializeField]
        private TextMeshProUGUI _jumpForceValue;

        [SerializeField]
        private Image _visual;

        public void FeedStatsValues(Wearable newWearable)
        {
            _nameValue.text = newWearable.Name;
            _movingSpeedValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.MOVING_SPEED);
            _protectionValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.PROTECTION);
            _hitForceValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.HIT_FORCE);
            _jumpForceValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.JUMP_FORCE);
            _visual.sprite = Resources.Load<Sprite>("ClothSprites/" + newWearable.SpriteName);

            CurrentlyWornWearables.TryOnNewWearable(newWearable);
        }

        private string GetModifierValue(Modifier[] array, ModifierType type)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Type == type)
                    return array[i].Value.ToString();
            }
            return "N/A";
        }
    }
}