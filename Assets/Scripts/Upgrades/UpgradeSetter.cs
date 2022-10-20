using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSetter : MonoBehaviour
{
    //NOT USED - Used for setting all of the children upgrades to each type object.

    [SerializeField] GameObject[] childUpgrades;

    public GameObject[] ChildUpgrades => childUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the length of the array.
        childUpgrades = new GameObject[3];
        SetChildren();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetChildren()
    {
        //Runs through all of the children objects (which are the specific upgrades), and adds them to the array in order.
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            childUpgrades[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
}
