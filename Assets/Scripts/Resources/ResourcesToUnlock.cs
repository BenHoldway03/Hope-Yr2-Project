using System;
using UnityEngine;

[Serializable]
public class ResourcesToUnlock 
{
    //Holds the amount of resources need to unlock a locked Planet.

    [SerializeField] float materialNeeded;
    [SerializeField] float foodNeeded;
    [SerializeField] float populationNeeded;

    public float MaterialNeeded
    {
        get { return materialNeeded; }
        set { materialNeeded = value; }
    }

    public float FoodNeeded
    {
        get { return foodNeeded; }
        set { foodNeeded = value; }
    }

    public float PopulationNeeded
    {
        get { return populationNeeded; }
        set { populationNeeded = value; }
    }

}
