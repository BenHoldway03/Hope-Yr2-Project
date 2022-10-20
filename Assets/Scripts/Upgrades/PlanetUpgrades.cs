using System;
using UnityEngine;

[Serializable]
public class PlanetUpgrades
{
    //NOT USED - Used to hold the different upgrades for the Planets.

    [SerializeField] bool tier1;
    [SerializeField] bool tier2;
    [SerializeField] bool tier3;

    public bool Tier1
    {
        get { return tier1; }
        set { tier1 = value; }
    }

    public bool Tier2
    {
        get { return tier2; }
        set { tier2 = value; }
    }

    public bool Tier3
    {
        get { return tier3; }
        set { tier3 = value; }
    }
}
