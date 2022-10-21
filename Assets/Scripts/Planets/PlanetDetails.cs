using UnityEngine;
using TMPro;
using System;

public class PlanetDetails : MonoBehaviour
{
    //Holds the specific details of each planet and any Serializable Classes that are linked to the Planets.

    //This script reference variables are set to public as the error of "Unsupported Type" came up when I tried to use a setter and getter to access them.
    public PlanetSettings Planet;

    [SerializeField] TMP_Text text;
    [SerializeField] Camera planetCam;
    [SerializeField] Resources resourse;
    ResourceUpdater resourceUpdater;

    public Camera PlanetCam => planetCam;
    public Resources Resource
    {
        get { return resourse; }
        set { resourse = value; }
    }

    //These actions run when the Planet is selected and deselected.
    public Action<string> onPlanetEnter;
    public Action onPlanetExit;

    // Start is called before the first frame update
    void Start()
    {
        resourceUpdater = GetComponent<ResourceUpdater>();
        resourceUpdater.onSetPlayerName += SetPlanetName;
    }

    private void OnMouseDown()
    {
        //Determines whether the Planet is being selected or deselected depending on whether the PlanetCam is enabled or not.
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
        //Executes when the mouse hovers over the Planet.
        SetPlanetName();
    }

    //Sets the text to empty when no Planet name is written.
    private void OnMouseExit()
    {
        text.SetText("");
    }

    //Shows the planet name wherever text is used.
    void SetPlanetName()
    {
        text.SetText(Planet.PlanetName);
    }
}