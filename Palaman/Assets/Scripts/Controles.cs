using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
  
    public float nextJump = 0.2f;
    public float jumpRate = 0.2f;
    bool pressButton = false;
    string controlObject;
    bool inventarioBandera = true;
    bool pressButtonInventario;
    float tiempoEspero = 0;
    public bool PAUSA;
    player palaman;

    void Start()
    {
        palaman = GameObject.Find("Shalike").GetComponent<player>();
    }
    void Update()
    {
            botonesRL();
            MenuPausa();
    }

    private void MenuPausa()
    {
        if (pressButton && controlObject == "Inventario")
        {
            if (Time.time > tiempoEspero)
            {
                PAUSA = true;
                tiempoEspero = Time.time + 0.3f;
                if (inventarioBandera)
                {
                    PAUSA = true;
                    for (int i = 0; i < 80; i++)
                    {
                        GameObject.Find("Inventario").transform.position = new Vector3(GameObject.Find("Inventario").transform.position.x, GameObject.Find("Inventario").transform.position.y - 0.1f, GameObject.Find("Inventario").transform.position.z);
                    }
                    inventarioBandera = false;
                }
                else
                {
                    PAUSA = false;
                    for (int i = 0; i < 80; i++)
                    {
                        GameObject.Find("Inventario").transform.position = new Vector3(GameObject.Find("Inventario").transform.position.x, GameObject.Find("Inventario").transform.position.y + 0.1f, GameObject.Find("Inventario").transform.position.z);
                    }
                    inventarioBandera = true;
                }
            }
        }
    }

    private void botonesRL()
    {
        if (pressButton )
        {
            if (controlObject == "Right")
            {
                if (palaman.fronteo && Time.time > nextJump && palaman.rigth)
                {
                    nextJump = Time.time + jumpRate;
                    palaman.saltar(true);
                }
                else
                    palaman.caminar(1);
            }
            else
                if (controlObject == "Left")
                {
                    if (palaman.fronteo && Time.time > nextJump && !palaman.rigth)
                    {
                        nextJump = Time.time + jumpRate;
                        palaman.saltar(true);
                    }
                    else
                        palaman.caminar(-1);
                }                   
        }
    }

    void OnMouseDow()
    {
        controlObject = this.name;
        pressButtonInventario = true;
    }
    void OnMouseDrag()
    {
        controlObject = this.name;
        pressButton = true;
    }

    void OnMouseUp()
    {
        pressButton = false;
        pressButtonInventario = true;
    }

}
