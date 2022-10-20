using System;
using UnityEngine;

[Serializable]
public class ResourceIncrease
{
    //Holds all the increase amounts of the resources on each Planet.

    [SerializeField] float materialIncrease;
    [SerializeField] float foodIncrease;
    [SerializeField] float populationIncrease;

    public float MaterialIncrease
    {
        get { return materialIncrease; }
        set { materialIncrease = value; }
    }

    public float FoodIncrease
    {
        get { return foodIncrease; }
        set { foodIncrease = value; }
    }

    public float PopulationIncrease
    {
        get { return populationIncrease; }
        set { populationIncrease = value; }
    }
}
