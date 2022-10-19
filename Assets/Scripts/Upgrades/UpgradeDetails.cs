using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDetails : MonoBehaviour
{
    [SerializeField] UpgradeSettings upgradeSettings;

    public UpgradeSettings UpgradeSettings
    {
        get { return upgradeSettings; }
        set { upgradeSettings = value; }  
    }
}
