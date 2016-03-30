using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour {

    private string highscoreURL = "http://chrisweir.cloudapp.net/display.php";
    public GameObject scoreList;
   
    // Use this for initialization
    void Start () {
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

    public void BackButton(string StartMenu)
    {
        Application.LoadLevel(StartMenu);
    }
}
