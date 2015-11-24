using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}
