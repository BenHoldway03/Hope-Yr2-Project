using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;

public class PlanetDetails : MonoBehaviour
{
    [SerializeField] PlanetSO planet;
    [SerializeField] TMP_Text text;
    [SerializeField] Camera planetCam;
    [SerializeField] Resources resourse;
    ResourceUpdater resourceUpdater;

    public PlanetSO Planet => planet;
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
        if(planet.PlanetName != "Crait")
        {
            planet.IsLocked = true;
        }
        else
        {
            planet.IsLocked = false;
        }

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

    void SetPlanetName()
    {
        text.SetText(Planet.PlanetName);
    }
}
