using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//This code allows the character to collect items


public class CornCollector : MonoBehaviour
{
    public int Score; // Player's score
    public int requiredScore = 40; // Score needed to win
    public float loseTime = 30; // Time limit to win in seconds
    public GameObject winScreen, loseScreen; //Stores Win and Lose Screens


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0; //Starting score set to 0
    }

    // Update is called once per frame
    void Update()
    {
        if (Score >= requiredScore && !loseScreen.activeSelf)
        {
            winScreen.SetActive(true);
        }

        if (Time.time >= loseTime && !winScreen.activeSelf)
        {
            loseScreen.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("corn")) //Check if the collided object is tagged as "corn"
        {
            Destroy(other.gameObject); // Remove the corn from the scene
            Score += 1; // Increase the score by 1
        }


    }

}


