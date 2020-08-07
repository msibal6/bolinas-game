using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartManager : MonoBehaviour
{
    private GameManager manager;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void NextStage()
    {
        //print("changing ot the next stage in the game");
        GameManager.instance.NextStage();
    }
}
