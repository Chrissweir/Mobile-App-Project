using UnityEngine;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour //Main menu script for starting, exiting, viewing leaderboards, changing settings
{
    //Md5 encryption
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

    //Start Button
    public void StartButton(string MainScene)
    {
        Application.LoadLevel(MainScene);
    }

    //Main menu Button
    public void MainButton(string StartMenu)
    {
        Application.LoadLevel(StartMenu);
    }

    //Leaderboards Button
    public void Leaderboards(string Leaderboards)
    {
        Application.LoadLevel(Leaderboards);
    }

    //Setting Button
    public void Settings(string Settings)
    {
        Application.LoadLevel(Settings);
    }

    //Exit Button
    public void Exit(string MainScene)
    {
        Application.Quit();
    }
}