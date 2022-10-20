using UnityEngine;
using TMPro;
using System;

public class ResourceUpdater : MonoBehaviour
{
    //Updates the resources seen on the screen.

    [SerializeField] GameObject planets;

    [SerializeField] GameObject resourceUI;
    [SerializeField] GameObject resourceTextParent;
    [SerializeField] GameObject totalResourceUI;
    [SerializeField] TMP_Text text;

    PlanetDetails planetDetails;

    public Action onSetPlayerName;

    private void Awake()
    {
        planetDetails = GetComponent<PlanetDetails>();
        planetDetails.onPlanetEnter += PlanetEnter;
        planetDetails.onPlanetExit += PlanetExit;

        PlanetExit();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to make sure the Planet is unlocked and the PlanetCam is active before updating the resources.
        if (!planetDetails.Planet.IsLocked && planetDetails.PlanetCam.isActiveAndEnabled)
        {
            PlanetUpdater();
        }
    }

    public void PlanetUpdater()
    {
        //Runs through all of the resource texts and sets the whole number of the resource amount to the Text Mesh Pro text.
        for (int i = 0; i < planetDetails.Resource.ResourceAmounts; i++)
        {
            TMP_Text textMeshPro = resourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            switch (i)
            {
                case 0:
                    textMeshPro.SetText(planetDetails.Resource.MaterialAmount.ToString("F0"));
                    break;
                case 1:
                    textMeshPro.SetText(planetDetails.Resource.FoodAmount.ToString("F0"));
                    break;
                case 2:
                    textMeshPro.SetText(planetDetails.Resource.PopulationAmount.ToString("F0"));
                    break;
                default:
                    break;
            }
        }
    }

    public void PlanetEnter(string name)
    {
        //Hides the total resource UI and shows the Planet specific resource UI, and also sets the name of the Planet as the text.
        totalResourceUI.SetActive(false);
        resourceUI.SetActive(true);

        text.SetText(name);
    }

    public void PlanetExit()
    {
        //Shows the total resource UI and hides the Planet specific resource UI
        totalResourceUI.SetActive(true);
        resourceUI.SetActive(false);

        //Sets all of the resource texts to 0 so that if a Planet that is still locked is viewed, the text shows 0.
        for (int i = 0; i < planetDetails.Resource.ResourceAmounts; i++)
        {
            TMP_Text textMeshPro = resourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            textMeshPro.SetText("0");
        }
    }
}
