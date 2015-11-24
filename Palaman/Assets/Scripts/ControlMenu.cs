using UnityEngine;
using System.Collections;

public class ControlMenu : MonoBehaviour
{

    public  Animator continues, newgame, options, exit, Optionsub;

    public void buttonclick(GameObject names)
    {

        switch (names.name)
        {
            case "Continuar":
                Debug.Log(names.name);
                break;
            case "Juego Nuevo":
                Application.LoadLevel("Movies");
                break;
            case "Opciones":
                continues.SetBool("Esconder", true);
                newgame.SetBool("Esconder", true);
                options.SetBool("Esconder", true);
                exit.SetBool("Esconder", true);
                Optionsub.SetBool("Esconder", true);
                break;
            case "Regresar":
                continues.SetBool("Esconder", false);
                newgame.SetBool("Esconder", false);
                options.SetBool("Esconder", false);
                exit.SetBool("Esconder", false);
                Optionsub.SetBool("Esconder", false);
                break;
            case "Salir":
                Application.Quit();
                break;
            default:
                break;
        }
    }


        
}
