using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {

    float derx1 = 769;
    float derx2 = 793;
    float dery1 = 120;
    float dery2 = 180;
    float izqx1 = 16;
    float izqx2 = 34;
    float izqy1 = 117;
    float izqy2 = 183;
    public float nextJump;
    public float jumpRate;

    player palaman;
    
    void Start()
    {
        palaman = GameObject.Find("Shalike").GetComponent<player>();
    }
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        botonesRL();
    }

    private void botonesRL()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > derx1 && Input.mousePosition.x < derx2 && Input.mousePosition.y > dery1 && Input.mousePosition.y < dery2)
            {
                //player palaman = GameObject.Find("Shalike").GetComponent<player>();
                if (palaman.fronteo && Time.time > nextJump && palaman.rigth)
                {
                    nextJump = Time.time + jumpRate;
                    palaman.saltar(true);
                }
                else
                palaman.caminar(1);
            }
            else
            {
                if (Input.mousePosition.x > izqx1 && Input.mousePosition.x < izqx2 && Input.mousePosition.y > izqy1 && Input.mousePosition.y < izqy2)
                {
                    //player palaman = GameObject.Find("Shalike").GetComponent<player>();
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
    }
}
