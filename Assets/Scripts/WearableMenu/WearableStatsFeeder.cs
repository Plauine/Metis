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
            _movingSpeedValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.MOVING_SPEED).ToString();
            _protectionValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.PROTECTION).ToString();
            _hitForceValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.HIT_FORCE).ToString();
            _jumpForceValue.text = GetModifierValue(newWearable.Modifiers, ModifierType.JUMP_FORCE).ToString();
            _visual.sprite = Resources.Load<Sprite>("ClothSprites/" + newWearable.SpriteName);

            CurrentlyWornWearables.PutOnNewWearable(newWearable);
        }

        private float GetModifierValue(Modifier[] array, ModifierType type)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Type == type)
                    return array[i].Value;
            }
            return -1.0f;
        }
    }
}