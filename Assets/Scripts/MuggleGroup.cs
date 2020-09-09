using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuggleGroup : MonoBehaviour
{
    public bool allowSwitchOff;
    public Toggle activeToggle;
    public Toggle[] toggles;
    public InfoManager infoManager;
    public string personInfoField;

    // My Toggle Group class to easily read which toggle was on in toggle group
    void Start() {
        personInfoField = gameObject.name;

        foreach (Toggle toggle in toggles) {
            toggle.onValueChanged.AddListener(delegate { UpdateToggles(toggle); } );
            StartToggle(toggle);
        }
    }
   
    public void UpdateToggles(Toggle changedToggle) {

        if (changedToggle.isOn) {
            activeToggle = changedToggle;

            foreach (Toggle toggle in toggles) {

                if (toggle != activeToggle) {
                    toggle.isOn = false;    
                } else {
                    infoManager.SendMessage("UpdateMuggle", personInfoField);
                }
            }
        } else if (changedToggle.isOn == false && changedToggle == activeToggle && allowSwitchOff == false) {
            changedToggle.isOn = true;
        }
    }

    private void StartToggle(Toggle toggle) {

        if (toggle.isOn && activeToggle == null) {
            activeToggle = toggle;
            infoManager.SendMessage("UpdateMuggle", personInfoField);

        }
    }
}
