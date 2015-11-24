using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BGInicio : MonoBehaviour {

    float x,y;
    public float speed;

    bool startMenu = true;
    public GameObject Menu,controlMenu;
    Text lifes, world, gemas;

    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3( x + Mathf.Repeat(Time.time * speed, 41), y, 0f);
    }

    void OnMouseDown()
    {
        if (startMenu)
        {
            Destroy(GameObject.Find("Icono_"));
            Destroy(GameObject.Find("Toca la Pantalla"));

            Menu.SetActive(true);

            lifes = GameObject.Find("TxtLifes").GetComponent<Text>();
            world = GameObject.Find("Mundo").GetComponent<Text>();
            gemas = GameObject.Find("Gemas").GetComponent<Text>();

            lifes.text = "X 1";
            world.text = "Mundo\n 1 - 1";
            gemas.text = "Gemas\n1";

            startMenu = false;
        }
    }
}
