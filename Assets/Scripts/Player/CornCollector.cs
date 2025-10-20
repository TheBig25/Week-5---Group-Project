using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//This code allows the character to collect items


public class CornCollector : MonoBehaviour
{
    public int Score; // Player's score
    public int requiredScore = 40; // Score needed to win
    public float loseTime; // Time limit to win in seconds
    public GameObject winScreen, loseScreen; //Stores Win and Lose Screens

    public TextMeshProUGUI scoreText; // Reference to the UI text component to display the score
    public TextMeshProUGUI timeText;
    public float timeLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0; //Starting score set to 0
        Time.timeScale = 1f; // Ensure the game is running at normal speed
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score >= requiredScore && !loseScreen.activeSelf)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }

        if (Time.time >= loseTime && !winScreen.activeSelf)
        {
            loseScreen.SetActive(true);
            timeText.text = "00:00";
            Time.timeScale = 0f; // Pause the game
        }

        scoreText.text = "Score: " + Score;
        TimeControl();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("corn")) //Check if the collided object is tagged as "corn"
        {
            Destroy(other.gameObject); // Remove the corn from the scene
            Score += 1; // Increase the score by 1
        }


    }

    void TimeControl()
    {
        
        if (timeLimit > 0)
        {
            //Decrease the time limit
            timeLimit -= Time.deltaTime;

            //Format the time display
            timeText.text = "Time Remaining: " + timeLimit.ToString();
            float minutes = Mathf.FloorToInt(timeLimit / 60);
            float seconds = Mathf.FloorToInt(timeLimit % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

}


