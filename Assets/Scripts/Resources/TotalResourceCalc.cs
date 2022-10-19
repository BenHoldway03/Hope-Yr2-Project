using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalResourceCalc : MonoBehaviour
{
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
        TotalCalculator();
    }

    void TotalCalculator()
    {
        for (int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            float total = 0;

            for (int j = 0; j < unlockedPlanets.Count; j++)
            {
                PlanetDetails details = unlockedPlanets[j].GetComponent<PlanetDetails>();

                if (resourceList.Count == 0)
                {
                    resourceList.Add(details.Resource.MaterialAmount);
                    resourceList.Add(details.Resource.FoodAmount);
                    resourceList.Add(details.Resource.PopulationAmount);
                }

                //add all recourses together to make a total
                total += (int)resourceList[i];

                resourceList.Clear();
            }

            TMP_Text textMeshPro = totalResourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            textMeshPro.SetText(total.ToString());
        }
    }
}
