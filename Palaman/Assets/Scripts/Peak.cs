using UnityEngine;
using System.Collections;

public class Peak : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D obj)
    {
        if (obj.gameObject.name == "Lava_inf(Clone)" || obj.gameObject.name == "Lava_sup(Clone)" || obj.gameObject.name == "Agua_inf(Clone)" || obj.gameObject.name == "Agua_sup(Clone)")
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
