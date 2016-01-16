using UnityEngine;
using System.Collections;

public class Golpe : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Shalike")
        {
            player shalike = GameObject.Find("Shalike").GetComponent<player>();
            shalike.Vidas(-1);
        }
    }
}
