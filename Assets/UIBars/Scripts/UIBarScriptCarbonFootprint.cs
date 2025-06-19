// Update the UIBarScript

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIBarScriptCarbonFootprint : MonoBehaviour {

    // GameObject variables
    private GameObject Filler;
    private GameObject Mask;
    private GameObject PercentTxt;
    private GameObject RatioTxt;
    

    // Fill style
    public enum FillStyles { horizontal = 0, vertical = 1 };
    public FillStyles FillStyle = FillStyles.horizontal;

    // Mask offsets
    private Vector3 Mask0;
    private Vector3 Mask1;
    public float MaskOffset;

    // Current value and the value it will update to
    private float Value = 0.5f;
    public float NewValue = 0f; // Default value set to 15

    // Gradients
    public Gradient HPColor;
    public Gradient TextColor;

    // Speed
    public float Speed = 10f;

    // Text bools
    public bool DisplayPercentTxt;
    public bool DisplayRatioTxt;

    [HideInInspector]
    public bool StartAnimate = false;

    // Categories
    public enum Categories { increase = 0, decrease = 1, NA = 2 }
    [HideInInspector]
    public Categories UpdateCategory = Categories.decrease;

    // Rule Lists
    public List<CriteriaRule> CriteriaRules = new List<CriteriaRule>();
    public List<UpdateAnimationRule> UpdateAnimationRules = new List<UpdateAnimationRule>();

    // Maximum HP
    public float MaxHP;

    // Set the variables
    void Awake()
    {
        Mask = gameObject.transform.Find("Mask").gameObject;
        Filler = Mask.transform.Find("Filler").gameObject;
        PercentTxt = gameObject.transform.Find("PercentTxt").gameObject;
        RatioTxt = gameObject.transform.Find("RatioTxt").gameObject;

        RectTransform FRT = (Filler.transform as RectTransform);

        // Location of the filler object when the HP is at 1
        Mask0 = new Vector3(FRT.position.x, FRT.position.y, FRT.position.z);

        // Location of the filler object when the HP is at 0 depends on the FillStyle
        if (FillStyle == FillStyles.horizontal)
        {
            Mask1 = new Vector3(FRT.position.x + FRT.rect.width, FRT.position.y, FRT.position.z);
        }
        else
        {
            Mask1 = new Vector3(FRT.position.x, FRT.position.y + FRT.rect.height, FRT.position.z);
        }
    }

    void Update()
    {
        // Set the Update Category
        if (Mathf.Round(Value) == Mathf.Round(NewValue))
        {
            UpdateCategory = Categories.NA;
        }
        else if (Value > NewValue)
        {
            UpdateCategory = Categories.decrease;
        }
        else if (Value < NewValue)
        {
            UpdateCategory = Categories.increase;
        }

        // Update the Mask locations
        RectTransform MRT = (Mask.transform as RectTransform);
        if (FillStyle == FillStyles.horizontal)
        {
            Mask1 = new Vector3(MRT.position.x, MRT.position.y, MRT.position.z);
            Mask0 = new Vector3(MRT.position.x - MRT.rect.width + MaskOffset, MRT.position.y, MRT.position.z);
        }
        else
        {
            Mask1 = new Vector3(MRT.position.x, MRT.position.y, MRT.position.z);
            Mask0 = new Vector3(MRT.position.x, MRT.position.y - MRT.rect.height + MaskOffset, MRT.position.z);
        }

        // Move the Current Value to the NewValue
        Value = Mathf.Lerp(Value, NewValue, Speed * Time.deltaTime);
        Value = Mathf.Clamp(Value, 0f, 100f);

        // Move the Filler position to display the Correct Percent
        RectTransform FRT = (Filler.transform as RectTransform);
        FRT.position = Vector3.Lerp(Mask0, Mask1, Value / 100f);

        // Set the color for the Fill Image, and the Text Objects
        Filler.GetComponent<Image>().color = HPColor.Evaluate(Value / 100f);
        PercentTxt.GetComponent<Text>().color = TextColor.Evaluate(Value / 100f);
        RatioTxt.GetComponent<Text>().color = TextColor.Evaluate(Value / 100f);

        // Execute Each Criteria Rule
        foreach (CriteriaRule CR in CriteriaRules)
        {
            if (CR.isImage())
            {
                CR.DefaultColor = HPColor.Evaluate(Value / 100f);
            }
            else
            {
                CR.DefaultColor = TextColor.Evaluate(Value / 100f);
            }

            CR.Use(Mathf.Round(Value));
        }

        // Execute Each Update Animation Rule
        foreach (UpdateAnimationRule UAR in UpdateAnimationRules)
        {
            if (StartAnimate)
            {
                if (UAR.Category.ToString() == UpdateCategory.ToString())
                {
                    UAR.StartAnimation = true;
                }
            }

            UAR.Use();
        }

        // Reset the StartAnimate variable
        StartAnimate = false;

        // Activate or inactivate the text objects
        PercentTxt.SetActive(DisplayPercentTxt);
        RatioTxt.SetActive(DisplayRatioTxt);

        // Update the PercentTxt 
        PercentTxt.GetComponent<Text>().text = Mathf.Round(Value).ToString();

    }

    // Update the UIBar
    // Update the UIBar
    public void UpdateValue(float Percent)
    {
        // Add the new value to the existing NewValue
        NewValue += Percent;

        // Ensure that NewValue stays within the desired range (0 to 30)
        NewValue = Mathf.Clamp(NewValue, 0f, 100f);

        // Trigger the start of the animation
        StartAnimate = true;
    }


    // Overloaded method to Update the UIBar with HP and MaxHP
    public void UpdateValue(float HP, float MaxHP)
    {
        // Set the RatioTxt
        RatioTxt.GetComponent<Text>().text = HP.ToString() + "/" + MaxHP.ToString();

        // NewValue
        NewValue += NewValue + Mathf.Round((HP / MaxHP) * 100f);

        // Trigger the start of the animation
        StartAnimate = true;
    }
}
