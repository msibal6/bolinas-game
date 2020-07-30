using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    private int infoStage;
    public GameObject bolinasMap;
    public GameObject[] infoPrompts;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Changes the questions to the next round 
    public void NextInfo()
    {
        if (infoStage == 0) {
            bolinasMap.SetActive(false);
        }
        infoPrompts[infoStage].SetActive(false);

        infoStage++;

        infoPrompts[infoStage].SetActive(true);
    }


    

}
