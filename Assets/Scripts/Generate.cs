using UnityEngine;

public class Generate : MonoBehaviour //Class for generating the rock obstacle game objects
{
    public GameObject rocks;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
    }

    void CreateObstacle()
    {
        Instantiate(rocks);
    }
}