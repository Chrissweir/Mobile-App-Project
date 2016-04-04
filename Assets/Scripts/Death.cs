using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death : MonoBehaviour {

    private string secretKey = "Jasmin"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://chrisweir.cloudapp.net/addscore.php?"; //URL to my php script on my server to interact with my database
    public string playerName = "";
    public int score;
    public InputField Field;
    public Button Submit;

    // Use this for initialization
    void Start ()
    {
        score = PlayerPrefs.GetInt("Player Score", score); //Get score from other scene
    }

    public void SubmitScore()
    {
        StartCoroutine(PostScores(playerName, score));
        Field.gameObject.SetActive(false);//input fields disappears when submit button is clicked
        Submit.gameObject.SetActive(false);//Submit button disappears when its clicked
    }
    //Button and inputfield to submit score 
    public void SubmitButton()
    {
        playerName = Field.text;
        SubmitScore();
    }

    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    IEnumerator PostScores(string playerName, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = Md5Sum(playerName + score + secretKey);

        string post_url = addScoreURL + "playerName=" + WWW.EscapeURL(playerName) + "&score=" + score + "&hash=" + hash;

        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

}
