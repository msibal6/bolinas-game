﻿

public class Person
{
    public bool local;
    public bool independent;
    public bool plannedAhead;
    public bool evacReady;
    public string surroundings;
    public string activity;
    public string bolinasTile;
    // work on mapping bolinas map to the world space and creating your pinpointed location
    public int groupSize;
    public string transportation;

    // TODO 
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
        transportation = person.transportation;
    }
}
