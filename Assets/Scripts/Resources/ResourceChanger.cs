using UnityEngine;

public class ResourceChanger : MonoBehaviour
{
    //Increases the resources on each Planet.

    [SerializeField] ResourceIncrease resourceIncrease;
    PlanetDetails planetDetails;

    private void Start()
    {
        planetDetails = GetComponent<PlanetDetails>();
    }

    private void Update()
    {
        //Makes sure that the Planet selected is not still locked.
        if (!planetDetails.Planet.IsLocked)
        {
            Increase();
        }
    }

    void Increase()
    {
        //Increases each resource by the increasing amount set.
        planetDetails.Resource.MaterialAmount += resourceIncrease.MaterialIncrease * Time.deltaTime;
        planetDetails.Resource.FoodAmount += resourceIncrease.FoodIncrease * Time.deltaTime;
        planetDetails.Resource.PopulationAmount += resourceIncrease.PopulationIncrease * Time.deltaTime;
    }
}