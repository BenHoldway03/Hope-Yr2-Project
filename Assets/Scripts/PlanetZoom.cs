using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Camera mainCam;

    //
    private void OnMouseDown()
    {
        ZoomIn();
    }

    public void ZoomIn()
    {
        mainCam.enabled = false;
        cam.enabled = true;
    }
}
