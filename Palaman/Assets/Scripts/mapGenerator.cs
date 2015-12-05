using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

public class MapGenerator : MonoBehaviour {

    public GameObject point;
    public string nivel;
    float difBlockY = 1.736548f;
    float[] blokX = new float[1006];
    public Transform blockExist;
    public LayerMask isBlock;

    public GameObject superBlock;
    public GameObject groundSup;
    public GameObject groundInf;
    public GameObject waterSup;
    public GameObject waterInf;
    public GameObject lavaSup;
    public GameObject lavaInf;
    public GameObject rockSup;
    public GameObject rockInf;
    public GameObject groundCave;

	void Start () {
        GenerarMapa();
	}

    private void GenerarMapa()
    {
        int i = 0;
        try
        {
            bool endTxt = true;
            string linea;

            // iniciamos un streamReader del archivo de texto para el nivel
            var txtLevel = new StreamReader(Application.dataPath + "\\Levels/txt/Level"+nivel+".txt");

            while (endTxt) // Se repite el codigo hasta que ya no haya texto que leer
            {
                linea = txtLevel.ReadLine(); // guardamos la linea leida

                if (linea == null) endTxt = false; // si la linea esta vacia el archivo se termino

                // Separamos el string por el caracter | y lo guardamos en el arreglo dateblock
                string[] dateBlock = linea.Split("|"[0]); 

                float blockX,blockY;

                // Convertimos el las coordenadas de string en flotante y lo guardamos en blockX
                float.TryParse(dateBlock[0], out blockX);
                // Convertimos el las coordenadas de string en flotante y lo guardamos en blockY
                float.TryParse(dateBlock[1], out blockY);

                //********************************************************
                // Funcion para obetener las coordenadas en X de cada bloque
                // para el calculo para saber donde colocar bloques nuevos
                if (i < 1006) 
                {
                    blokX[i] = blockX; // Guardamos en el arreglo las coordenadas de X
                    i += 1;            // Incrementamos el contador i
                }
                //********************************************************
                 
                // Debe de existir bloque 0:No 1:Si
                if (Convert.ToInt16(dateBlock[2]) == 1)
                {
                    // Creamos el bloque pasando las coordenadas y el tipo de bloque que se colocara
                    CrearBloques(blockX, blockY, dateBlock[3]); 
                }
            }

            txtLevel.Close();  // cerramos el archivo de texto
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    void CrearBloques(float blkX,float blkY,String tyBl){

        #region Switch block
        switch (tyBl) // Entramos en un switch para saber que tipo de bloque colocaremos
        {
            case "0": // Super bloque
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "1": // Tierra sup
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "2": // Tierra inf
                Instantiate(groundInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "3": // Agua sup
                Instantiate(waterSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "4": // Agua Inf
                Instantiate(waterInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "5": // Lava sup
                Instantiate(lavaSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "6": // Lava inf
                Instantiate(lavaInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "7": // Roca sup
                Instantiate(rockSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "8": // Roca inf
                Instantiate(rockInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "9": // Tierra de cueva
                Instantiate(groundCave, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "10": // 
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "11": //
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "12": //
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;

            default:
                break;
        }
        #endregion
    }

    #region Colocacion del Bloque Diagrama
    /*****************************************************************************************
     * 1) Primero nos ubicamos en las coordenadas X y calculamos mi posicion
     *
     *   x> ☻ <x1
     * ▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣
     * 
     * 2) Hacia donde estoy viendo y verifico si existe un bloque delante-atras ABAJO
     * 
     *     ☻ 
     * ▣▣X▣X▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣
     * 
     * 3) Si no existe lo coloco si no...
     * 
     *     ☻ 
     * ▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣
     * 
     * 4) Verifico delante-atras del personaje
     * 
     *    X☻X
     * ▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣
     * 
     * 
     * 5) Y coloco si no existe un bloque
     * 
     *    ▣☻▣
     * ▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣▣
     * 
     ******************************************************************************************/
    #endregion

    public void UbicacionPersonaje(float playerX, float playerY, bool righ)
    {
        // recorremos el arreglo de las coordenadas de cada bloque en X
        for (int i = 0; i < blokX.Length; i++)
        {
            // si estamos dentro de las coordenadas en X de 2 boques
            if (blokX[i] < playerX && blokX[i + 1] > playerX)
            {
                float media = (blokX[i + 1] - blokX[i]) / 2; // calculamos la distancia entre ambos bloques
                if ( blokX[i] - media < playerX && playerX < blokX[i] + media ) // si estamos en el primer bloque
                {
                    CalculoBloque(i, playerY, righ);
                }
                else
                {
                    if (blokX[i] + media < playerX && playerX < blokX[i + 1] + media) // si estamos en el segundo
                    {
                        CalculoBloque(i+1, playerY, righ);
                    }
                }
                //Instantiate(point, new Vector2(blokX[i] - media, playerY - difBlockY), transform.rotation);
                //Instantiate(point, new Vector2(blokX[i] + media, playerY - difBlockY), transform.rotation);
                //Instantiate(point, new Vector2(blokX[i + 1] + media, playerY - difBlockY), transform.rotation);
                break;
            }
        }
    }

    void CalculoBloque(int i , float BY,bool righ2)
    {
        if (righ2)
        {
            // muevo el verificador de bloque adelante-abajo
            blockExist.transform.position = new Vector3(blokX[i + 1], BY - difBlockY, 0);
            // si existe bloque adelante-bajo de nuestra posicion
            if (Physics2D.OverlapCircle(blockExist.position, 0.3f, isBlock))
            {
                // muevo el verificador de bloque adelante
                blockExist.transform.position = new Vector3(blokX[i + 1], BY, 0);
                // si no existe bloque adelante de nuestra posicion
                if (!Physics2D.OverlapCircle(blockExist.position, 0.3f, isBlock))
                    CrearBloques(blokX[i + 1], (BY - difBlockY) + 1.55f, "1");  // creamos bloque frente a nosotros              
            }
            else
                CrearBloques(blokX[i + 1], BY - difBlockY, "1"); // creamos bloque enfrente-abajo
        }
        else
        {
            // muevo el verificador de bloque adelante-abajo
            blockExist.transform.position = new Vector3(blokX[i - 1], BY - difBlockY, 0);
            // si existe bloque adelante-bajo de nuestra posicion
            if (Physics2D.OverlapCircle(blockExist.position, 0.3f, isBlock))
            {
                // muevo el verificador de bloque adelante
                blockExist.transform.position = new Vector3(blokX[i - 1], BY, 0);
                // si no existe bloque adelante de nuestra posicion
                if (!Physics2D.OverlapCircle(blockExist.position, 0.3f, isBlock))
                    CrearBloques(blokX[i - 1], (BY - difBlockY) + 1.55f, "1"); // creamos bloque atras
            }
            else
                CrearBloques(blokX[i - 1], BY - difBlockY, "1"); // creamos bloque atras-abajo
        }
        Destroy(GameObject.Find("checkBlockExist(Clone)")); // destruyo el verficador de que existe un bloque
    }
}

