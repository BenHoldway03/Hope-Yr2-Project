using System;
using UnityEngine;

[Serializable]
public class UpgradeSettings
{
    //NOT USED - holds the settings for the upgrades.

    [SerializeField] bool upgradeUnlocked;

    public bool UpgradeUnlocked
    {
        get { return upgradeUnlocked; }
        set { upgradeUnlocked = value; }
    }
}