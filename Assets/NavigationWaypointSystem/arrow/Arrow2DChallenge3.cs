using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Arrow2DChallenge3 : MonoBehaviour
{
    public RectTransform ArrowRectTransform; // Use RectTransform instead of Image
    public float OrganicMatter = 1.0f;    
    public float Acidifying = 1.0f;
    public GameObject MonitorScore;
    public Text MonitorScoreText;
    public float CurrentPh = 1;
    public float NumberOfOrganic = 1;
    public float NumberOfAcidifying = 1;
    public bool IsOrganicSub = false;
    public bool IsAcidifyingSub = false;

    public GameObject CancelButton;

    private Vector2 initialPosition; // Store the initial anchored position of the arrow
    private float initialCurrentPh;  // Store the initial value of CurrentPh

    private void Start()
    {
        // Save the initial anchored position of the arrow and the initial value of CurrentPh when the script starts
        initialPosition = ArrowRectTransform.anchoredPosition;
        initialCurrentPh = CurrentPh;
    }

    // Function to move the arrow to the left by the specified amount
    public void MoveArrowLeftOrganicMatter()
    {
        // Get the current anchored position of the arrow
        Vector2 currentPosition = ArrowRectTransform.anchoredPosition;

        // Calculate the new anchored position by moving left by the specified amount
        Vector2 newPosition = new Vector2(currentPosition.x - OrganicMatter, currentPosition.y);

        // Set the new anchored position of the arrow
        ArrowRectTransform.anchoredPosition = newPosition;

        if (IsOrganicSub)
        {
            CurrentPh -= NumberOfAcidifying;
        }
        else
        {
            CurrentPh += NumberOfAcidifying;
        }
    }

    public void MoveArrowLeftAcidifying()
    {
        // Get the current anchored position of the arrow
        Vector2 currentPosition = ArrowRectTransform.anchoredPosition;

        // Calculate the new anchored position by moving left by the specified amount
        Vector2 newPosition = new Vector2(currentPosition.x - Acidifying, currentPosition.y);

        // Set the new anchored position of the arrow
        ArrowRectTransform.anchoredPosition = newPosition;
     
        if (IsAcidifyingSub)
        {
            CurrentPh -= NumberOfOrganic;
        }
        else
        {
            CurrentPh += NumberOfOrganic;
        }
    }

    public void MonitorAndAdjust()
    {
        MonitorScoreText.text = "ph Result: " + CurrentPh.ToString();
        MonitorScore.SetActive(true);
        StartCoroutine(WaitSeconds());
    }

    IEnumerator WaitSeconds()
    {
        // Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        // Yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(4);

        // After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        MonitorScore.SetActive(false);
    }

    // Function to reset the arrow to its initial position and reset CurrentPh to its initial value
    public void ResetToFirstPosition()
    {
        // Set the arrow's anchored position back to the initial position
        ArrowRectTransform.anchoredPosition = initialPosition;
        // Reset CurrentPh to its initial value
        CurrentPh = initialCurrentPh;
        
    }

    public void CancelOperation()
    {
        ArrowRectTransform.anchoredPosition = initialPosition;
        CurrentPh = initialCurrentPh;
    }
}
