using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetUnlock : MonoBehaviour
{
    [SerializeField] ResourcesToUnlock resourcesNeeded;
    [SerializeField] PlanetDetails planetDetails;

    [SerializeField] GameObject totalResourceTextParent;
    [SerializeField] GameObject unlockButton;
    [SerializeField] GameObject upgradeButton;


    public ResourcesToUnlock ResourcesNeeded
    {
        get { return resourcesNeeded; }
        set { resourcesNeeded = value; }
    }

    private void Awake()
    {
        Button btn = unlockButton.GetComponent<Button>();
        planetDetails = GetComponent<PlanetDetails>();

        btn.onClick.AddListener(UnlockPlanet);

        unlockButton.SetActive(true);
        upgradeButton.SetActive(false);

        UnlockPlanet();
    }

    private bool UnlockChecker()
    {
        for(int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            TMP_Text text = totalResourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();
            float resourceNeeded = 0;

            switch (i)
            {
                case 0:
                    resourceNeeded = resourcesNeeded.MaterialNeeded;
                    break;
                case 1:
                    resourceNeeded = resourcesNeeded.FoodNeeded;
                    break;
                case 2:
                    resourceNeeded = resourcesNeeded.PopulationNeeded;
                    break;
                default:
                    break;
            }

            int num;
            int.TryParse(text.text, out num);

            if(num < resourceNeeded)
            {
                return false;                
            }
        }

        return true;
    }

    public void UnlockPlanet()
    {
        bool unlockPlanet = UnlockChecker();

        if (unlockPlanet && planetDetails.PlanetCam.isActiveAndEnabled)
        {
            planetDetails.Planet.IsLocked = false;

            unlockButton.SetActive(false);
            upgradeButton.SetActive(true);
        }
    }
}
