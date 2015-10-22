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
    public string nivel;
    int moveSpeed = 300;
    int countId = 0;
    
   	void Start () {
        for (int i = minY; i < maxY; i++)
        {
            spaceX = 0;
            for (int j = minX; j < maxX; j++)
            {
                Instantiate(superBlockMaster, new Vector3(spaceX + j, spaceY + i , -1), transform.rotation);
                id[countId] = "0|0|0|0";
                spaceX += 0.48f;
                countId += 1;
            }
            spaceY += 0.55f;
        }        
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightArrow)) transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow)) transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.DownArrow)) transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) generarmapa();
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
                    id[countId] = Convert.ToString(blockx + "|" + blocky + "|" + block + "|" + typeblock);
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
        var txtLevel = new StreamWriter(Application.dataPath + "\\Levels/txt/Level"+nivel+".txt");

        foreach (var item in id)
        {
            txtLevel.WriteLine(item);
        }
        txtLevel.Close();
        Debug.Log("---------------Mapa Generado--------------");

    }

}
