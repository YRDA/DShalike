using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

public class mapGenerator : MonoBehaviour {
    
    public GameObject superBlock,groundSup,groundInf,waterSup,waterInf,lavaSup,lavaInf,rockSup,rockInf;
    public string nivel;

	// Use this for initialization
	void Start () {
        GenerarMapa();
	}

    private void GenerarMapa()
    {
        try
        {
            bool endTxt = true;
            string linea;
            //Primero creamos una estancia de StreamWriter.
            var txtLevel = new StreamReader(Application.dataPath + "\\Levels/txt/Level"+nivel+".txt");


            while (endTxt)
            {
                linea = txtLevel.ReadLine();
                Debug.Log(linea);

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
                            Instantiate(superBlock, new Vector3(blockX, blockY, -1), transform.rotation);
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
   
}

