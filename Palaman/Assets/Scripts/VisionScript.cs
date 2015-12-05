using UnityEngine;
using System.Collections;

public class VisionScript : MonoBehaviour {

    public wanflyScript wanfliS;

    void OnTriggerEnter2D(Collider2D col)
    {
        // si entra dentro del rango de vision
        if (col.gameObject.name == "Shalike")
        {
            // empezamos el modo perseguir
            wanfliS.stepPlayer = true;
            Destroy(this.gameObject);// destruimos el campo de vision
        }
    }

}
