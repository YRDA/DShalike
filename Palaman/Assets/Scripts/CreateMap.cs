using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour {
    
    public int width = 31;
    public int height = 171;

    public GameObject groundSup,groundInf,waterSup,waterInf;


    int[] grid;


	// Use this for initialization
	void Start () {
        GenerarMapa();
	}

    private void GenerarMapa()
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
            spacey += 0.18f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Editormapa();
	}

    private void Editormapa()
    {
        
    }
}
