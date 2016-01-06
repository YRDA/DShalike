using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class MasterBlock : MonoBehaviour {

    string valuesBlock;
    int typeBlock = 0;
    Animator animaBlocks;

    void Start()
    {
        // obtenemos la propiedad del animator del mismo objeto
        animaBlocks = gameObject.GetComponent<Animator>();
    }
	void Update () {
        // actualizamos el valor
        animaBlocks.SetInteger("type",typeBlock);
	}

    void OnMouseDown()
    {
        // referenciamos el script Mapcreator para poder acceder a sus propiedades
        MapCreator mapeo = GameObject.Find("Level0").GetComponent<MapCreator>();

        // si el valor del contador de tipo de bloque llega al maximo valor
        if (typeBlock == 10)
        {
            typeBlock = 0; // lo reiniciamos
            // actualizamos de tipo de bloque llamando la funcion de MapCreator y pasandole coordenadas y valor del bloque
            mapeo.actualizarvalues(transform.position.x,transform.position.y,0,0);
        }
        else
        {
            typeBlock += 1; // aumentamos en 1 el valor del contador del tipo de bloque
            // actualizamos de tipo de bloque llamando la funcion de MapCreator y pasandole coordenadas y valor del bloque
            mapeo.actualizarvalues(transform.position.x, transform.position.y, 1, typeBlock);
        }
    }
}
