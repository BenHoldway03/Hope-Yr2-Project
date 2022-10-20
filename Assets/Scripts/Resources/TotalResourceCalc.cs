using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalResourceCalc : MonoBehaviour
{
    //Calculates and shows the total resource amounts.

    [SerializeField] GameObject planets;

    [SerializeField] GameObject totalResourceUI;
    [SerializeField] GameObject totalResourceTextParent;

    [SerializeField] List<float> resourceList = new List<float>();
    [SerializeField] List<GameObject> unlockedPlanets = new List<GameObject>();

    public List<GameObject> UnlockedPlanets
    {
        get { return unlockedPlanets; }
        set { unlockedPlanets = value; }
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly updates the resources.
        TotalCalculator();
    }

    void TotalCalculator()
    {
        //Runs through all of the total resource texts (children of the parent set).
        for (int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            float total = 0;

            //Runs through the UnlockedPlanets list
            for (int j = 0; j < UnlockedPlanets.Count; j++)
            {
                PlanetDetails details = unlockedPlanets[j].GetComponent<PlanetDetails>();

                //Adds the amounts of each resource for the specific Planet.
                if (resourceList.Count == 0)
                {
                    resourceList.Add(details.Resource.MaterialAmount);
                    resourceList.Add(details.Resource.FoodAmount);
                    resourceList.Add(details.Resource.PopulationAmount);
                }

                //Add all recourses together to make a total
                total += (int)resourceList[i];

                //Clears the resource list so that its ready for the next Planet.
                resourceList.Clear();
            }

            //Sets each of the total resource texts to the total amounts (and coverts them from float to string for text).
            TMP_Text textMeshPro = totalResourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            textMeshPro.SetText(total.ToString());
        }
    }
}
