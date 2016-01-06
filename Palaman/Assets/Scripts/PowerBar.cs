using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour {

    public bool booltime = true, boolPanel = true, PAUSA;
    float contador = 0;
    public GameObject panelPoder;
    Controles controlX;
    Animator anima;
    float timecharge = 0;
    int countPowr = 100,contatime;
    player shalike;
    Animator aniG;
    public bool boolSpecial;
    public GameObject[] GOPowers = new GameObject[8];

    void Start()
    {
        shalike = GameObject.Find("Shalike").GetComponent<player>();
        aniG = GameObject.Find("GemaBarra").GetComponent<Animator>();
        controlX = GameObject.Find("Inventario").GetComponent<Controles>();
        anima = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time > timecharge)
        {
            timecharge = Time.time + 10;
            anima.SetInteger("Charge", countPowr);

            if (countPowr < 100)
                countPowr += 10;
        }

        Special();
    }

    void OnMouseDrag()
    {
        if (booltime)
        {
            contador = Time.time + 2;
            booltime = false;
        }
        
        if (Time.time > contador && boolPanel && !controlX.PAUSA)
        {
            boolPanel = false;
            Instantiate(panelPoder, new Vector3(this.transform.position.x-6.85f,this.transform.position.y -3.66f, 0), transform.rotation);
            PAUSA = true;
        }
    }

    void OnMouseUp()
    {
        if (!GameObject.Find("PanelSpecial(Clone)") && countPowr == 100 && aniG.GetInteger("Gemax") > 0)
        {
            countPowr = 0;
            anima.SetInteger("Charge", countPowr);
            int gema  = aniG.GetInteger("Gemax");
            shalike.StartSpecial(gema);
        }
    }

    void Special()
    {

        if (boolSpecial)
        {
            switch (aniG.GetInteger("Gemax"))
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    // Hielo
                    float XRan = 9 , YRan = 2.0f;
                    for (int i = 0; i < 3; i++)
                    {
                        float randomX = Random.Range(-XRan, XRan);
                        float randomY = Random.Range(-YRan, YRan);
                        Instantiate(GOPowers[aniG.GetInteger("Gemax") - 1], new Vector3(GameObject.Find("Sky").transform.position.x + randomX, GameObject.Find("Sky").transform.position.y + randomY, 0), transform.rotation);
                    }
                    break;
                case 8:
                    break;
                default:
                    break;
            }
        }
    }
}
