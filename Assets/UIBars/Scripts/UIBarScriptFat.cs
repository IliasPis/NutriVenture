// Update the UIBarScript

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIBarScriptFat : MonoBehaviour {

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
    public float NewValue = 15f; // Default value set to 15

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
        Value = Mathf.Clamp(Value, 0f, 30f);

        // Move the Filler position to display the Correct Percent
        RectTransform FRT = (Filler.transform as RectTransform);
        FRT.position = Vector3.Lerp(Mask0, Mask1, Value / 30f);

        // Set the color for the Fill Image, and the Text Objects
        Filler.GetComponent<Image>().color = HPColor.Evaluate(Value / 30f);
        PercentTxt.GetComponent<Text>().color = TextColor.Evaluate(Value / 30f);
        RatioTxt.GetComponent<Text>().color = TextColor.Evaluate(Value / 30f);

        // Execute Each Criteria Rule
        foreach (CriteriaRule CR in CriteriaRules)
        {
            if (CR.isImage())
            {
                CR.DefaultColor = HPColor.Evaluate(Value / 30f);
            }
            else
            {
                CR.DefaultColor = TextColor.Evaluate(Value / 30f);
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
    public void UpdateValue(float Percent)
    {
        // Hide the Ratio text
        //DisplayRatioTxt = false;

        // NewValue
        NewValue = Percent;

        // Trigger the start of the animation
        StartAnimate = true;
    }

    // Overloaded method to Update the UIBar with HP and MaxHP
    public void UpdateValue(float HP, float MaxHP)
    {
        // Set the RatioTxt
        RatioTxt.GetComponent<Text>().text = HP.ToString() + "/" + MaxHP.ToString();

        // NewValue
        NewValue += NewValue + Mathf.Round((HP / MaxHP) * 30f);

        // Trigger the start of the animation
        StartAnimate = true;
    }
}
