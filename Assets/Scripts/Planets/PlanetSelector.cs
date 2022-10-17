using UnityEngine;
using UnityEngine.UI;

public class PlanetSelector : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] PlanetUnlock planetUnlock;

    // Start is called before the first frame update
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlanetSelect);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlanetSelect()
    {
        cam = Camera.current;
        planetUnlock = cam.GetComponentInParent<PlanetUnlock>();
        planetUnlock?.UnlockPlanet();
    }
}
