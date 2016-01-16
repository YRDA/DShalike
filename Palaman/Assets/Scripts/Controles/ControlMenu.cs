using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{

    public  Animator continues, newgame, options, exit, Optionsub;

    public void buttonclick(GameObject names)
    {
        // recibo al boton al que le di click y uso su nombre en un switch
        switch (names.name)
        {
            case "ButtonContinue":
                Application.LoadLevel("MapaGlobal");
                break;
            case "ButtonNewGame":
                
                string direccion = pathForDocumentsFile("Dates.txt");

                if (File.Exists(direccion))
                    File.Delete(direccion);

                var txtwrite = new StreamWriter(direccion);
                txtwrite.Write("5|0|0|0|12-11-91|");
                for (int i = 5; i < 160; i++)
                    txtwrite.Write("0|");
                txtwrite.Close();
                Application.LoadLevel("Levels"); // Cargo el nivel 01
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
