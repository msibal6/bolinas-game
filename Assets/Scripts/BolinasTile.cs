using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolinasTile : MonoBehaviour
{
    enum TrafficStatus { Light, Medium, Heavy};
    public List<BolinasTile> neighbors;
    private TrafficStatus trafficStatus;
    private bool onFire;
    private bool blocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        print("colliding with " + collider2D.gameObject.name);
        neighbors.Add(collider2D.gameObject.GetComponent<BolinasTile>());
    }

    private void OnMouseDown()
    {
        print("this is where you live" + gameObject.name);
        // go to the next round of information grab
        // Create the different map divisions to show
        // where the person live 
        GameObject text = GameObject.Find("location question");
        text.GetComponent<Text>().text = gameObject.name;
    }

}
