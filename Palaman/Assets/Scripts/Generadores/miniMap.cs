using UnityEngine;
using System.Collections;
using System.IO;

public class miniMap : MonoBehaviour
{
    string world = Globales.word;
    int mundo;
    Animator anima;
    public GameObject curva_, lock_, panel_, pass_, barra_;
    float[,,] plano = new float[12,7,2];

    void Start()
    {
        anima = this.gameObject.GetComponent<Animator>();
        CrearCoordenadas();
        cambioTipoMundo();
        DibujarMiniMapa();
    }

    private void CrearCoordenadas()
    {
        float xx = 0, yy = 0;
        for (int j = 0; j < 7; j++)
        {
            xx = 0;
            for (int i = 0; i < 12; i++)
            {
                plano[i, j,0] = -8.342f + xx;
                plano[i, j,1] = 4.515f - yy;
                xx += 1.528f;
            }
            yy += 1.525f;
        }
    }

    private void DibujarMiniMapa()
    {
        switch (mundo)
        {
            case 0:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(141, 151);
                break;
            case 1:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(51,61);
                break;

            case 2:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(61, 71);
                break;
            case 3:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(71, 81);
                break;
            case 4:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(81, 91);
                break;
            case 5:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(91, 101);
                break;
            case 6:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(101, 111);
                break;
            case 7:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(111, 121);
                break;
            case 8:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(121, 131);
                break;
            case 9:
                anima.SetInteger("Mapeo", mundo);
                CargaNiveles(131, 141);
                break;

            default:
                break;
        }
    }

    void cambioTipoMundo()
    {
        switch (world)
        {
            case "Ciudad(Clone)":
                mundo = 0;
                break;

            case "Agua(Clone)":
                mundo = 1;
                break;

            case "Volcan(Clone)":
                mundo = 2;
                break;

            case "Piramide(Clone)":
                mundo = 3;
                break;

            case "Torre(Clone)":
                mundo = 4;
                break;

            case "Bosque(Clone)":
                mundo = 5;
                break;

            case "Cueva(Clone)":
                mundo = 6;
                break;

            case "Montaña(Clone)":
                mundo = 7;
                break;

            case "NubeNegra(Clone)":
                mundo = 8;
                break;

            case "portal(Clone)":
                mundo = 9;
                break;
            default: 
                mundo = 6;
                break;
        }
    }

    void CargaNiveles(int inicio, int final){
        Globales dir = GameObject.Find("GlobalesGO").GetComponent<Globales>();
        string direccion = dir.pathForDocumentsFile("Dates.txt");
        var txtRead = new StreamReader(direccion);
        string[] datos = txtRead.ReadLine().Split("|"[0]);
        txtRead.Close();
        int lastlvl = 0;
        for (int i = inicio; i < final; i++)
                {
                    if (datos[i] == "1")
                    {
                        Niveles(i, 1);
                        lastlvl = i;
                    }
                }
                if (lastlvl == 0)
                    Niveles(inicio, 0);    
                else
                    Niveles(lastlvl + 1, 0);
    }

    void Niveles(int lvl, int unLock)
    {
        switch (lvl)
        {

            #region //-----------------------------------------> MUNDO 1  51-60 <-----------------------------------------//
            case 51:
                #region Nivel 1-1
                Ajustador(plano[0, 5, 0], plano[0, 5, 1], 3, 90, unLock); // Barra
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 1, 0, unLock);  // Panel
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 2, 0, unLock);  // Nivel
                #endregion
                break;
            case 52:
                #region Nivel 1-2
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 1, 0, unLock);  // Panel
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 2, 0, unLock);  // Nivel
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 3, 0, unLock); // Barra
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 4, 0, unLock); // Curva
                #endregion
                break;
            case 53:
                #region Nivel 1-3
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 1, 0, unLock);  // Panel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 2, 0, unLock);  // Nivel
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 3, 0, unLock); // Barra
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 4, 0, unLock); // Curva
                #endregion
                break;
            case 54:
                #region Nivel 1-4
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock); // Plano
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock); // Nivel                
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock); // Barra               
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock); // Barra                
                #endregion
                break;
            case 55:
                #region Nivel 1-5
                Ajustador(plano[7,3,0], plano[7,3,1], 1, 0, unLock);// Plano
                Ajustador(plano[7,3,0], plano[7,3,1], 2, 0, unLock);// Nivel
                Ajustador(plano[6,2,0], plano[6,2,1], 3, 0, unLock);// Barra
                Ajustador(plano[6,3,0], plano[6,3,1], 4, 270, unLock);// Curva
                #endregion
                break;
            case 56:
                #region Nivel 1-6
                Ajustador(plano[8,5,0], plano[8,5,1], 1, 0, unLock);// Plano
                Ajustador(plano[8,5,0], plano[8,5,1], 2, 0, unLock);// Nivel
                Ajustador(plano[7,4,0], plano[7,4,1], 3, 0, unLock);// Barra
                Ajustador(plano[7,5,0], plano[7,5,1], 4, 270, unLock);// Curva
                #endregion
                break;
            case 57:
                #region Nivel 1-7
                Ajustador(plano[10,5,0], plano[10,5,1], 1, 0, unLock);// Plano
                Ajustador(plano[10,5,0], plano[10,5,1], 2, 0, unLock);// Nivel
                Ajustador(plano[9,5,0], plano[9,5,1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 58:
                #region Nivel 1-8
                Ajustador(plano[10,3,0], plano[10,3,1], 1, 0, unLock);// Plano
                Ajustador(plano[10,3,0], plano[10,3,1], 2, 0, unLock);// Nivel
                Ajustador(plano[10,4,0], plano[10,4,1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 59:
                #region Nivel 1-9
                Ajustador(plano[10,1,0], plano[10,1,1], 1, 0, unLock);// Plano
                Ajustador(plano[10,1,0], plano[10,1,1], 2, 0, unLock);// Nivel
                Ajustador(plano[10,2,0], plano[10,2,1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 60:
                #region Nivel 1-10
                Ajustador(plano[5,5,0], plano[5,5,1], 1, 0, unLock);// Plano
                Ajustador(plano[5,5,0], plano[5,5,1], 2, 0, unLock);// Nivel
                Ajustador(plano[9,1,0], plano[9,1,1], 4, 180, unLock);// Curva
                Ajustador(plano[9,2,0], plano[9,2,1], 4, 0, unLock);// Curva
                Ajustador(plano[8,2,0], plano[8,2,1], 3, 90, unLock);// Barra
                Ajustador(plano[7,2,0], plano[7,2,1], 3, 90, unLock);// Barra
                Ajustador(plano[6,2,0], plano[6,2,1], 3, 90, unLock);// Barra
                Ajustador(plano[5,2,0], plano[5,2,1], 4, 180, unLock);// Curva
                Ajustador(plano[5,3,0], plano[5,3,1], 3, 0, unLock);// Barra
                Ajustador(plano[5,4,0], plano[5,4,1], 3, 0, unLock);// Barra
                #endregion
                break;
            #endregion

            #region //-----------------------------------------> MUNDO 2  61-70 <-----------------------------------------//
            case 61:
                #region Nivel 2-1
                Ajustador(plano[1, 2, 0], plano[1, 2, 1], 1, 0, unLock); // panel
                Ajustador(plano[1, 2, 0], plano[1, 2, 1], 2, 0, unLock); // Nivel
                Ajustador(plano[1, 0, 0], plano[1, 0, 1], 3, 0, unLock);// barra
                Ajustador(plano[1, 1, 0], plano[1, 1, 1], 3, 0, unLock);// barra
            #endregion
                break;
            case 62:
                #region Nivel 2-2
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 1, 0, unLock); // panel
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 2, 0, unLock); // Nivel
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 3, 0, unLock);// barra
                Ajustador(plano[1, 4, 0], plano[1, 4, 1], 3, 0, unLock);// barra
                #endregion
                break;
            case 63:
                #region Nivel 2-3
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 1, 0, unLock); // panel
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 2, 0, unLock); // Nivel
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 3, 90, unLock);// barra
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 3, 90, unLock);// barra
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 3, 90, unLock);// barra
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 3, 90, unLock);// barra
                #endregion
                break;
            case 64:
                #region Nivel 2-4
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// barra
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 3, 90, unLock);// barra
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 3, 90, unLock);// barra
                #endregion
                break;
            case 65:
                #region Nivel 2-5
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 2, 0], plano[10, 2, 1], 3, 0, unLock);// barra
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 3, 0, unLock);// barra
                Ajustador(plano[10, 4, 0], plano[10, 4, 1], 3, 0, unLock);// barra
                #endregion
                break;
            case 66:
                #region Nivel 2-6
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 67:
                #region Nivel 2-7
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 68:
                #region Nivel 2-8
                Ajustador(plano[3, 4, 0], plano[3, 4, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 4, 0], plano[3, 4, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 3, 0, unLock);// Barra
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 69:
                #region Nivel 2-9
                Ajustador(plano[8, 4, 0], plano[8, 4, 1], 1, 0, unLock);// Panel
                Ajustador(plano[8, 4, 0], plano[8, 4, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 4, 0], plano[5, 4, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 4, 0], plano[6, 4, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 4, 0], plano[7, 4, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 70:
                #region Nivel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 3, 0], plano[8, 3, 1], 4, 90, unLock);// Curva
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            #endregion

            #region  //-----------------------------------------> MUNDO 3  71-80 <-----------------------------------------//
            case 71:
                #region Nivel 3-1
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[1, 1, 0], plano[1, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[0, 1, 0], plano[0, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 72:
                #region Nivel 3-2
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 3, 0, unLock);// Barra
                Ajustador(plano[2, 2, 0], plano[2, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 73:
                #region Nivel 3-3
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 74:
                #region Nivel 3-4
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 2, 0], plano[5, 2, 1], 3, 0, unLock);// Barra
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 0, unLock);// Barra
                Ajustador(plano[5, 4, 0], plano[5, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 75:
                #region Nivel 3-5
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 76:
                #region Nivel 3-6
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 4, 0], plano[8, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[8, 3, 0], plano[8, 3, 1], 3, 0, unLock);// Barra
                Ajustador(plano[8, 2, 0], plano[8, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 77:
                #region Nivel 3-7
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 4, 0, unLock);// Curva
                Ajustador(plano[10, 4, 0], plano[10, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 78:
                #region Nivel 3-8
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 3, 0], plano[8, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 79:
                #region Nivel 2-9
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 80:
                #region Nivel 3-10
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            #endregion

            #region  //-----------------------------------------> MUNDO 4  81-90 <-----------------------------------------//
            case 81:
                #region Nivel 4-1
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[11, 1, 0], plano[11, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 82:
                #region Nivel 4-2
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 83:
                #region Nivel 4-3
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 84:
                #region Nivel 4-4
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 2, 0], plano[2, 2, 1], 4, 0, unLock);// Curva
                Ajustador(plano[1, 2, 0], plano[1, 2, 1], 4, 180, unLock);// Curva
                #endregion
                break;
            case 85:
                #region Nivel 4-5
                 Ajustador(plano[2, 5, 0], plano[2, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[1, 4, 0], plano[1, 4, 1], 4, 270, unLock);// Curva
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 4, 90, unLock);// Curva
                #endregion
                break;
            case 86:
                #region Nivel 4-6
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 3, 90, unLock);// Barr
                #endregion
                break;
            case 87:
                #region Nivel 4-7
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 88:
                #region Nivel 4-8
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 4, 0], plano[10, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 4, 90, unLock);// Curva
                #endregion
                break;
            case 89:
                #region Nivel 4-9
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 3, 0], plano[8, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 90:
                #region Nivel 4-10
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            #endregion

            #region //-----------------------------------------> MUNDO 5  91-100 <-----------------------------------------//
            case 91:
                #region Nivel 5-1
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[6, 0, 0], plano[6, 0, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 92:
                #region Nivel 5-2
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[6, 4, 0], plano[6, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 3, 0, unLock);// Barra
                Ajustador(plano[6, 2, 0], plano[6, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 93:
                #region Nivel 5-3
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 94:
                #region Nivel 5-4
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 4, 0], plano[10, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 95:
                #region Nivel 5-5
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 2, 0], plano[10, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 96:
                #region Nivel 5-6
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 4, 180, unLock);// Curva
                Ajustador(plano[7, 2, 0], plano[7, 2, 1], 4, 0, unLock);// Curva
                Ajustador(plano[6, 2, 0], plano[6, 2, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 2, 0], plano[5, 2, 1], 4, 270, unLock);// Curva
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 4, 90, unLock);// Curva
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 97:
                #region Nivel 5-7
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 2, 0], plano[2, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 98:
                #region Nivel 5-8
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 3, 0, unLock);// Panel
                #endregion
                break;
            case 99:
                #region Nivel 5-9
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 100:
                #region Nivel 5-10
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 4, 180, unLock);// Curva
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            #endregion

            #region //-----------------------------------------> MUNDO 6  100-110 <-----------------------------------------//
            case 101:
                #region Nivel 6-1
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[11, 5, 0], plano[11, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 102:
                #region Nivel 6-2
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 103:
                #region Nivel 6-3
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 104:
                #region Nivel 6-4
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 105:
                #region Nivel 6-5
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 106:
                #region Nivel 6-6
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 3, 0], plano[8, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 107:
                #region Nivel 6-7
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 2, 0], plano[10, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 108:
                #region Nivel 6-8
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 109:
                #region Nivel 6-9
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 1, 0], plano[2, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 110:
                #region Nivel 6-10
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 2, 0], plano[2, 2, 1], 4, 270, unLock);// Curva
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 2, 0], plano[4, 2, 1], 4, 90, unLock);// Curva
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 3, 0, unLock);// Barra
                
                #endregion
                break;
            #endregion

            #region //-----------------------------------------> MUNDO 7  111-120 <-----------------------------------------//
            case 111:
                #region Nivel 7-1
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[1, 6, 0], plano[1, 6, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 112:
                #region Nivel 7-2
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 4, 0, unLock);// Curva
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 113:
                #region Nivel 7-3
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 4, 0, unLock);// Curva
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 114:
                #region Nivel 7-4
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 115:
                #region Nivel 7-5
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 116:
                #region Nivel 7-6
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 4, 270, unLock);// Curva
                Ajustador(plano[9, 2, 0], plano[9, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 117:
                #region Nivel 7-7
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[11, 3, 0], plano[11, 3, 1], 4, 90, unLock);// Curva
                Ajustador(plano[11, 4, 0], plano[11, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[11, 5, 0], plano[11, 5, 1], 4, 0, unLock);// Curva
                #endregion
                break;
            case 118:
                #region Nivel 7-8
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 119:
                #region Nivel 7-9
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 120:
                #region Nivel 7-10
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 4, 180, unLock);// Curva
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            #endregion

            #region  //-----------------------------------------> MUNDO 8  121-130 <-----------------------------------------//
            case 121:
                #region Nivel 8-1
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[11, 1, 0], plano[11, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 122:
                #region Nivel 8-2
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[9, 3, 0], plano[9, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 4, 180, unLock);// Curva
                Ajustador(plano[9, 2, 0], plano[9, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 123:
                #region Nivel 8-3
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[8, 3, 0], plano[9, 3, 1], 4, 180, unLock);// Curva
                Ajustador(plano[8, 4, 0], plano[9, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 124:
                #region Nivel 8-4
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 125:
                #region Nivel 8-5
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 4, 0], plano[5, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 126:
                #region Nivel 8-6
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 4, 0, unLock);// Curva
                Ajustador(plano[7, 2, 0], plano[7, 2, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 127:
                #region Nivel 8-7
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 128:
                #region Nivel 8-8
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 3, 0], plano[3, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 3, 0, unLock);// Barra
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 4, 180, unLock);// Curva
                #endregion
                break;
            case 129:
                #region Nivel 8-9
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 4, 0], plano[3, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 130:
                #region Nivel 8-10
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            #endregion

            #region //-----------------------------------------> MUNDO 9  131-140 <-----------------------------------------//
            case 131:
                #region Nivel 9-1
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[6, 2, 0], plano[6, 2, 1], 3, 0, unLock);// Barra
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 3, 0, unLock);// Barra
                Ajustador(plano[6, 0, 0], plano[6, 0, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 132:
                #region Nivel 9-2
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 5, 0], plano[6, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[6, 4, 0], plano[6, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 133:
                #region Nivel 9-3
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 5, 0], plano[10, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 5, 0], plano[8, 5, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 134:
                #region Nivel 9-4
                Ajustador(plano[10, 2, 0], plano[10, 2, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 2, 0], plano[10, 2, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 3, 0, unLock);// Barra
                Ajustador(plano[10, 4, 0], plano[10, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 135:
                #region Nivel 9-5
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 1, 0], plano[10, 1, 1], 4, 90, unLock);// Curva
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 136:
                #region Nivel 9-6
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 137:
                #region Nivel 9-7
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[1, 3, 0], plano[1, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 4, 0, unLock);// Curva
                Ajustador(plano[2, 2, 0], plano[2, 2, 1], 3, 90, unLock);// Barra
                Ajustador(plano[1, 2, 0], plano[1, 2, 1], 4, 180, unLock);// Curva
                #endregion
                break;
            case 138:
                #region Nivel 9-8
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 5, 0], plano[2, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[1, 4, 0], plano[1, 4, 1], 3, 0, unLock);// Barra
                Ajustador(plano[1, 5, 0], plano[1, 5, 1], 4, 270, unLock);// Curva
                #endregion
                break;
            case 139: 
                #region Nivel 9-9
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 140:
                #region Nivel 9-10
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            #endregion

            #region //-----------------------------------------> MUNDO 0  141-150 <-----------------------------------------//
            case 141:
                #region Nivel 0-1
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[9, 5, 0], plano[9, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 6, 0], plano[9, 6, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            case 142:
                #region Nivel 0-2
                Ajustador(plano[10, 3, 0], plano[10,3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[10, 3, 0], plano[10, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[9, 4, 0], plano[9, 4, 1], 4, 180, unLock);// Curva
                Ajustador(plano[10, 4, 0], plano[10, 4, 1], 4, 0, unLock);// Curva
                #endregion
                break;
            case 143:
                #region Nivel 0-3
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[9, 1, 0], plano[9, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[10, 2, 0], plano[10, 2, 1], 4, 90, unLock);// Curva
                Ajustador(plano[9, 2, 0], plano[9, 2, 1], 4, 270, unLock);// Curva
                #endregion
                break;
            case 144:
                #region Nivel 0-4
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 1, 0], plano[6, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 1, 0], plano[7, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[8, 1, 0], plano[8, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 145:
                #region Nivel 0-5
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 1, 0], plano[3, 1, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 1, 0], plano[4, 1, 1], 3, 90, unLock);// Barra
                Ajustador(plano[5, 1, 0], plano[5, 1, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 146:
                #region Nivel 0-6
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[2, 3, 0], plano[2, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[3, 2, 0], plano[3, 2, 1], 4, 0, unLock);// Curva
                Ajustador(plano[2, 2, 0], plano[2, 2, 1], 4, 180, unLock);// Curva
                #endregion
                break;
            case 147:
                #region Nivel 0-7
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[3, 5, 0], plano[3, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[2, 4, 0], plano[2, 4, 1], 4, 270, unLock);// Curva
                Ajustador(plano[3, 4, 0], plano[3, 4, 1], 4, 90, unLock);// Curva
                #endregion
                break;
            case 148:
                #region Nivel 0-8
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[5, 5, 0], plano[5, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[4, 5, 0], plano[4, 5, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 149:
                #region Nivel 0-9
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 1, 0, unLock);// Panel
                Ajustador(plano[6, 3, 0], plano[6, 3, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[5, 4, 0], plano[5, 4, 1], 4, 90, unLock);// Curvas
                Ajustador(plano[4, 4, 0], plano[4, 4, 1], 4, 270, unLock);// Curvas
                Ajustador(plano[4, 3, 0], plano[4, 3, 1], 4, 180, unLock);// Curvas
                Ajustador(plano[5, 3, 0], plano[5, 3, 1], 3, 90, unLock);// Barra
                #endregion
                break;
            case 150:
                #region Nivel 0-10
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 1, 0, unLock);// Panel
                Ajustador(plano[7, 5, 0], plano[7, 5, 1], 2, 0, unLock);// Nivel
                Ajustador(plano[7, 3, 0], plano[7, 3, 1], 4, 90, unLock);// Curvas
                Ajustador(plano[7, 4, 0], plano[7, 4, 1], 3, 0, unLock);// Barra
                #endregion
                break;
            #endregion
        }
    }

    void Ajustador(float x, float y, int tipo,int angulo ,int blocked)
    {
        switch (tipo)
        {
            case 1:
                Instantiate(panel_,new Vector2(x,y),transform.rotation);
                break;
            case 2:
                if (blocked == 1)
                    Instantiate(pass_, new Vector2(x, y), transform.rotation);
                else
                    Instantiate(lock_, new Vector2(x, y), transform.rotation);
                break;
            case 3:
                Instantiate(barra_, new Vector2(x, y), barra_.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo)));
                break;
            case 4:
                // Giro 2    180 =   ╔       Giro 1    90  =   ╗
                // Giro 3    270 =   ╚       Giro       0  =   ╝
                float space = 0.25f;
                if (angulo == 0)
                    Instantiate(curva_, new Vector2(x - space, y + space), curva_.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo)));
                else
                    if (angulo == 90)
                        Instantiate(curva_, new Vector2(x - space, y - space), curva_.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo)));
                    else
                        if (angulo == 180)
                            Instantiate(curva_, new Vector2(x + space, y - space), curva_.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo)));
                        else
                            if (angulo == 270)
                                Instantiate(curva_, new Vector2(x + space, y + space), curva_.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo)));
                break;
        }
        // Reinicio de rotaciones
        barra_.transform.rotation = Quaternion.Euler(0, 0, 0);
        curva_.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
