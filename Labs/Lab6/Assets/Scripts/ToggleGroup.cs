using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    public Toggle[] toggles;

    public void OnToggleValueChanged(Toggle changedToggle)
    {
        if (changedToggle.isOn)
        {
            foreach (var toggle in toggles)
            {
                if (toggle != changedToggle)
                {
                    toggle.isOn = false;
                }
            }
        }
    }
}