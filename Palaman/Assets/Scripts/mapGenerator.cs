using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

public class mapGenerator : MonoBehaviour {

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

            var txtLevel = new StreamReader(Application.dataPath + "\\Levels/txt/Level"+nivel+".txt");

            while (endTxt)
            {
                linea = txtLevel.ReadLine();

                if (linea == null) endTxt = false;

                string[] b = linea.Split("|"[0]);

                float blockX,blockY;
                
                float.TryParse(b[0],out blockX);
                float.TryParse(b[1], out blockY);

                if (i < 1006)
                {
                    blokX[i] = blockX;
                    i += 1;    
                }
                

                if (Convert.ToInt16(b[2]) == 1)
                {
                    CrearBloques(blockX, blockY, b[3]);
                }
            }

            txtLevel.Close();  
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    void CrearBloques(float blkX,float blkY,String tyBl){

        #region Switch block
        switch (tyBl)
        {
            case "0":
                Instantiate(superBlock, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "1":
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "2":
                Instantiate(groundInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "3":
                Instantiate(waterSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "4":
                Instantiate(waterInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "5":
                Instantiate(lavaSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "6":
                Instantiate(lavaInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "7":
                Instantiate(rockSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "8":
                Instantiate(rockInf, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "9":
                Instantiate(groundCave, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "10":
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "11":
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;
            case "12":
                Instantiate(groundSup, new Vector3(blkX, blkY, -1), transform.rotation);
                break;

            default:
                break;
        }
        #endregion
    }

    public void CalculoBloque(float playerX, float playerY, bool righ)
    {
        float Bloque1, Bloque2, Media;
        for (int i = 0; i < blokX.Length; i++)
        {
            if (blokX[i] < playerX && blokX[i + 1] > playerX)
            {
                Bloque1 = blokX[i];
                Bloque2 = blokX[i + 1];
                Media = (Bloque1 - Bloque2) / 2;


                    if (righ)
                    {
                        blockExist.transform.position = new Vector3(Bloque1 + 1.48f, playerY - difBlockY, 0);
                        if (Physics2D.OverlapCircle(blockExist.position, 0.3f, isBlock))
                            CrearBloques(Bloque1 + 1.48f, (playerY - difBlockY) + 1.55f, "9");
                        else
                            CrearBloques(Bloque1 + 1.48f, (playerY - difBlockY) , "9");
                    }
                    else
                    {
                        blockExist.transform.position = new Vector3(Bloque1 - 1.48f, playerY - difBlockY, 0);
                        if (Physics2D.OverlapCircle(blockExist.position, 0.3f, isBlock))
                            CrearBloques(Bloque1 - 1.48f, (playerY - difBlockY) + 1.55f, "9");
                        else
                            CrearBloques(Bloque1 - 1.48f, (playerY - difBlockY), "9");
                    }
                    Destroy(GameObject.Find("checkBlockExist(Clone)"));

                break;
            }
        }
    }

}

