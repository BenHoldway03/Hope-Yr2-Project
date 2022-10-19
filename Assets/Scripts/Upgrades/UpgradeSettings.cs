using System;
using UnityEngine;

[Serializable]
public class UpgradeSettings
{
    [SerializeField] bool upgradeUnlocked;

    public bool UpgradeUnlocked
    {
        get { return upgradeUnlocked; }
        set { upgradeUnlocked = value; }
    }
}
