using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    private int infoStage;
    public GameObject bolinasMap;
    public Button nextButton;
    public Person person;
    public MuggleGroup origin;
    public MuggleGroup helpStatus;
    public MuggleGroup plan;
    public InputField partySize;
    public Dropdown vehicleType;


    public GameObject[] infoPrompts;

    private void Update()
    {
        if (infoStage == 0) {

        }


    }
    // Changes the questions to the next round 
    public void NextInfo()
    {
        // changing after the first info stage
        if (infoStage == 0)
        {
            bolinasMap.SetActive(false);
        }
        else if (infoStage == 1)
        {

        }

        infoPrompts[infoStage].SetActive(false);
        infoStage++;
        infoPrompts[infoStage].SetActive(true);
    }


    

}
