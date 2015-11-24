using UnityEngine;
using System.Collections;

public class MovieControll : MonoBehaviour {


    public GameObject nubeDiamante, alertaIcono, pico;
    public GameObject mycamera;


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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (nubeDiamante.activeInHierarchy)
                nubeDiamante.SetActive(false);
            else
                nubeDiamante.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mycamera.transform.position = new Vector3(mycamera.transform.position.x, mycamera.transform.position.y + 0.3f, -10);
            
            if (Time.time > nextJump)
            {
                nextJump = Time.time + jumpRate;
                mycamera.transform.position = new Vector3(mycamera.transform.position.x, mycamera.transform.position.y - 0.5f, -10);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (alertaIcono.activeInHierarchy)
                alertaIcono.SetActive(false);
            else
                alertaIcono.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(pico, new Vector2(-1.6f, -4), transform.rotation);
            Instantiate(pico, new Vector2(0, -4), transform.rotation);
            Instantiate(pico, new Vector2(-1.6f, -6), transform.rotation);
            Instantiate(pico, new Vector2(0, -6), transform.rotation);
        }
        

        #region caminar
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            palaman.caminar(-1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Time.time > nextJump)
            {
                nextJump = Time.time + jumpRate;
                palaman.saltar(true);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            palaman.caminar(1);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            palaman.caminar(0);
        }
        #endregion
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
}
