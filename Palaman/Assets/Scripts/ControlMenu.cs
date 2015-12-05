using UnityEngine;
using System.Collections;

public class ControlMenu : MonoBehaviour
{

    public  Animator continues, newgame, options, exit, Optionsub;

    public void buttonclick(GameObject names)
    {
        // recibo al boton al que le di click y uso su nombre en un switch
        switch (names.name)
        {
            case "ButtonContinue":
                Debug.Log(names.name); // voy al mapa del juego
                break;
            case "ButtonNewGame":
                Application.LoadLevel("Level 01"); // Cargo el nivel 01
                break;
            case "ButtonOptions":
                continues.SetBool("Esconder", true); // escondemos el boton continuar
                newgame.SetBool("Esconder", true);   // escondemos el boton juego nuevo
                options.SetBool("Esconder", true);   // escondemos el boton opciones
                exit.SetBool("Esconder", true);     // escondemos el boton exit
                Optionsub.SetBool("Esconder", true); // mostramos el menu de opciones
                break;
            case "Regresar":
                continues.SetBool("Esconder", false); // mostramos el boton continuar
                newgame.SetBool("Esconder", false);   // mostramos el boton juego nuevo
                options.SetBool("Esconder", false);   // mostramos el boton opciones
                exit.SetBool("Esconder", false);      // mostramos el boton exit
                Optionsub.SetBool("Esconder", false); // ocultamos el menu de opciones
                break;
            case "ButtonExit":
                Application.Quit(); // Cierro la app
                break;
            default:
                break;
        }
    }


        
}
