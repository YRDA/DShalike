﻿using UnityEngine;
using System.Collections;
using System.IO;

public class AnimaMapa : MonoBehaviour {

    float Xposition, Yposition;
    public float timeOver, timeOver2 = 5 , timex = 0.5f;
    public float scaleSmog = 0.5f;
    string namePza;
    public GameObject gota, cubo;
    public bool rigth;

    public int contadorX = 0,contadorY = 0;
    float spaceX = 0.5f, spaceY = 0.5f;
    public int  contaTimer,maX = 22, maxY = 12;
    float cuboX = 9.0f, cuboY = 4.61f;
    bool boolpantalla = false;
    public string mundo;
    public GameObject[] pzaMundo = new GameObject[10];

    AnimaMapa pausa;

    void Start()
    {
        pausa = GameObject.Find("btnJugar").GetComponent<AnimaMapa>();
        Xposition = this.transform.position.x;
        Yposition = this.transform.position.y;
        if (this.name == "btnJugar")
        {
            mundo = "Ciudad(Clone)";
            dibujarMapa();
        }
    }

    private void dibujarMapa()
    {
        float[] mundoX = new float[] { 0.98f, -6.43f, 6.77f, -3.98f, 4.96f, -5.9f, 0.23f, 0.85f, 4.57f, 5.59f };
        float[] mundoY = new float[] { 0.707f, -3.56f, 1.5f, 3.48f, -3.41f, -0.61f, 4.12f, -1.94f, -0.74f, 3.81f };
        string direccion = pathForDocumentsFile("Dates.txt");
        var txtRead = new StreamReader(direccion);
        string[] datos = txtRead.ReadLine().Split("|"[0]);

        Instantiate(pzaMundo[0], new Vector3(mundoX[0], mundoY[0], 0), transform.rotation);
        Instantiate(pzaMundo[1], new Vector3(mundoX[1], mundoY[1], 0), transform.rotation);
        Instantiate(pzaMundo[2], new Vector3(mundoX[2], mundoY[2], 0), transform.rotation);
        Instantiate(pzaMundo[3], new Vector3(mundoX[3], mundoY[3], 0), transform.rotation);
        Instantiate(pzaMundo[4], new Vector3(mundoX[4], mundoY[4], 0), transform.rotation);


        //Naturaleza
        if (datos[5] == "1" && datos[7] == "1")
        {
            Instantiate(pzaMundo[5], new Vector3(mundoX[5], mundoY[5], 0), transform.rotation);
        }

        // Acero
        if (datos[6] == "1" && datos[7] == "1")
        {
            Instantiate(pzaMundo[6], new Vector3(mundoX[6], mundoY[6], 0), transform.rotation);
        }

        //Hielo
        if (datos[5] == "1" && datos[8] == "1")
        {
            Instantiate(pzaMundo[7], new Vector3(mundoX[7], mundoY[7], 0), transform.rotation);
        }

        //Electricidad
        if (datos[6] == "1" && datos[8] == "1")
        {
            Instantiate(pzaMundo[8], new Vector3(mundoX[8], mundoY[8], 0), transform.rotation);
        }

        if (datos[149] == "1")
        {
            Instantiate(pzaMundo[9], new Vector3(mundoX[9], mundoY[9], 0), transform.rotation);
        }
    }

	void Update () {

        namePza = this.name;

        if (!pausa.boolpantalla)
        {
            animaciones();
        }
        else
        {
            if (namePza == "btnJugar")
            {
                Pantallazo();
            }
        }
        
	}

    private void animaciones()
    {
        float speed = 0.02f;

        switch (namePza)
        {
            #region Remolinos
            case "Remolino_0":
                this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 200));
                break;
            case "Remolino_1":
                this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -150));
                break;
            case "Remolino_2":
                this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 100));
                break;
            #endregion

            #region Nubes
            case "Nubes":
                this.transform.position = new Vector3(Xposition + Mathf.Repeat(Time.time * speed, 0.1f), Yposition, 0);
                break;
            #endregion

            #region Smog Volcan
            case "Smog":

                if (Time.time > timeOver)
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                    timeOver = Time.time + timex;
                }
                else
                    if (Time.time > timeOver2)
                    {
                        timeOver2 = Time.time + timex;
                        this.transform.localScale = new Vector3(scaleSmog, scaleSmog, 0);
                    }

                break;
            case "Smog_1":

                if (Time.time > timeOver)
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                    timeOver = Time.time + timex;
                }
                else
                    if (Time.time > timeOver2)
                    {
                        timeOver2 = Time.time + timex;
                        this.transform.localScale = new Vector3(1, 1, 0);
                    }
                break;

            case "Smog_2":

                if (Time.time > timeOver)
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                    timeOver = Time.time + timex;
                }
                else
                    if (Time.time > timeOver2)
                    {
                        timeOver2 = Time.time + timex;
                        this.transform.localScale = new Vector3(1 + scaleSmog, 1 + scaleSmog, 0);
                    }
                break;
            #endregion

            #region Rayos
            case "rayos":
                if (Time.time > timeOver)
                {
                    this.transform.localScale = new Vector3(0, 0, 0);
                    timeOver = Time.time + Random.Range(0, 5);
                }
                else
                    if (Time.time > timeOver2)
                    {
                        timeOver2 = Time.time + timex;
                        this.transform.localScale = new Vector3(1, 1, 0);
                    }
                break;
            #endregion

            #region Nube Negra [lluvia]
            case "NubeNegra(Clone)":
                Instantiate(gota, new Vector3(this.transform.position.x + Random.Range(-0.6f, 0.6f), this.transform.position.y, 0), transform.rotation);
                Instantiate(gota, new Vector3(this.transform.position.x + Random.Range(-0.6f, 0.6f), this.transform.position.y, 0), transform.rotation);
                Instantiate(gota, new Vector3(this.transform.position.x + Random.Range(-0.6f, 0.6f), this.transform.position.y, 0), transform.rotation);
                Instantiate(gota, new Vector3(this.transform.position.x, this.transform.position.y, 0), transform.rotation);
                Instantiate(gota, new Vector3(this.transform.position.x + Random.Range(-0.0f, 0.2f), this.transform.position.y, 0), transform.rotation);
                Instantiate(gota, new Vector3(this.transform.position.x + Random.Range(-0.3f, 0.3f), this.transform.position.y, 0), transform.rotation);
                break;
            #endregion

            #region Aldeanos
            case "Aldeano":
                if (Time.time > timeOver)
                {
                    timeOver = Time.time + 0.5f;

                    if (rigth)
                        rigth = false; // Regresamos por la izquierda
                    else
                        rigth = true; // regresamos por la derecha
                }
                if (rigth) // vamos para la derecha?
                {
                    // avanzamos hacia la derecha
                    transform.position = new Vector3(transform.position.x + Random.Range(0.01f, 0.02f), transform.position.y, transform.position.z);
                }
                else
                {
                    // avanzamos hacia la izquierda
                    transform.position = new Vector3(transform.position.x - Random.Range(0.01f, 0.02f), transform.position.y, transform.position.z);
                }
                break;

            case "Aldeano_1":
                if (Time.time > timeOver)
                {
                    timeOver = Time.time + 0.5f;

                    if (rigth)
                        rigth = false; // Regresamos por la izquierda
                    else
                        rigth = true; // regresamos por la derecha
                }
                if (rigth) // vamos para la derecha?
                {
                    // avanzamos hacia la derecha
                    transform.position = new Vector3(transform.position.x + Random.Range(0.01f, 0.02f), transform.position.y, transform.position.z);
                }
                else
                {
                    // avanzamos hacia la izquierda
                    transform.position = new Vector3(transform.position.x - Random.Range(0.01f, 0.02f), transform.position.y, transform.position.z);
                }
                break;
            #endregion

            #region Putero Giro
            case "Arrow":
                this.transform.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
                break;
            #endregion

            #region Portal completo
            case "portal_":
                this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 100));
                break;

            case "fire":
                if (Time.time > timeOver)
                {
                    this.transform.Rotate(new Vector3(0, 180, 0));
                    timeOver = Time.time + timex;
                }
                else
                    if (Time.time > timeOver2)
                    {
                        timeOver2 = Time.time + timex;
                        this.transform.Rotate(new Vector3(0, 180, 0));
                    }
                break;
            #endregion
        }	
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (namePza == "gota(Clone)")
        {
            Destroy(this.gameObject);    
        }
        
    }

    void OnMouseDown()
    {
        if (namePza == "btnJugar")
        {
            boolpantalla = true;
        }
        else
        {
            if (!pausa.boolpantalla)
            {
                if (namePza == "NubeNegra(Clone)" || namePza == "Agua(Clone)" || namePza == "Cueva(Clone)")
                {
                    GameObject.Find("Arrow").transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
                    pausa.mundo = namePza;
                }
                else
                {
                    if (namePza == "Piramide(Clone)" || namePza == "Bosque(Clone)")
                    {
                        GameObject.Find("Arrow").transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.7f);
                        pausa.mundo = namePza;
                    }
                    else
                    {
                        GameObject.Find("Arrow").transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1);
                        pausa.mundo = namePza;
                    }
                }
            }
        }
    }

    void Pantallazo()
    {
        #region cubo Negro
        switch (contaTimer)
        {
            case 0:
                for (int i = 0; i < maX; i++)
                {
                    if (Time.time > timeOver && contadorX == i)
                    {
                        timeOver = Time.time + 0.00005f;
                        Instantiate(cubo, new Vector3(-cuboX + spaceX, cuboY, 0), transform.rotation);
                        spaceX = spaceX + 0.8f;
                        contadorX += 1;
                    }
                    if (contadorX == maX)
                    {
                        contaTimer = 1;
                    }
                }
                break;

            case 1:
                if (maX != 10)
                {
                    for (int i = 0; i < maxY; i++)
                    {
                        if (Time.time > timeOver && contadorY == i)
                        {
                            timeOver = Time.time + 0.00005f;
                            Instantiate(cubo, new Vector3(-cuboX + (spaceX - 0.8f), cuboY - spaceY, 0), transform.rotation);
                            spaceY = spaceY + 0.8f;
                            contadorY += 1;
                        }
                        if (contadorY == maxY)
                        {
                            contadorX = 0;
                            spaceX = 0.5f;
                            contaTimer = 2;
                        }
                    }
                }
                else
                {
                    Globales.word = mundo;
                    Application.LoadLevel("Mini Mapa");
                }
                break;
            case 2:
                for (int i = 0; i < maX; i++)
                {
                    if (Time.time > timeOver && contadorX == i)
                    {
                        timeOver = Time.time + 0.00005f;
                        Instantiate(cubo, new Vector3(cuboX - spaceX, cuboY - (spaceY - 0.8f), 0), transform.rotation);
                        spaceX = spaceX + 0.8f;
                        contadorX += 1;
                    }
                    if (contadorX == maX)
                    {
                        contadorY = 0;
                        spaceY = 0.5f;
                        contaTimer = 3;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < maxY; i++)
                {
                    if (Time.time > timeOver && contadorY == i)
                    {
                        timeOver = Time.time + 0.00005f;
                        Instantiate(cubo, new Vector3(cuboX - (spaceX - 0.8f), -cuboY + spaceY, 0), transform.rotation);
                        spaceY = spaceY + 0.8f;
                        contadorY += 1;
                    }
                    if (contadorY == maxY)
                    {
                        maX -= 2;
                        maxY -= 2;
                        contadorX = 0;
                        contadorY = 0;
                        spaceY = 0.5f;
                        spaceX = 0.5f;
                        cuboX -= 0.8f;
                        cuboY -= 0.8f;
                        contaTimer = 0;
                    }
                }
                break;
        }
        #endregion
    }

    public string pathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            return Path.Combine(path, filename);
        }

        else
        {
            string path = Application.dataPath;
            return Path.Combine(Path.Combine(path, "Levels/txt/"), filename);
        }
    }
}
