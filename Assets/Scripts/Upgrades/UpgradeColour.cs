using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeColour : MonoBehaviour
{
    UpgradeSelector upgradeSelector;

    // Start is called before the first frame update
    void Start()
    {
        upgradeSelector = transform.GetComponentInParent<UpgradeSelector>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetColour(GameObject upgrade)
    {
        int i = 0;
        UpgradeDetails upgradeDetails = upgrade.GetComponent<UpgradeDetails>();

        do
        {
            //get previous upgrade and check to see if its unlocked, unless its the first upgrade (not working)
            UpgradeDetails upgradeDetails1 = upgradeSelector.ChildUpgrades[i-1].gameObject.GetComponent<UpgradeDetails>();

            if (upgrade != null && !upgradeDetails.UpgradeSettings.UpgradeUnlocked && upgradeDetails1.UpgradeSettings.UpgradeUnlocked) {
                Image image = upgradeSelector.ChildUpgrades[i].gameObject.GetComponent<Image>();
                image.color = new Color(0, 227, 255, 255);
                i++;
            }
        }
        while (i <= Array.IndexOf(upgradeSelector.ChildUpgrades, upgrade));
    }
}
