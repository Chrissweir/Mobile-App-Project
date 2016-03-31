using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    private float volume = 1.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void options()
    {
        volume = GUILayout.HorizontalSlider(volume, 0.0f, 1.0f);
        AudioListener.volume = volume;
    }
}
