﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO  This class would have been used to monitor the fire and see if the player can still progress to the highway

public class FireTracker : MonoBehaviour
{
    public BolinasTile[] mainRoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BolinasTile road in mainRoad) {
            if (road.onFire) {
                // TODO the player cannot pass through here
                // Send message if they have the proper communication
                // Can be sent through radio
                // Text
                // or other people????
            }
        }
    }
}
