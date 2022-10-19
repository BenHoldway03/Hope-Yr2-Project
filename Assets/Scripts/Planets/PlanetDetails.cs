using UnityEngine;
using TMPro;
using System;

public class PlanetDetails : MonoBehaviour
{
    public PlanetSettings Planet;
    [SerializeField] TMP_Text text;
    [SerializeField] Camera planetCam;
    [SerializeField] Resources resourse;
    ResourceUpdater resourceUpdater;

    /*public PlanetSettings Planet
    {
        get { return planet; }
        set { planet = value; }
    }*/
    public Camera PlanetCam => planetCam;
    public Resources Resource
    {
        get { return resourse; }
        set { resourse = value; }
    }

    public Action<string> onPlanetEnter;
    public Action onPlanetExit;

    // Start is called before the first frame update
    void Start()
    {
        /*if(planet.PlanetNum != 1)
        {
            planet.SetLocked(true);
        }
        else
        {
            planet.SetLocked(false);
        }*/

        resourceUpdater = GetComponent<ResourceUpdater>();
        resourceUpdater.onSetPlayerName += SetPlanetName;
    }

    private void OnMouseDown()
    {
        if (!planetCam.isActiveAndEnabled)
        {
            onPlanetEnter?.Invoke(Planet.PlanetName);
        }
        else
        {
            onPlanetExit?.Invoke();
        }
    }

    private void OnMouseOver()
    {
        SetPlanetName();
    }

    private void OnMouseExit()
    {
        text.SetText("");
    }

    //Shows the planet name wherever text is used
    void SetPlanetName()
    {
        text.SetText(Planet.PlanetName);
    }
}
