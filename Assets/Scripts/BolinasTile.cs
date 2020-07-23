using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("colliding with " + collision.gameObject.name);
        neighbors.Add(collision.gameObject.GetComponent<BolinasTile>());
    }
}
