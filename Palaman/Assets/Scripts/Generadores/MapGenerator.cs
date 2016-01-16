using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

public class MapGenerator : MonoBehaviour {

    public GameObject point;
    float difBlockY = 1.618729f;
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
    public GameObject madera,madera2;

    string[] datos;

	void Start () {
        GenerarMapa();
	}

    private void GenerarMapa()
    {
        string lvl;
        Globales dir = GameObject.Find("GlobalesGO").GetComponent<Globales>();
        lvl = Globales.word + Globales.nivel ;
        datos = dir.DatosNivel(lvl).Split("|"[0]);
        try
        {
            for (int i = 0; i < datos.Length; i++)
            {
                float x, y;
                float.TryParse(datos[i], out x);
                float.TryParse(datos[i + 1], out y);

                if (datos[i + 2] == "1")
                    CrearBloques(x, y, datos[i + 3]);

                i += 3;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);   
        }

        Debug.Log(lvl);
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
                Instantiate(madera, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "11": //
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "12": //
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "13":
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
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

    public void UbicacionPersonaje(float playerX, float playerY, bool righ,int tipoBloque)
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
                    CalculoBloque(i, playerY, righ,tipoBloque);
                }
                else
                {
                    if (blokX[i] + media < playerX && playerX < blokX[i + 1] + media) // si estamos en el segundo
                    {
                        CalculoBloque(i+1, playerY, righ,tipoBloque);
                    }
                }
                //Instantiate(point, new Vector2(blokX[i] - media, playerY - difBlockY), transform.rotation);
                //Instantiate(point, new Vector2(blokX[i] + media, playerY - difBlockY), transform.rotation);
                //Instantiate(point, new Vector2(blokX[i + 1] + media, playerY - difBlockY), transform.rotation);
                break;
            }
        }
    }

    void CalculoBloque(int i , float BY,bool righ2, int tipo)
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
                    if(tipo != 4)
                    BloquesInventario(blokX[i + 1], (BY - difBlockY) + 1.55f, tipo);  // creamos bloque frente a nosotros              
            }
            else
                BloquesInventario(blokX[i + 1], BY - difBlockY, tipo); // creamos bloque enfrente-abajo
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
                    if (tipo != 4)
                    BloquesInventario(blokX[i - 1], (BY - difBlockY) + 1.55f, tipo); // creamos bloque atras
            }
            else
                BloquesInventario(blokX[i - 1], BY - difBlockY, tipo); // creamos bloque atras-abajo
        }
        Destroy(GameObject.Find("checkBlockExist(Clone)")); // destruyo el verficador de que existe un bloque
    }

    public void BloquesInventario(float blkX, float blkY, int tyBl)
    {
        player palaman = GameObject.Find("Shalike").GetComponent<player>();
        palaman.cubo[palaman.BlocInkUse].pzas--;
        #region Switch block
        switch (tyBl) // Entramos en un switch para saber que tipo de bloque colocaremos
        {
            case 0: // Super bloque
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 1: // Tierra sup
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 2: // Tierra inf
                Instantiate(groundCave, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 3: // Agua sup
                Instantiate(rockSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 4: // Agua Inf
                Instantiate(madera2, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 5: // Lava sup
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 6: // Lava inf
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 7: // Roca sup
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 8: // Roca inf
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 9: // Tierra de cueva
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 10: // 
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 11: //
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 12: //
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case 13:
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;

            default:
                break;
        }
        #endregion
    }
}
