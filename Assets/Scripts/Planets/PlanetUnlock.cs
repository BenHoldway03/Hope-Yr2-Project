using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetUnlock : MonoBehaviour
{
    [SerializeField] ResourcesToUnlock resourcesNeeded;
    [SerializeField] PlanetDetails planetDetails;

    [SerializeField] GameObject totalResourceTextParent;
    [SerializeField] Button button;
    int num;

    public ResourcesToUnlock ResourcesNeeded
    {
        get { return resourcesNeeded; }
        set { resourcesNeeded = value; }
    }

    private void Awake()
    {
        Button btn = button.GetComponent<Button>();
        planetDetails = GetComponent<PlanetDetails>();

        btn.onClick.AddListener(UnlockPlanet);
    }

    private bool UnlockChecker()
    {
        for(int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            TMP_Text text = totalResourceTextParent.transform.GetChild(0).GetComponent<TMP_Text>();
            int resourceAmount = 0;

            switch (i)
            {
                case 0:
                    resourceAmount = (int)planetDetails.Resource.MaterialAmount;
                    Debug.Log("Material");
                    break;
                case 1:
                    resourceAmount = (int)planetDetails.Resource.FoodAmount;
                    Debug.Log("Food");
                    break;
                case 2:
                    resourceAmount = (int)planetDetails.Resource.PopulationAmount;
                    Debug.Log("Population");
                    break;
                default:
                    break;
            }

            int.TryParse(text.text, out num);

            if(num < resourceAmount)
            {
                return false;
            }
        }

        return true;
    }

    public void UnlockPlanet()
    {
        bool unlockPlanet = UnlockChecker();

        if (planetDetails.PlanetCam.isActiveAndEnabled)
        {
            if (unlockPlanet)
            {
                Debug.Log("Unlock");
                planetDetails.Planet.IsLocked = false;
            }
            else
            {
                Debug.Log("Not Unlocked");
            }
        }
    }
}
