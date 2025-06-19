using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

namespace FinalChallenge
{

[RequireComponent(typeof(Image))]
public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Button correctButton;
    public Button correctButton2;
    public Button correctButton3;
    public Button correctButton4;
    public Button correctButton5;
    public Button correctButton6;
    public Button correctButton7;
    public Button correctButton8;
    public Button correctButton9;
    public Button correctButton10;
    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public static int TotalScore = 0; // Static variable to store total score across all instances
    public int ScoreOfQuestions = 0; // Variable to store the score for this instance

    private Image image;
    private Vector3 initialPosition;
    private Button currentButton;
    private bool isCorrectButtonSelected = false;
    private HashSet<Button> buttonsWithImages = new HashSet<Button>(); // Store buttons with received images
    private bool outOfQuestions = false; // Indicates if all images have disappeared
    public static int counter = 0;
    public GameObject MatchingObject;
    public GameObject Outcome;
    public Text OutcomeText;
    public Text ScoreShow;

    public static int TotalFoodScore=0;

    private void Start()
    {
        image = GetComponent<Image>();
        initialPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Set the object as being dragged
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow the pointer's position
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
{
    // Reset the position if dropped outside of any button
    transform.position = initialPosition;

    // Check if the object is dropped onto a button
    if (currentButton != null)
    {
        // Change button color based on correctness
        if (currentButton == correctButton || currentButton == correctButton2 || currentButton == correctButton3 || currentButton == correctButton4 || currentButton == correctButton5 || currentButton == correctButton6 || currentButton == correctButton7 || currentButton == correctButton8 || currentButton == correctButton9 || currentButton == correctButton10)
        {
            currentButton.image.color = correctColor;
            isCorrectButtonSelected = true;
            // Increment score if correct button and correct image
            ScoreOfQuestions++;
            TotalScore++;
            Debug.Log("Total Score is: " + TotalScore);
            counter++;
            Debug.Log("Counter is: " + counter);
            MatchingCalculate();
            TotalFoodScore += 1;

        }
        else
        {
            currentButton.image.color = incorrectColor;
            isCorrectButtonSelected = false;
            Debug.Log("Total Score is: " + TotalScore);
            counter++;
            Debug.Log("Counter is: " + counter);
            MatchingCalculate();
            TotalFoodScore -= 1;
        }

        // Disable button collider and trigger if image is dropped
        currentButton.GetComponent<Collider2D>().enabled = false;
        currentButton.GetComponent<Collider2D>().isTrigger = false;

        // Store the button as having received an image
        buttonsWithImages.Add(currentButton);

        // *** Update button image with the dropped item's image ***
        currentButton.image.sprite = GetComponent<Image>().sprite;  // Update button image

        // Deactivate the object
        gameObject.SetActive(false);

        // Check if all images have disappeared
        outOfQuestions = buttonsWithImages.Count == 0;
        if (outOfQuestions)
        {
            Debug.Log("End Of The Matching");
        }
    }

    // Restore raycast target
    image.raycastTarget = true;
}


    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object enters a button's collider
        if (other.CompareTag("Button"))
        {
            currentButton = other.GetComponent<Button>();

            // Check if the button has already received an image
            if (buttonsWithImages.Contains(currentButton))
            {
                // Reset button color
                currentButton.image.color = Color.white;
                currentButton = null; // Reset current button reference
            }
        }
    }

   void MatchingCalculate()
    {
         
                
            if(counter==17 && TotalScore<=7)
            {
                MatchingObject.SetActive(false);
                Outcome.SetActive(true);
                OutcomeText.text="Looks like there was a misunderstanding. No worries! Take another shot at it, and don't be afraid to explore more about crowdfunding";
                ScoreShow.text = TotalScore.ToString() + " / 17";
            }

            if(counter==17 && TotalScore>7 && TotalScore<=13)
            {
                MatchingObject.SetActive(false);
                Outcome.SetActive(true);
                OutcomeText.text="Not bad, but there's room for improvement. Keep learning about crowdfunding and you'll ace it next time!";
                ScoreShow.text = TotalScore.ToString() + " / 17";
            }

            if(counter==17 && TotalScore>=14)
            {
                MatchingObject.SetActive(false);
                Outcome.SetActive(true);
                OutcomeText.text="You got all the answers correct! 🎉 You're a crowdfunding expert! Keep up the great work!";
                ScoreShow.text = TotalScore.ToString() + " / 17";
            }
    
    }
}




}