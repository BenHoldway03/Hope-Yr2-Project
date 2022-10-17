using System;
using UnityEngine;

public class PlanetZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Camera mainCam;
    [SerializeField] bool isZoom;

    private void Start()
    {

    }

    //runs if the mouse is hovering over the object when clicked
    private void OnMouseDown()
    {
        //runs ZoomIn if not zoomed in, or zooms out if already zoomed in
        if (!isZoom)
        {
            ZoomIn();
            isZoom = true;
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