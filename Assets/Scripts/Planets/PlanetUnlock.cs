using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetUnlock : MonoBehaviour
{
    [SerializeField] ResourcesToUnlock resourcesNeeded;
    PlanetDetails planetDetails;
    PlanetZoom planetZoom;

    [SerializeField] GameObject totalResourceTextParent;
    [SerializeField] GameObject totalResourceUI;
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
        planetZoom = GetComponent<PlanetZoom>();

        //refreshes UI when planet is selected
        planetZoom.onPlanetZoom += SetUI;

        //checks if the unlock button has been clicked
        btn.onClick.AddListener(UnlockPlanet);
    }

    private bool UnlockChecker()
    {
        //for loop to run through each of the total resource texts at the top of the screen in the scene
        for(int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            //gets the Text Mesh Pro text component from each child of the total text object
            TMP_Text text = totalResourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();

            //resource needed to unlock the planet
            float resourceNeeded = 0;

            //selects what resource is being checked
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

            //converts the string to an integer
            int num;
            int.TryParse(text.text, out num);

            //returns false and exits the bool checker if one of these resources is less than whats needed
            if(num < resourceNeeded)
            {
                return false;                
            }
        }

        //has checked through all of the resources and there is enough of each, so returns true
        return true;
    }

    public void UnlockPlanet()
    {
        //gets the return result
        bool unlockPlanet = UnlockChecker();

        //unlocks and refreshes the unlock/upgrade UI if the return result is true
        if (unlockPlanet && planetDetails.PlanetCam.isActiveAndEnabled)
        {
            planetDetails.Planet.IsLocked = false;
            SetUI();

            //adds planet to unlocked planets list in TotalResourceCalc script
            TotalResourceCalc totalResourceCalc = totalResourceUI.GetComponent<TotalResourceCalc>();
            totalResourceCalc.UnlockedPlanets.Add(gameObject);
        }
    }

    public void SetUI()
    {
        //shows unlock button and hides upgrade button if planet is locked
        if (planetDetails.Planet.IsLocked)
        {
            unlockButton.SetActive(true);
            upgradeButton.SetActive(false);
        }
        //hides unlock button and shows upgrade button if planet is not locked
        else
        {
            unlockButton.SetActive(false);
            upgradeButton.SetActive(true);
        }
    }
}