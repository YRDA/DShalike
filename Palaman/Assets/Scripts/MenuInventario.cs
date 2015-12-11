using UnityEngine;
using System.Collections;

public class MenuInventario : MonoBehaviour {

    Controles invent;
    bool pressButton;
    int boolMove = 1;
    string controlObject;
    GameObject selectBlok;
    player palaman;

	// Use this for initialization
	void Start () {
        palaman = GameObject.Find("Shalike").GetComponent<player>();
        invent = GameObject.Find("Inventario").GetComponent<Controles>();
        selectBlok = GameObject.Find("SelectBloque");
	}
	
	// Update is called once per frame
	void Update () {
        OpcionesPausa();
    }

    void OpcionesPausa()
    {
        if (invent.PAUSA)
        {
            if (boolMove == 1)
            {
                for (int i = 0; i < 80; i++)
                    // Movemos el inventario en el eje Y hacia abajo
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);

                selectBlok.transform.position = new Vector2(selectBlok.transform.position.x, selectBlok.transform.position.y - 1.14f);
                boolMove = 2;
            }

            if (pressButton)
            {
                if (controlObject == "Options")
                {
                    Debug.Log("Opciones");
                }
                else
                {
                    if (controlObject == "EspaceInventary 1" || controlObject == "EspaceInventary 2" || controlObject == "EspaceInventary 3" || controlObject == "EspaceInventary 4" || controlObject == "EspaceInventary 5" || controlObject == "EspaceInventary 6")
                    {
                        selectBlok.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                        palaman.UseBlock(this.gameObject.name);
                    }
                        
                }
            }
        }
        else
        {
            if (boolMove == 2)
            {
                for (int i = 0; i < 80; i++)
                    // Movemos el inventario en el eje Y hacia abajo
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);

                selectBlok.transform.position = new Vector2(selectBlok.transform.position.x, selectBlok.transform.position.y + 1.14f);
                boolMove = 1;
            }
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
