using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public bool local;
    public bool independent;
    public bool plannedAhead;
    public string surroundings;
    public string activity;
    public string bolinasTile;
    // work on mapping bolinas map to the world space and creating your pinpointed location
    public int groupSize;
    public string vehicle;

    // private Transportation[] transportations
    // private Communication[] communications

    public Person()
    {
       
    }

    public Person(Person person) {
    bolinasTile = person.bolinasTile;
        local = person.local;
        independent = person.independent;
        plannedAhead = person.plannedAhead;
        surroundings = person.surroundings;
        activity = person.activity;
        bolinasTile = person.bolinasTile;
        groupSize = person.groupSize;
        vehicle = person.vehicle;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
