using UnityEngine;

[System.Serializable]
public class PlanetSettings
{
    [SerializeField] string planetName;
    [SerializeField] int planetNum;
    [SerializeField] bool isLocked;

    public string PlanetName => planetName;

    public int PlanetNum => planetNum;

    public bool IsLocked
    {
        get { return isLocked; }
        set { isLocked = value; }
    }
}
