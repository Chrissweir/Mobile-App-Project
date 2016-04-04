using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    private float volume = 1.0f;
    private float slider = 1.0f;
    public Slider volumeSlider;
    
    // Use this for initialization
    void Start ()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume Slider", volumeSlider.value); //Load currently saved volume level
    }

    public void Options()
    {
        volume = volumeSlider.value;//Slider controls the volume level
        PlayerPrefs.SetFloat("Volume Slider", volumeSlider.value);//Save slider value
        AudioListener.volume = volume;//Audio Listener is set to volume value
        PlayerPrefs.SetFloat("Audio Volume", volume); //Save audio value
    }

    public void Mute()
    {
        volume = 0;//Set volume to 0
        volumeSlider.value = 0;//Set Slider to 0
        PlayerPrefs.SetFloat("Volume Slider", volumeSlider.value);//Save Slider value
        AudioListener.volume = volume;//Audio Listener is set to volume value
        PlayerPrefs.SetFloat("Audio Volume", volume);//Save audio value
    }
}
