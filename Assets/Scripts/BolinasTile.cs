using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BolinasTile : MonoBehaviour
{
    enum TrafficStatus { Light, Medium, Heavy};
    public BolinasTile[] neighbors;
    public int offset { get; private set; }
    private TrafficStatus trafficStatus;
    public bool onFire { get; private set;}
    private bool blocked;

    public void SetOffset(int newOffset) {
        offset = newOffset;
    }

    public bool DangerFromFire() {
        foreach (BolinasTile neighbor in neighbors) {
            if (neighbor != null && neighbor.onFire)
                return true;
        }
        return onFire;
    }

    public void SetFire() {
        onFire = true;
    }

    public void Extinguish() {
        onFire = false;
    }


    private void OnMouseDown() {
        //print("this is where you live" + gameObject.name);
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
