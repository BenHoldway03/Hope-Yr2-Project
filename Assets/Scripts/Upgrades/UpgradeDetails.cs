using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDetails : MonoBehaviour
{
    //NOT USED - Holds the details about the specific upgrades.

    [SerializeField] UpgradeSettings upgradeSettings;

    public UpgradeSettings UpgradeSettings
    {
        get { return upgradeSettings; }
        set { upgradeSettings = value; }  
    }
}
