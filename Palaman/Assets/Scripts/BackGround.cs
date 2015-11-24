using UnityEngine;
using System.Collections;

public class backGround : MonoBehaviour {


    float x, y;
    public float speed;

    void Start()
    {
        x = this.transform.position.x;
        y = this.transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(x + Mathf.Repeat(Time.time * speed, 41), y, 0f);
    }

}
