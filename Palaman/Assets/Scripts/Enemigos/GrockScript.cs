using UnityEngine;
using System.Collections;

public class GrockScript : MonoBehaviour {

    string estado = "caminando";
    bool rigth = true,caminando,atacando;
    public float energy = 10;
    float speed = 0.02f;
    float timeover;
    bool boolN;
    int golpe;
    public bool stepPlayer;
    public GameObject guanteCh,guanteXL;
    public Transform check;
    public LayerMask myLM;
    Animator anima;
    Rigidbody2D myrb;

    void Start()
    {
        anima = this.GetComponent<Animator>();
        myrb = this.GetComponent<Rigidbody2D>();
    }

	void Update () {

        if (stepPlayer)
        {
            estado = "atacando";
        }

        if (rigth)
        {
            Vector3 newScale = transform.localScale;
            newScale.x = 0.8f;
            transform.localScale = newScale;
        }
        else
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -0.8f;
            transform.localScale = newScale;
        }
        switch (estado)
        {
            case "normal":
                anima.SetBool("Run", false);
                speed = 0;
                if (Time.time > timeover)
                {
                    timeover = Time.time + 0.5f;
                    if (boolN)
                    {
                        guanteCh.transform.position = new Vector3(guanteCh.transform.position.x, guanteCh.transform.position.y + 0.03f, 0);
                        guanteXL.transform.position = new Vector3(guanteXL.transform.position.x, guanteXL.transform.position.y + 0.03f, 0);
                        boolN = false;
                    }
                    else
                    {
                        guanteCh.transform.position = new Vector3(guanteCh.transform.position.x, guanteCh.transform.position.y - 0.03f, 0);
                        guanteXL.transform.position = new Vector3(guanteXL.transform.position.x, guanteXL.transform.position.y - 0.03f, 0);
                        boolN = true;
                    }

                    if (energy == 10)
                        estado = "caminando";
                    else
                        energy += 1;
                }
                
                break;
            case "caminando":
                speed = 0.02f;
                anima.SetBool("Run", true);

                if (Physics2D.OverlapCircle(check.position, 0.05f, myLM))
                {
                    if (rigth)
                        rigth = false;
                    else
                        rigth = true;
                }
                else
                {
                    if (energy > 0){

                        if (rigth)
                            this.transform.position = new Vector2((this.transform.position.x + (0.5f * speed)), this.transform.position.y);
                        else
                            this.transform.position = new Vector2((this.transform.position.x - (0.5f * speed)), this.transform.position.y);
                        if (Time.time > timeover)
                        {
                            timeover = Time.time + 0.5f;
                            energy -= 0.5f;
                        }
                    }
                    else
                        estado = "normal";
                }

                break;
            case "atacando":
                anima.SetBool("Run", false);
                speed = 0;
                if (Time.time > timeover){
                    timeover = Time.time + 0.2f;
                    if (golpe == 0)
                    {
                        if (rigth)
                            guanteXL.transform.position = new Vector3(guanteXL.transform.position.x + 0.5f, guanteXL.transform.position.y, 0);
                        else
                            guanteXL.transform.position = new Vector3(guanteXL.transform.position.x - 0.5f, guanteXL.transform.position.y, 0);
                        golpe += 1;
                    }
                    else
                    {
                        if (golpe == 1)
                        {
                            if (rigth)
                            guanteXL.transform.position = new Vector3(guanteXL.transform.position.x - 0.5f, guanteXL.transform.position.y, 0);
                        else
                            guanteXL.transform.position = new Vector3(guanteXL.transform.position.x + 0.5f, guanteXL.transform.position.y, 0);
                        }
                        stepPlayer = false;
                        if (rigth)
                            rigth = false;
                        else
                            rigth = true;
                        estado = "caminando";
                        golpe = 0;
                    }
                }

                break;
        }

	}
}
