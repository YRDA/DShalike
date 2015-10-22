using UnityEngine;
using System.Collections;

public class Peak : MonoBehaviour {

    float peakY;
    void Start()
    {
        peakY = transform.position.y;
    }

    void Update()
    {
        if ( transform.position.y < peakY - 1)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.name == "Lava_inf(Clone)" || obj.gameObject.name == "Lava_sup(Clone)" || obj.gameObject.name == "Agua_inf(Clone)" || obj.gameObject.name == "Agua_sup(Clone)" || obj.gameObject.name == "Shalike")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(obj.gameObject);
            Destroy(this.gameObject);
        }
    }
}
