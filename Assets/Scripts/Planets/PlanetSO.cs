using UnityEngine;

[CreateAssetMenu(fileName = "Planets", menuName = "ScriptableObjects/Planet", order = 0)]
public class PlanetSO : ScriptableObject
{
    [SerializeField] string planetName;
    [SerializeField] bool isLocked;
    public string PlanetName => planetName;

    public bool IsLocked
    {
        get { return isLocked; }
        set { isLocked = value; }
    }
}
