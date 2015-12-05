using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
  
    public float nextJump = 0f;
    public float jumpRate = 1.0f;
    bool pressButton = false;
    string controlObject;
    bool boolInventary = true;
    float tiempoEspero = 0;
    public bool PAUSA;
    player palaman;

    void Start()
    {
        // referenciamos el scrip player
        palaman = GameObject.Find("Shalike").GetComponent<player>();
    }

    void Update()
    {
            botonesRL();
            MenuPausa();
    }

    private void MenuPausa()
    {
        // Si detectamos un click y fue encima del inventario
        if (pressButton && controlObject == "Inventario") 
        {
            // Damos un tiempo para evitar que el proceso sea tan rapido que se muestre y oculte al mismo tiempo
            if (Time.time > tiempoEspero) 
            {
                tiempoEspero = Time.time + 0.3f;
 
                if (boolInventary) // Si inventario esta oculto
                {
                    PAUSA = true; // Activamos Pausa

                    // Desplasamos el inventario
                    for (int i = 0; i < 80; i++) 
                    {
                        // Movemos el inventario en el eje Y hacia abajo
                        GameObject.Find("Inventario").transform.position = new Vector3(GameObject.Find("Inventario").transform.position.x, GameObject.Find("Inventario").transform.position.y - 0.1f, GameObject.Find("Inventario").transform.position.z);
                    }
                    boolInventary = false; // El inventario se esta mostrando
                }
                else
                {
                    PAUSA = false; // Desactivamos Pausa
                    
                    // Desplasamos el inventario
                    for (int i = 0; i < 80; i++)
                    {
                        // Movemos el inventario en el eje Y hacia arriba
                        GameObject.Find("Inventario").transform.position = new Vector3(GameObject.Find("Inventario").transform.position.x, GameObject.Find("Inventario").transform.position.y + 0.1f, GameObject.Find("Inventario").transform.position.z);
                    }
                    boolInventary = true; // El inventario esta oculto
                }
            }
        }
    }

    private void botonesRL()
    {
        if (pressButton) // si se detecta un click
        {
            if (controlObject == "Right") // si el click fue en la flecha izquierda
                palaman.caminar(1); // Caminamos hacia adelante
            else
                if (controlObject == "Left")// si el click fue en la flecha derecha
                    palaman.caminar(-1); // Caminamos hacia atras
        }
    }

    void OnMouseDrag()
    {
        controlObject = this.name; // nombre del objeto al cual le dimos click encima
        pressButton = true; // Estamos dando click en la pantalla
    }

    void OnMouseUp()
    {
        pressButton = false; // Ya no hay click
    }

}
