using UnityEngine;
using System.Collections;

public class ControlMiniMap : MonoBehaviour {

    string myname;
    float timeOver;
    bool scaleStar;
    float[, ,] plano = new float[12, 7, 2];

	void Start () {
        CrearCoordenadas();
        myname = this.name;
	}

    private void CrearCoordenadas()
    {
        float xx = 0, yy = 0;
        for (int j = 0; j < 7; j++)
        {
            xx = 0;
            for (int i = 0; i < 12; i++)
            {
                plano[i, j, 0] = -8.342f + xx;
                plano[i, j, 1] = 4.515f - yy;
                xx += 1.528f;
            }
            yy += 1.525f;
        }
    }

	// Update is called once per frame
	void Update () {
        if (this.name == "Lock(Clone)" || this.name == "Pass(Clone)")
            {
                if (Time.time > timeOver)
                {
                    if (scaleStar)
                    {
                        this.transform.localScale = new Vector3(1.68f,1.68f,0);
                        scaleStar = false;
                    }
                    else
                    {
                        this.transform.localScale = new Vector3(1.38f, 1.38f, 0);
                        scaleStar = true;
                    }
                timeOver = Time.time + 0.5f;    
                }
            }
	}

    void OnMouseDown()
    {
        if (myname == "btnSalto")
        {
            Application.LoadLevel("MapaGlobal");
        }

        if (myname == "Lock(Clone)" || this.name == "Pass(Clone)")
        {
            switch (Globales.word)
            {
                case "Ciudad(Clone)":
                    float[] lvlX = new float[] { plano[9, 5, 0], plano[10, 3, 0], plano[9, 1, 0], plano[6, 1, 0], plano[3, 1, 0], plano[2, 3, 0], plano[3, 5, 0], plano[5, 5, 0], plano[6, 3, 0], plano[7, 5, 0] };
                    float[] lvlY = new float[] { plano[9, 5, 1], plano[10, 3, 1], plano[9, 1, 1], plano[6, 1, 1], plano[3, 1, 1], plano[2, 3, 1], plano[3, 5, 1], plano[5, 5, 1], plano[6, 3, 1], plano[7, 5, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Agua(Clone)":
                    lvlX = new float[] { plano[1, 5, 0], plano[2, 3, 0], plano[3, 1, 0], plano[6, 1, 0], plano[7, 3, 0], plano[8, 5, 0], plano[10, 5, 0], plano[10, 3, 0], plano[10, 1, 0], plano[5, 5, 0] };
                    lvlY = new float[] { plano[1, 5, 1], plano[2, 3, 1], plano[3, 1, 1], plano[6, 1, 1], plano[7, 3, 1], plano[8, 5, 1], plano[10, 5, 1], plano[10, 3, 1], plano[10, 1, 1], plano[5, 5, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Volcan(Clone)":
                    lvlX = new float[] { plano[1, 2, 0], plano[1, 5, 0], plano[6, 5, 0], plano[10, 5, 0], plano[10, 1, 0], plano[6, 1, 0], plano[3, 1, 0], plano[3, 4, 0], plano[8, 4, 0], plano[6, 3, 0] };
                    lvlY = new float[] { plano[1, 2, 1], plano[1, 5, 1], plano[6, 5, 1], plano[10, 5, 1], plano[10, 1, 1], plano[6, 1, 1], plano[3, 1, 1], plano[3, 4, 1], plano[8, 4, 1], plano[6, 3, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Piramide(Clone)":
                    lvlX = new float[] { plano[2, 1, 0], plano[2, 5, 0], plano[5, 5, 0], plano[5, 1, 0], plano[8, 1, 0], plano[8, 5, 0], plano[10, 3, 0], plano[7, 3, 0], plano[4, 3, 0], plano[1, 3, 0] };
                    lvlY = new float[] { plano[2, 1, 1], plano[2, 5, 1], plano[5, 5, 1], plano[5, 1, 1], plano[8, 1, 1], plano[8, 5, 1], plano[10, 3, 1], plano[7, 3, 1], plano[4, 3, 1], plano[1, 3, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Torre(Clone)":
                    lvlX = new float[] { plano[10, 1, 0], plano[6, 1, 0], plano[2, 1, 0], plano[1, 3, 0], plano[2, 5, 0], plano[6, 5, 0], plano[10, 5, 0], plano[9, 3, 0], plano[7, 3, 0], plano[4, 3, 0] };
                    lvlY = new float[] { plano[10, 1, 1], plano[6, 1, 1], plano[2, 1, 1], plano[1, 3, 1], plano[2, 5, 1], plano[6, 5, 1], plano[10, 5, 1], plano[9, 3, 1], plano[7, 3, 1], plano[4, 3, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Bosque(Clone)":
                    lvlX = new float[] { plano[6, 1, 0], plano[6, 5, 0], plano[10, 5, 0], plano[10, 3, 0], plano[10, 1, 0], plano[2, 1, 0], plano[2, 3, 0], plano[2, 5, 0], plano[4, 5, 0], plano[7, 3, 0] };
                    lvlY = new float[] { plano[6, 1, 1], plano[6, 5, 1], plano[10, 5, 1], plano[10, 3, 1], plano[10, 1, 1], plano[2, 1, 1], plano[2, 3, 1], plano[2, 5, 1], plano[4, 5, 1], plano[7, 3, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Cueva(Clone)":
                    lvlX = new float[] { plano[10, 5, 0], plano[6, 5, 0], plano[2, 5, 0], plano[2, 3, 0], plano[6, 3, 0], plano[10, 3, 0], plano[10, 1, 0], plano[6, 1, 0], plano[2, 1, 0], plano[4, 4, 0] };
                    lvlY = new float[] { plano[10, 5, 1], plano[6, 5, 1], plano[2, 5, 1], plano[2, 3, 1], plano[6, 3, 1], plano[10, 3, 1], plano[10, 1, 1], plano[6, 1, 1], plano[2, 1, 1], plano[4, 4, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "Montaña(Clone)":
                    lvlX = new float[] { plano[1, 5, 0], plano[2, 3, 0], plano[3, 1, 0], plano[6, 1, 0], plano[9, 1, 0], plano[10, 3, 0], plano[10, 5, 0], plano[7, 5, 0], plano[4, 5, 0], plano[6, 3, 0] };
                    lvlY = new float[] { plano[1, 5, 1], plano[2, 3, 1], plano[3, 1, 1], plano[6, 1, 1], plano[9, 1, 1], plano[10, 3, 1], plano[10, 5, 1], plano[7, 5, 1], plano[4, 5, 1], plano[6, 3, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "NubeNegra(Clone)":
                    lvlX = new float[] { plano[10, 1, 0], plano[9, 3, 0], plano[8, 5, 0], plano[5, 5, 0], plano[5, 3, 0], plano[7, 1, 0], plano[4, 1, 0], plano[3, 3, 0], plano[3, 5, 0], plano[1, 5, 0] };
                    lvlY = new float[] { plano[10, 1, 1], plano[9, 3, 1], plano[8, 5, 1], plano[5, 5, 1], plano[5, 3, 1], plano[7, 1, 1], plano[4, 1, 1], plano[3, 3, 1], plano[3, 5, 1], plano[1, 5, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;

                case "portal(Clone)":
                    lvlX = new float[] { plano[6, 3, 0], plano[6, 5, 0], plano[10, 5, 0], plano[10, 2, 0], plano[8, 1, 0], plano[3, 1, 0], plano[1, 3, 0], plano[2, 5, 0], plano[4, 5, 0], plano[4, 3, 0] };
                    lvlY = new float[] { plano[6, 3, 1], plano[6, 5, 1], plano[10, 5, 1], plano[10, 2, 1], plano[8, 1, 1], plano[3, 1, 1], plano[1, 3, 1], plano[2, 5, 1], plano[4, 5, 1], plano[4, 3, 1] };
                    GoToLevel(lvlX, lvlY);
                    break;
            }
        }
    }

    void GoToLevel(float[] lvlX, float[] lvlY)
    {
        for (int i = 0; i < 10; i++)
        {
            if (lvlX[i] == this.transform.position.x && lvlY[i] == this.transform.position.y)
            {
                Globales.nivel = i + 1;
                Application.LoadLevel("PreLevel");
            }
        }
    }
}
