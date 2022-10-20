using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetUnlock : MonoBehaviour
{
    //Handles the unlocking of each Planet.

    [SerializeField] ResourcesToUnlock resourcesNeeded;
    PlanetDetails planetDetails;
    PlanetZoom planetZoom;

    [SerializeField] GameObject totalResourceTextParent;
    [SerializeField] GameObject totalResourceUI;
    [SerializeField] GameObject unlockButton;
    [SerializeField] GameObject resourceTitleText;


    public ResourcesToUnlock ResourcesNeeded
    {
        get { return resourcesNeeded; }
        set { resourcesNeeded = value; }
    }

    void Start()
    {
        Button btn = unlockButton.GetComponent<Button>();
        planetDetails = GetComponent<PlanetDetails>();
        planetZoom = GetComponent<PlanetZoom>();

        //Refreshes UI when planet is selected
        planetZoom.onPlanetZoom += SetUI;

        //Checks if the unlock button has been clicked
        btn.onClick.AddListener(UnlockPlanet);
    }

    bool UnlockChecker()
    {
        //For loop to run through each of the total resource texts at the top of the screen in the scene
        for(int i = 0; i < totalResourceTextParent.transform.childCount; i++)
        {
            //Gets the Text Mesh Pro text component from each child of the total text object
            TMP_Text text = totalResourceTextParent.transform.GetChild(i).GetComponent<TMP_Text>();

            //Resource needed to unlock the planet
            float resourceNeeded = 0;

            //Selects what resource is being checked
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

            //Converts the string to an integer
            int num;
            int.TryParse(text.text, out num);

            //Returns false and exits the bool checker if one of these resources is less than whats needed
            if(num < resourceNeeded)
            {
                return false;                
            }
        }

        //Has checked through all of the resources and there is enough of each, so returns true
        return true;
    }

    public void UnlockPlanet()
    {
        //Gets the return result
        bool unlockPlanet = UnlockChecker();

        //Unlocks and refreshes the unlock/upgrade UI if the return result is true
        if (unlockPlanet && planetDetails.PlanetCam.isActiveAndEnabled)
        {
            planetDetails.Planet.IsLocked = false;
            SetUI();

            //Adds planet to unlocked planets list in TotalResourceCalc script
            TotalResourceCalc totalResourceCalc = totalResourceUI.GetComponent<TotalResourceCalc>();
            totalResourceCalc.UnlockedPlanets.Add(gameObject);

            planetDetails.Resource.MaterialAmount = 0;
            planetDetails.Resource.FoodAmount = 0;
            planetDetails.Resource.PopulationAmount = 0;
        }
    }

    public void SetUI()
    {
        TMP_Text text = resourceTitleText.GetComponent<TMP_Text>();
        //Shows unlock button and sets the Resources title to "Resources Required" (as the Planet is locked).
        if (planetDetails.Planet.IsLocked)
        {
            unlockButton.SetActive(true);
            text.SetText("Resources Required");
        }
        //Hides unlock button and sets the Resources title to "Resources Gathered" (as the Planet is unlocked).
        else
        {
            unlockButton.SetActive(false);
            text.SetText("Resources Gathered");
        }
    }
}