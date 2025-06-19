using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyPlan : MonoBehaviour
{
    double Protein;
    double CarbonHydrates;
    double Fat;

    public GameObject ProteinPicked;
    public GameObject CarbonHydratesPicked;

    public GameObject ChallengeFailed;
    public GameObject FatPicked;
    public bool ExistProtein;
    public bool ExistCarbonHydrates;
    public bool ExistFat;

    void Start()
    {
        Protein=0;
        CarbonHydrates=0;
        Fat=0;
        ExistProtein=true;
        ExistCarbonHydrates=true;
        ExistFat=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ProteinPicked.activeSelf)
        {
            ExistProtein=false;      
        }
        if (ExistProtein==false)
        {
            ProteinAction();
        }


        if (!CarbonHydratesPicked.activeSelf)
        {
            ExistCarbonHydrates=false;
        }
        if (ExistCarbonHydrates==false)
        {
            CarbonHydratesAction();
        }


        if (!ProteinPicked.activeSelf)
        {
            ExistFat=false;    
        }
        if (ExistFat==false)
        {
            FatAction();
        }

        if (Protein>=200 || CarbonHydrates >=200 || Fat>=200 )
        {
            ChallengeFailedAction();
        }


}

    void ProteinAction()
    {
        Protein+=20;
        ExistProtein=true;  
    }

    void CarbonHydratesAction()
    {
        CarbonHydrates+=20;
        ExistCarbonHydrates=true;     
    }

    void FatAction()
    {
        Fat+=20;
        ExistFat=true;    
    }

    void ChallengeFailedAction()
    {
        ChallengeFailed.SetActive(true);
    }

}
