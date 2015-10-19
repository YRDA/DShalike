using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

public class mapGenerator : MonoBehaviour {
    
    public GameObject gamePlayer,groundSup,groundInf,waterSup,waterInf,lavaSup,lavaInf,rockSup,rockInf;


    int[] grid;


	// Use this for initialization
	void Start () {
        //crearpiso();
        GenerarMapa();
	}

	// Update is called once per frame
	void Update () {
     
	}

    private void GenerarMapa()
    {
        try
        {
            bool endTxt = true;
            string linea;
            //Primero creamos una estancia de StreamWriter.
            var txtLevel = new StreamReader(Application.dataPath + "\\Levels/txt/Level01.txt");

            while (endTxt)
            {
                linea = txtLevel.ReadLine();
                if (linea == null) endTxt = false;

                string[] b = linea.Split("|"[0]);

                float blockX,blockY;
                
                float.TryParse(b[0],out blockX);
                float.TryParse(b[1], out blockY);
                
                if (Convert.ToInt16(b[2]) == 1)
                {
                    #region Switch block
                    switch (b[3])
                    {
                        case "0":
                            Instantiate(gamePlayer, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "1":
                            Instantiate(groundSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "2":
                            Instantiate(groundInf, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "3":
                            Instantiate(waterSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "4":
                            Instantiate(waterInf, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "5":
                            Instantiate(lavaSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "6":
                            Instantiate(lavaInf, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "7":
                            Instantiate(rockSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "8":
                            Instantiate(rockInf, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "9":
                            Instantiate(groundSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "10":
                            Instantiate(groundSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;
                        case "11":
                            Instantiate(groundSup, new Vector3(blockX, blockY, -1), transform.rotation);
                            break;

                        default:
                            break;
                    }
                    #endregion
                }
            }

            txtLevel.Close();  
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    static void escribir(float x, float y, int block, int typeBlock)
    {
        string strX, strY, strBlock, strTypeBlock;
        strX = x.ToString();
        strY = y.ToString();
        strBlock = block.ToString();
        strTypeBlock = typeBlock.ToString();

        //Primero creamos una estancia de StreamWriter.

        var txtLevel = new StreamWriter(Application.dataPath + "\\Levels/txt/Level01.txt", true);

        // (path , true) true = escribir bajo lo ya escrito

        //A partir de aqui, escribimos lo que queramos
        txtLevel.WriteLine(strX + "|" + strY + "|" + strBlock + "|" + strTypeBlock);

        //Cerramos la instancia de StreamWriter
        txtLevel.Close();
    }
   
    private void crearpiso()
    {
        float spacey = 0f;

        for (int j = -15; j < 15; j++)
        {
            float spacex = 0f;

            for (int i = -100; i < 6; i++)
            {
                if (j < -10 && j < -9)
                {
                    Instantiate(groundInf, new Vector3(i + spacex, j + spacey, -1), transform.rotation);
                }
                else
                {
                    if (j < -9)
                    {
                        Instantiate(groundSup, new Vector3(i + spacex, j + spacey, -1), transform.rotation);
                    }
                }
                spacex += 0.18f;
            }
            spacey += 0.225f;
        }
    }
}

