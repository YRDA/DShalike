using UnityEngine;
using System.Collections;

public class ControlMenu : MonoBehaviour
{
    public GameObject[] opciones;
    public int contador;
    bool bandera = true;

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (bandera)
            {
                bandera = false;
                GameObject.Find("Toca la Pantalla").SetActive(false);
            }

            Debug.Log(Input.mousePosition);
            for (int i = 0; i < 6 ; i++)
            {
                if (contador == i)
                {
                    if (contador == 5)
                    {
                        contador = -1;
                    }
                    else
                    {
                        Destroy(GameObject.FindWithTag("Options"));
                        Instantiate(opciones[contador], new Vector2(0, -3.5f), transform.rotation);
                    }
                }
            }
            contador += 1;          
        } 
    }
}
