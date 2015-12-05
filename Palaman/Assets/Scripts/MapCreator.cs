using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class MapCreator : MonoBehaviour {

    int maxX = 18, minX = -49, maxY = 4, minY = -11;
    public GameObject superBlockMaster;
    float spaceX = 0.0f;
    float spaceY = 0.0f;
    public string[] id = new string[1006];
    public string nivel;
    int moveSpeed = 300;
    int countId = 0;
    
   	void Start () {

        // recorremos dos ciclos for para recorrer en X y Y todo el mapa
        for (int i = minY; i < maxY; i++)
        {
            spaceX = 0; // reiniciamos el espacio en x
            for (int j = minX; j < maxX; j++)
            {
                // colocamos un bloque maestro en las coordenadas XY y le sumamos el espacio entre cada bloque
                Instantiate(superBlockMaster, new Vector3(spaceX + j, spaceY + i , -1), transform.rotation);
                // agregamos al arreglo las coordenadas de cada bloque
                id[countId] = (spaceX+j) + "|" + (spaceY +i) + "|0|0";
                spaceX += 0.48f; // incrementamos el espacio entre cada bloque en el eje X
                countId += 1; // incrementamos el valor del contador en 1
            }
            spaceY += 0.55f; // incrementamos el espacio entre cada bloque en el eje Y
        }        
	}

    void Update()
    {
        // Movimiento de la pantalla con las flechas del teclado
        if (Input.GetKeyDown(KeyCode.LeftArrow)) transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightArrow)) transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow)) transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.DownArrow)) transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        // generamos el archivo de texto para el nivel al precionar la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space)) generarmapa();
    }

    public void actualizarvalues(float blockx,float blocky,int block, int typeblock)
    {
        // recivimos la coordenadas XY del bloque, si debe existir un bloque y que tipo de bloque
        countId = 0;
        spaceY = 0;

        // recorremos cada bloque del mapa por sus coordenadas en XY
        for (int i = minY; i < maxY; i++)
        {
            spaceX = 0; // reiniciamos el espacio entre cada bloque en X
            for (int j = minX; j < maxX; j++)
            {
                float xx = spaceX + j; // Guardamos las coordenadas X del bloque en turno
                float yy = spaceY + i; // Guardamos las coordenadas Y del bloque en turno

                // Si las coordenadas en XY coinciden con las recividas
                // estamos en el numero del arreglo al que pertenece el bloque
                if ( blockx == xx && blocky == yy) 
                {
                    // Actualizamos los valores del bloque...
                    id[countId] = Convert.ToString(blockx + "|" + blocky + "|" + block + "|" + typeblock);
                }
                countId += 1; // Incrementamos el arreglo en 1
                spaceX += 0.48f; 
            }
            spaceY += 0.55f;
        }
    }

    public void generarmapa()
    {
        //Primero creamos una estancia de StreamWriter.
        var txtLevel = new StreamWriter(Application.dataPath + "\\Levels/txt/Level"+nivel+".txt");

        // Recorremos el arreglo de las coordenadas de cada bloque
        foreach (var item in id)
        {
            txtLevel.WriteLine(item); // escribimos en una linea nueva las coordenadas de cada bloque
        }
        txtLevel.Close(); // cerramos el archivo de texto

        Debug.Log("---------------Mapa Generado--------------");

    }

}
