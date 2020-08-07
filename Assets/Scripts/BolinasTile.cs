using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BolinasTile : MonoBehaviour
{
    enum TrafficStatus { Light, Medium, Heavy};
    public BolinasTile[] neighbors;
    private int offset;
    private TrafficStatus trafficStatus;
    private bool onFire;
    private bool blocked;

    public void SetOffset(int newOffset) {
        offset = newOffset;
    }

    public int GetOffset() {
        return offset;
    }
     

    private void OnMouseDown()
    {
        print("this is where you live" + gameObject.name);
        GameObject text = GameObject.Find("location question");
        text.GetComponent<Text>().text = gameObject.name;

        // location grab of where the player is
        // TODO add location grab of where the rest of their evacutation party is
        if (SceneManager.GetActiveScene().name == "info grab") {
            InfoManager infoManager = FindObjectOfType<InfoManager>();
            infoManager.person = new Person {
                bolinasTile = gameObject.GetComponent<BolinasTile>().name
            };
            print(infoManager.person.bolinasTile);
        }
    }

}
