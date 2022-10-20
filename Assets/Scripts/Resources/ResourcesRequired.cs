using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesRequired : MonoBehaviour
{
    //Sets the Resource numbers to the needed amount for locked Planets.

    PlanetDetails planetDetails;
    PlanetUnlock planetUnlock;
    [SerializeField] GameObject resourceTextParent;

    // Start is called before the first frame update
    void Start()
    {
        planetDetails = GetComponent<PlanetDetails>();
        planetUnlock = GetComponent<PlanetUnlock>();
    }

    // Update is called once per frame
    void Update()
    {
        //Method is called if the Planet is locked and the PlanetCam is active
        if (planetDetails.Planet.IsLocked && planetDetails.PlanetCam.isActiveAndEnabled)
        {
            RequiredResources();
        }
    }

    void RequiredResources()
    {
        //Runs through all of the resource texts and sets the whole number of the resources needed to unlock the Planet to the Text Mesh Pro text.
        for (int i = 0; i < planetDetails.Resource.ResourceAmounts; i++)
        {
            TMP_Text textMeshPro = resourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            switch (i)
            {
                case 0:
                    textMeshPro.SetText(planetUnlock.ResourcesNeeded.MaterialNeeded.ToString("F0"));
                    break;
                case 1:
                    textMeshPro.SetText(planetUnlock.ResourcesNeeded.FoodNeeded.ToString("F0"));
                    break;
                case 2:
                    textMeshPro.SetText(planetUnlock.ResourcesNeeded.PopulationNeeded.ToString("F0"));
                    break;
                default:
                    break;
            }
        }
    }
}
