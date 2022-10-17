using UnityEngine;
using TMPro;
using System;

public class ResourceUpdater : MonoBehaviour
{
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
        if (!planetDetails.Planet.IsLocked && planetDetails.PlanetCam.isActiveAndEnabled)
        {
            PlanetUpdater();
        }
    }

    public void PlanetUpdater()
    {
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
        totalResourceUI.SetActive(false);
        resourceUI.SetActive(true);

        text.SetText(name);
    }

    public void PlanetExit()
    {
        totalResourceUI.SetActive(true);
        resourceUI.SetActive(false);

        for (int i = 0; i < planetDetails.Resource.ResourceAmounts; i++)
        {
            TMP_Text textMeshPro = resourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            textMeshPro.SetText("0");
        }
    }
}
