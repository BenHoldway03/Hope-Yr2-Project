using System;
using UnityEngine;

public class PlanetZoom : MonoBehaviour
{
    //Focuses on the Planet selected and zooms into it (changes to the PlanetCam).

    [SerializeField] Camera cam;
    [SerializeField] Camera mainCam;
    [SerializeField] bool isZoom;

    public Action onPlanetZoom;

    private void Start()
    {

    }

    //Runs if the mouse is hovering over the object when clicked
    private void OnMouseDown()
    {
        //Runs ZoomIn if not zoomed in, or zooms out if already zoomed in
        if (!isZoom)
        {
            ZoomIn();
            isZoom = true;
            onPlanetZoom?.Invoke();
        }
        else
        {
            mainCam.enabled = true;
            cam.enabled = false;
            isZoom = false;
        }
    }

    //Function to zoom in
    public void ZoomIn()
    {
        mainCam.enabled = false;
        cam.enabled = true;
    }
}