using UnityEngine;
using UnityEngine.UI;

public class StatBarsController : MonoBehaviour
{
    private readonly float maxValue = 100;
    [SerializeField] private Image _statBar, _modifierBar;

    private void Awake()
    {
        SetupBar(50f, 3f);
    }

    private void SetupBar(float currentValue, float modifierValue)
    {
        _statBar.fillAmount = currentValue / maxValue;
        _modifierBar.fillAmount = modifierValue / maxValue;
    }
}
