using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeColour : MonoBehaviour
{
    //NOT USED - Changes the colours of the upgrade boxes to show if they're unlocked or still locked.

    UpgradeSetter upgradeSetter;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the UpgradeSetter component from the parent of the upgrade object (what this script is attached to).
        upgradeSetter = transform.GetComponentInParent<UpgradeSetter>();
    }

    public void SetColour(GameObject upgrade)
    {
        int i = 0;
        UpgradeDetails upgradeDetails = upgrade.GetComponent<UpgradeDetails>();
        bool previousUpgradeUnlocked = true;

        //Gets the index of the upgrade object and checks to see if there is an upgrade beforehand.
        int index = Array.IndexOf(upgradeSetter.ChildUpgrades, upgrade);
        //If there are more upgrades beforehand, sets that upgrade to previousUpgrade and checks to see if its unlocked.
        if (index > 0)
        {
            UpgradeDetails previousUpgrade = upgradeSetter.ChildUpgrades[index - 1].gameObject.GetComponent<UpgradeDetails>();
            previousUpgradeUnlocked = previousUpgrade.UpgradeSettings.UpgradeUnlocked;
        }

        //Uses the previousUpgradeUnlocked check to determine if it is either the first upgrade, or the previous upgrade is unlocked.
        if (previousUpgradeUnlocked) {
            //Runs through all of the upgrades from the first one to the one clicked on and unlocks them.
            while (i <= Array.IndexOf(upgradeSetter.ChildUpgrades, upgrade))
            {
                //Gets the Image component to change the upgrade from a gray to a light blue (ish) colour.
                Image image = upgradeSetter.ChildUpgrades[i].gameObject.GetComponent<Image>();
                image.color = new Color(0, 227, 255, 255);
                //Sets the upgrade to unlocked.
                upgradeDetails.UpgradeSettings.UpgradeUnlocked = true;
                //Go to the next upgrade.
                i++;
            }
        }
    }
}