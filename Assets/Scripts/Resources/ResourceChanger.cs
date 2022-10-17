using UnityEngine;

public class ResourceChanger : MonoBehaviour
{
    [SerializeField] ResourceIncrease resourceIncrease;
    PlanetDetails planetDetails;

    private void Start()
    {
        planetDetails = GetComponent<PlanetDetails>();
    }

    private void Update()
    {
        if (!planetDetails.Planet.IsLocked)
        {
            Increase();
        }
    }

    void Increase()
    {
        planetDetails.Resource.MaterialAmount += resourceIncrease.MaterialIncrease * Time.deltaTime;
        planetDetails.Resource.FoodAmount += resourceIncrease.FoodIncrease * Time.deltaTime;
        planetDetails.Resource.PopulationAmount += resourceIncrease.PopulationIncrease * Time.deltaTime;
    }
}