//Reference for this code - http://wiki.unity3d.com/index.php?title=Server_Side_Highscores
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour // Leaderboard script
{
    private string highscoreURL = "http://chrissweir.cloudapp.net/display.php"; //URL to my php script on my server to interact with my database
    public GameObject scoreList;
   
    void Start ()
    {
        StartCoroutine(HighScoreMenu());
	}

    IEnumerator HighScoreMenu()
    {
        scoreList.GetComponent<Text>().enabled = true;//Enables Score display
            scoreList.GetComponent<Text>().text = "Loading Scores";
            WWW hs_get = new WWW(highscoreURL);
            yield return hs_get;

            if (hs_get.error != null)
            {
                print("There was an error getting the high score: " + hs_get.error);
            }
            else
            {
                scoreList.GetComponent<Text>().text = hs_get.text; // this is a GUIText that will display the scores in game.
            }
    }

    public void BackButton(string StartMenu) // Back button to go back to the main  menu
    { 
        Application.LoadLevel(StartMenu);
    }
}
