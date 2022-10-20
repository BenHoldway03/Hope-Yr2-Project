using System;
using UnityEngine;

[Serializable]
public class Resources
{
    //Holds the amounts of resources on each Planet.

    [SerializeField] int resourceAmounts = 3;

    [SerializeField] float materialAmount;
    [SerializeField] float foodAmount;
    [SerializeField] float populationAmount;

    public int ResourceAmounts => resourceAmounts;
    public float MaterialAmount
    {
        get { return materialAmount; }
        set { materialAmount = value; }
    }

    public float FoodAmount
    {
        get { return foodAmount; }
        set { foodAmount = value; }
    }

    public float PopulationAmount
    {
        get { return populationAmount; }
        set { populationAmount = value; }
    }
}
