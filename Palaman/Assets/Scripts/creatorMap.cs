using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class creatorMap : MonoBehaviour {

    int maxX = 18, minX = -49, maxY = 4, minY = -11;
    public GameObject superBlockMaster;
    float spaceX = 0.0f;
    float spaceY = 0.0f;
    public string[] id = new string[1006];
    int countId = 0;

    void Update()
    {
        generarmapa();
    }

   	void Start () {
        for (int i = minY; i < maxY; i++)
        {
            spaceX = 0;
            for (int j = minX; j < maxX; j++)
            {
                Instantiate(superBlockMaster, new Vector3(spaceX + j, spaceY + i , -1), transform.rotation);
                id[countId] = "0|0|1|1";
                spaceX += 0.48f;
                countId += 1;
            }
            spaceY += 0.55f;
        }        
	}

    public void actualizarvalues(float blockx,float blocky,int block, int typeblock)
    {
        countId = 0;
        spaceY = 0;

        for (int i = minY; i < maxY; i++)
        {
            spaceX = 0;
            for (int j = minX; j < maxX; j++)
            {
                float xx = spaceX + j;
                float yy = spaceY + i;
                if ( blockx == xx && blocky == yy)
                {
                    string stringblock = Convert.ToString(blockx + "|" + blocky + "|" + block + "|" + typeblock);
                    id[countId] = stringblock;
                    Debug.Log(id[countId]);
                }
                countId += 1;
                spaceX += 0.48f;
            }
            spaceY += 0.55f;
        }
    }

    public void generarmapa()
    {
        //Primero creamos una estancia de StreamWriter.
        var txtLevel = new StreamWriter(Application.dataPath + "\\Levels/txt/Level01.txt");

        foreach (var item in id)
        {
            txtLevel.WriteLine(item);
        }
        txtLevel.Close();
        Debug.Log("---------------Mapa Generado--------------");

    }

}
