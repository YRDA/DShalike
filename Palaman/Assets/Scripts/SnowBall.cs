using UnityEngine;
using System.Collections;

public class SnowBall : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Block")
        {
            Destroy(this.gameObject);
        }
    }
}
