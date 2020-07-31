using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuggleGroup : MonoBehaviour
{
    public bool allowSwitchOff;
    public Toggle activeToggle;
    public Toggle[] toggles;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate { UpdateToggle(toggle); } );
            CheckToggle(toggle);
        }
    }

    
    public void UpdateToggle(Toggle changedToggle)
    {
        if (changedToggle.isOn)
        {
            activeToggle = changedToggle;
            foreach (Toggle toggle in toggles)
            {
                if (toggle != activeToggle)
                {
                    toggle.isOn = false;    
                }
            }
        }
    }

    private void CheckToggle(Toggle toggle)
    {
        if (toggle.isOn && activeToggle == null)
        {
            activeToggle = toggle;
        }
    }
}
