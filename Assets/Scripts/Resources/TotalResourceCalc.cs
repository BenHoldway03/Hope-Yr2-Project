using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalResourceCalc : MonoBehaviour
{
    [SerializeField] GameObject planets;

    [SerializeField] GameObject totalResourceUI;
    [SerializeField] GameObject totalResourceTextParent;

    [SerializeField] List<float> resourceList = new List<float>();

    // Update is called once per frame
    void Update()
    {
        TotalCalculator();
    }

    void TotalCalculator()
    {
        for (int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            float total = 0;

            for (int j = 0; j < planets.transform.childCount; j++)
            {
                PlanetDetails details = planets.transform.GetChild(j).GetComponent<PlanetDetails>();

                if (resourceList.Count == 0)
                {
                    resourceList.Add(details.Resource.MaterialAmount);
                    resourceList.Add(details.Resource.FoodAmount);
                    resourceList.Add(details.Resource.PopulationAmount);
                }

                //add all recourses together to make a total
                if (!details.Planet.IsLocked)
                {
                    total += (int)resourceList[i];
                }
            }

            TMP_Text textMeshPro = totalResourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            textMeshPro.SetText(total.ToString("F0"));
        }

        resourceList.Clear();
    }
}