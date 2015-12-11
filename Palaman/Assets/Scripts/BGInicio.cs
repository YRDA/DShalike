using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class BGInicio : MonoBehaviour {

    float x,y;
    public float speed;

    bool boolStartMenu = true;
    public GameObject btnContinue, btnNewGame, btnOptions, btnExit;
    Text lifes, world, gemas;

    void Start()
    {
        x = transform.position.x; //obtenemos su posicion en x
        y = transform.position.y; //obtenemos su posicion en Y
    }

    void Update()
    {
        transform.position = new Vector3( x + Mathf.Repeat(Time.time * speed, 41), y, 0f);
        // movemos el fondo en el eje X 
        //mathf.repeat (operacion q repetira, duracion )
    }

    void OnMouseDown()
    {
        // al detectar un click en encima...
        if (boolStartMenu)
        {
            Destroy(GameObject.Find("Icono_")); // destruimos el icono principal
            Destroy(GameObject.Find("Toca la Pantalla")); // el texto de Toca la pantalla

            // Verificamos si existen partidas guardadas y cargamos los valores al boton Continuar...
            ChargeValuesContinue(); 

            btnNewGame.SetActive(true);  // activamos boton Juego nuevo
            btnOptions.SetActive(true); // activamos boton Opciones
            btnExit.SetActive(true);    // activamos boton Exit

            boolStartMenu = false; // evitamos que se vuelva a entrar en esta opcion
        }
    }

    void ChargeValuesContinue()
    {
        string linea;
        // Iniciamos un StreamReader para el archivo dates
        var txtLevel = new StreamReader(Application.dataPath + "\\Levels/txt/Dates.txt");

        linea = txtLevel.ReadLine(); // leer linea

        if (linea != null) // si la linea leia no esta vacia
        {
            btnContinue.SetActive(true); // activamos boton Continuar

            // separamos los datos por el simbolo | y los guardamos en el arreglo datesValues
            string[] datesValues = linea.Split("|"[0]); 

            // Obtenemos la propiedad de texto del boton continuar [Vidas,Nivel,Gemas]
            lifes = GameObject.Find("TxtLifes").GetComponent<Text>();
            world = GameObject.Find("Mundo").GetComponent<Text>();
            gemas = GameObject.Find("Gemas").GetComponent<Text>();

            // modificamos el texto del boton continuar [Vidas,Nivel,Gemas]
            lifes.text = "X " + datesValues[0];
            world.text = "Mundo\n" + datesValues[1] + " - " + datesValues[2];
            gemas.text = "Gemas\n" + datesValues[3];

            /*        ------  Formato ------
             *    ________________________________
             *   |                                | 
             *   |  [Imagen] X [0]     Gemas [3]  |
             *   |                                |
             *   |      Mundo   [1] - [2]         |
             *   |________________________________|
             *    
            */
            txtLevel.Close();
        }
    }
}
