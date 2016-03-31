using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    private float volume = 1.0f;
    private float slider = 1.0f;
    public Slider volumeSlider;


    // Use this for initialization
    void Start () {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume Slider", volumeSlider.value);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Options()
    {
        volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume Slider", volumeSlider.value);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Audio Volume", volume);

    }
    public void Mute()
    {
        volume = 0;
        volumeSlider.value = 0;
        PlayerPrefs.SetFloat("Volume Slider", volumeSlider.value);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Audio Volume", volume);
    }
}
