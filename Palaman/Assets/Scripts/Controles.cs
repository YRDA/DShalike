using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
  
    public float nextJump = 0.2f;
    public float jumpRate = 0.2f;

    bool pressButton = false;
    string controlObject;

    player palaman;
    
    void Start()
    {
        palaman = GameObject.Find("Shalike").GetComponent<player>();
    }
    void Update()
    {
        botonesRL();
    }

    private void botonesRL()
    {
        if (pressButton)
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

    void OnMouseDrag()
    {
        controlObject = this.name;
        pressButton = true;
    }

    void OnMouseUp()
    {
        pressButton = false;
    }
}
