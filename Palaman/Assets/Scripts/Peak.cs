using UnityEngine;
using System.Collections;

public class Peak : MonoBehaviour {

    float peakY;
    void Start()
    {
        peakY = transform.position.y; // obtenemos la posicion del eje Y 
    }

    void Update()
    {
        // si mi posicion actual es menor a mi posicion inicial menos 1
        if ( transform.position.y < peakY - 1)
        {
            Destroy(this.gameObject); // autodestruyo el objeto
        }
    }

    void OnTriggerEnter2D (Collider2D obj)
    {
        // Si colisiono con lava, agua, personaje o SuperBloque
        if (obj.gameObject.name == "Lava_inf(Clone)" || obj.gameObject.name == "Lava_sup(Clone)" || obj.gameObject.name == "Agua_inf(Clone)" || obj.gameObject.name == "Agua_sup(Clone)" || obj.gameObject.name == "Shalike" || obj.gameObject.name == "SuperBlock")
        {
            Destroy(this.gameObject); // Autodestruyo el objeto
        }
        else
        {
            if (obj.tag == "Block") // es un bloque?
            {
                Destroy(obj.gameObject); // destruyo el otro objeto
                Destroy(this.gameObject); // Autodestruyo el objeto    
            }
        }
    }
}
