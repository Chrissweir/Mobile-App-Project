using UnityEngine;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour
{
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
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    

    public void StartButton(string MainScene)
    {
        Application.LoadLevel(MainScene);
    }

    public void MainButton(string StartMenu)
    {
        Application.LoadLevel(StartMenu);
    }

    public void Leaderboards(string Leaderboards)
    {
        Application.LoadLevel(Leaderboards);
    }

    public void Settings(string Settings)
    {
        Application.LoadLevel(Settings);
    }

    public void Exit(string MainScene)
    {
        Application.Quit();
    }
}