using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {


    float x, y;
    public float speed;

    void Start()
    {
        x = transform.position.x; //obtenemos su posicion en x
        y = transform.position.y; //obtenemos su posicion en y
    }
    void Update()
    {
        transform.position = new Vector3(x + Mathf.Repeat(Time.time * speed, 41), y, 0f);
        // movemos el fondo en el eje X 
        //mathf.repeat (operacion q repetira, duracion )
    }

}
