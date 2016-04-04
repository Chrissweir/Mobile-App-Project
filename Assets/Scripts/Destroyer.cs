using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour //Destroy obstacles that go off of the screen to help stop objects building up and making the game lag
{ 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform.parent)
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
