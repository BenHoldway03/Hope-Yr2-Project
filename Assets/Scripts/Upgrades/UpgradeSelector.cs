using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelector : MonoBehaviour
{
    [SerializeField] GameObject[] childUpgrades;

    public GameObject[] ChildUpgrades => childUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        childUpgrades = new GameObject[3];
        SetChildren();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetChildren()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            childUpgrades[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
}
