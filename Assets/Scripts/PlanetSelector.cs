using System;
using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    public Action<Camera, Camera> onZoomIn;
    
    [SerializeField] new Camera camera;
    [SerializeField] GameObject planets;
    [SerializeField] Camera[] planetsCams;

    // Update is called once per frame
    void Update()
    {
        if (camera.isActiveAndEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.tag == "Planet")
            {
                    for (int i = 0; i < planets.transform.childCount; i++)
                    {
                        if (objectHit.name == planets.transform.GetChild(i).name)
                        {
                            onZoomIn?.Invoke(camera, planetsCams[i]);
                        }
                    }
            }
        }
    }
}
