using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class player : MonoBehaviour {


    public class Space
    {
        public bool disponible {get;set;}
        public int tipo {get;set;}
        public int pzas {get; set;}
        public string name {get; set;}
    }

    int countVidas = 3;
    private Rigidbody2D myRB2D;
    public GameObject mycamera, peakObj, btnblok, btnJumping, corazon_1, corazon_2, corazon_3;
    private Animator anima;

    public float speed;
    public bool rigth = false,run = false;

    private Vector3 offset;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool grounded = false;

    public Transform blockFrontCheck;
    public bool jumping = false, fronteo = false, boolForceDown = true , boolJump = true;
    public float jumpForce;

    Controles ControlesPlayer;
    MapGenerator controleX;

    public GameObject[] icono = new GameObject[20];
    List<Space> cubo = new List<Space>();

    int BlocInkUse = 0;
    Animator animaIco;

	void Start () {
        ChargeBlocks();
        animaIco = GameObject.Find("Block").GetComponent<Animator>();
        ControlesPlayer = GameObject.Find("Inventario").GetComponent<Controles>();
        controleX = GameObject.Find("Generador").GetComponent<MapGenerator>();
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
        anima = gameObject.GetComponent<Animator>();
        offset = mycamera.transform.position;
	}
	
	void Update () {

        mycamera.transform.position = new Vector3(this.transform.position.x + offset.x,this.transform.position.y + offset.y + 2,this.transform.position.z + offset.z);
        
        UpdateIconos();

        if (fronteo || anima.GetBool("Jump") || !grounded) speed = 0;
        else speed = 0.08f;

        if (fronteo)
            activeJump();
        else
            disableJump();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, whatIsGround);
        fronteo = Physics2D.OverlapCircle(blockFrontCheck.position, 0.2f, whatIsGround);

        if (grounded)
        {
            jumping = false;
            boolForceDown = true;
        }    
        else
        {
            if (boolForceDown)
            {
                if (rigth)
                    myRB2D.AddForce(new Vector2(40, 0));
                else
                    myRB2D.AddForce(new Vector2(-40, 0));
                boolForceDown = false;
            }
            jumping = true;
        }

        anima.SetBool("hSpeed", run);
        anima.SetBool("Ground", grounded);
        anima.SetBool("Jump",jumping);
        
    }

    private void activeJump()
    {
        if (boolJump)
        {
            Controles ControlOBlock = btnblok.GetComponent<Controles>();
            Controles ControlOJump = btnJumping.GetComponent<Controles>();
            ControlOBlock.controlObject = "";
            ControlOJump.controlObject = "";
            btnblok.SetActive(false);
            btnJumping.SetActive(true);
            boolJump = false;
        }
    }

    public void disableJump()
    {
        if (!boolJump)
        {
            btnblok.SetActive(true);
            btnJumping.SetActive(false);
            boolJump = true;
        }
    }

    public void caminar(int caminando)
    {
        if (caminando == -1 && !jumping && grounded && !ControlesPlayer.PAUSA)
        {
            run = true;
            rigth = false;

            transform.Translate(caminando * speed, 0f, 0f);

            Vector3 newScale = transform.localScale;
            newScale.x = -0.8f; 
            transform.localScale = newScale;
        }
        else
        {
            if (caminando == 1 && !jumping && grounded && !ControlesPlayer.PAUSA)
            {
                run = true;
                rigth = true;

                transform.Translate(caminando * speed, 0f, 0f);

                Vector3 newScale = transform.localScale;
                newScale.x = 0.8f;
                transform.localScale = newScale;
            }
            else 
                if (caminando == 0)
                    run = false; 
    }
}

    public void saltar()
    {
        if (grounded && fronteo && rigth && !ControlesPlayer.PAUSA)
        {
            myRB2D.AddForce(new Vector2(20, jumpForce));
            fronteo = false;
            anima.SetBool("Ground", false);
            anima.SetBool("Jump", true);
        }
        else
        {
            if (grounded && fronteo && !rigth && !ControlesPlayer.PAUSA)
            {
                myRB2D.AddForce(new Vector2(-20, jumpForce));

                fronteo = false;
                anima.SetBool("Ground", false);
                anima.SetBool("Jump", true);
            }
        }
    }

    public void cavar()
    {
        if (grounded && !jumping && !run && !ControlesPlayer.PAUSA)
        {
                if (rigth)
                    Instantiate(peakObj, new Vector3(this.transform.position.x + 1.5f, this.transform.position.y, -1f), transform.rotation);
                else
                    Instantiate(peakObj, new Vector3(this.transform.position.x - 1.5f, this.transform.position.y, -1f), transform.rotation);

                anima.SetBool("Dig", true);
        }
    }

    void finCavar() {

        anima.SetBool("Dig", false);

    }

    public void ColocarBloque()
    {
        if (grounded && !jumping && !run && !ControlesPlayer.PAUSA)
        {
            if (cubo[BlocInkUse].pzas > 0)
            {
                cubo[BlocInkUse].pzas--;
                controleX.UbicacionPersonaje(transform.position.x, transform.position.y, rigth,cubo[BlocInkUse].tipo);
            }
        }
    }

    void ChargeBlocks()
    {
        string linea;
        // Iniciamos un StreamReader para el archivo dates
        var txtLevel = new StreamReader(Application.dataPath + "\\Levels/txt/Dates.txt");

        linea = txtLevel.ReadLine(); // leer linea

        if (linea != null) // si la linea leia no esta vacia
        {

            // separamos los datos por el simbolo | y los guardamos en el arreglo datesValues
            string[] datesValues = linea.Split("|"[0]);
            for (int i = 0; i < 6; i++)
            {
                int typeBlock, pzasBlock;
                int.TryParse(datesValues[i + 32], out typeBlock);
                int.TryParse(datesValues[i + 38], out pzasBlock);

                if (typeBlock > 0)
                {
                    Instantiate(icono[typeBlock], new Vector3(GameObject.Find("EspaceInventary " + (i + 1)).transform.position.x, GameObject.Find("EspaceInventary " + (i + 1)).transform.position.y, -1), transform.rotation);
                    cubo.Add(new Space() { disponible = false, tipo = typeBlock, pzas = pzasBlock, name = icono[typeBlock].name + "(Clone)" });
                }
                else
                {
                    cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
                }

            }
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.TrimExcess();            
            txtLevel.Close();

            #region Lista Iconos
            /*
         * [00] = Super Bloque           [10] = 
         * [01] = Tierra                 [11] = 
         * [02] = Tierra Cueva           [12] = 
         * [03] = Roca                   [13] = 
         * [04] = Madera                 [14] = 
         * [05] =                        [15] = 
         * [06] =                        [16] = 
         * [07] =                        [17] = 
         * [08] =                        [18] = 
         * [09] =                        [19] = 
        */
            #endregion

        }
        else
        {
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
            cubo.Add(new Space() { disponible = true, tipo = 0, pzas = 0, name = "" });
        }
    }

    public void UseBlock(string espacio)
    {
        switch (espacio)
        {
            case "EspaceInventary 1":
                BlocInkUse = 0;
                break;
            case "EspaceInventary 2":
                BlocInkUse = 1;
                break;
            case "EspaceInventary 3":
                BlocInkUse = 2;
                break;
            case "EspaceInventary 4":
                BlocInkUse = 3;
                break;
            case "EspaceInventary 5":
                BlocInkUse = 4;
                break;
            case "EspaceInventary 6":
                BlocInkUse = 5;
                break;

            default:
                break;
        }
    }

    void UpdateIconos()
    {
            #region Contadores
            Animator conta1, conta2, conta3, conta4, conta5, conta6, conta7;

            conta1 = GameObject.Find("Contador 1").GetComponent<Animator>();
            conta2 = GameObject.Find("Contador 2").GetComponent<Animator>();
            conta3 = GameObject.Find("Contador 3").GetComponent<Animator>();
            conta4 = GameObject.Find("Contador 4").GetComponent<Animator>();
            conta5 = GameObject.Find("Contador 5").GetComponent<Animator>();
            conta6 = GameObject.Find("Contador 6").GetComponent<Animator>();
            conta7 = GameObject.Find("Contador 7").GetComponent<Animator>();

            conta1.SetInteger("Contador", cubo[0].pzas);
            conta2.SetInteger("Contador", cubo[1].pzas);
            conta3.SetInteger("Contador", cubo[2].pzas);
            conta4.SetInteger("Contador", cubo[3].pzas);
            conta5.SetInteger("Contador", cubo[4].pzas);
            conta6.SetInteger("Contador", cubo[5].pzas);
            conta7.SetInteger("Contador", cubo[BlocInkUse].pzas);

            if (cubo[BlocInkUse].tipo > 0)
                animaIco.SetInteger("TypeIn", cubo[BlocInkUse].tipo);
            else
                animaIco.SetInteger("TypeIn", 0);

            #endregion

            #region Actualizar Lugares

            for (int i = 0; i < 6; i++)
            {
                if (cubo[i].pzas == 0)
                {
                    if (cubo[i + 1].pzas > 0)
                    {
                        cubo[i].disponible = cubo[i + 1].disponible;
                        cubo[i].name = cubo[i + 1].name;
                        cubo[i].pzas = cubo[i + 1].pzas;
                        cubo[i].tipo = cubo[i + 1].tipo;

                        cubo[i + 1].disponible = true;
                        cubo[i + 1].name = "";
                        cubo[i + 1].pzas = 0;
                        cubo[i + 1].tipo = 0;
                    }
                    else
                    {
                        if (!cubo[i].disponible)
                        {
                            Destroy(GameObject.Find(cubo[i].name));
                            cubo[i].disponible = true;
                            cubo[i].name = "";
                            cubo[i].pzas = 0;
                            cubo[i].tipo = 0;
                        }
                    }
                }

                if (!cubo[i].disponible)
                    GameObject.Find(cubo[i].name).transform.position = new Vector3(GameObject.Find("EspaceInventary " + (i + 1)).transform.position.x, GameObject.Find("EspaceInventary " + (i + 1)).transform.position.y, -1);
            }
            #endregion
    }

    public void AddBlocks(string nameBlock)
    {
        string familia = "";
        int familiaTipo = 0;
        bool newIcono = false;

        Debug.Log(nameBlock);
        switch (nameBlock)
        {
            case "Tierra_sup(Clone)":
                familia = "Icono_Tierra";
                familiaTipo = 1;
                break;
            case "Tierra_inf(Clone)":
                familia = "Icono_Tierra";
                familiaTipo = 1;
                break;
            case "Tierra_cave_inf(Clone)":
                familia = "Icono_TierraC";
                familiaTipo = 2;
                break;
            case "Roca_inf(Clone)":
                familia = "Icono_Roca";
                familiaTipo = 3;
                break;
            case "Roca_sup(Clone)":
                familia = "Icono_Roca";
                familiaTipo = 3;
                break;
            case "Madera(Clone)":
                familia = "Icono_Madera";
                familiaTipo = 4;
                break;
            default: familiaTipo = 1;
                break;
        }

        for (int i = 0; i < 6; i++)
        {
            if (!cubo[i].disponible)
            {
                if (cubo[i].name == (familia + "(Clone)"))
                {
                    if (cubo[i].pzas < 20)
                    {
                        cubo[i].pzas += 1;
                    }
                    newIcono = true;
                    break;
     
                }
            }
        }

        if (!newIcono)
        {
            for (int i = 0; i < 6; i++)
            {
                if (cubo[i].disponible)
                {
                    cubo[i].disponible = false;
                    cubo[i].name = familia + "(Clone)";
                    cubo[i].tipo = familiaTipo;
                    cubo[i].pzas = 1;
                    Instantiate(icono[cubo[i].tipo], new Vector3(GameObject.Find("EspaceInventary " + (i + 1)).transform.position.x, GameObject.Find("EspaceInventary " + (i + 1)).transform.position.y, -1), transform.rotation);
                    break;
                }

            }
        }
    }

    public void Vidas(int vidas)
    {
        if (vidas == 1)
        {
            switch (countVidas)
            {
                case 1: 
                    countVidas += 1;
                    corazon_2.SetActive(true);
                    break;
                case 2:
                    countVidas += 1;
                    corazon_3.SetActive(true);
                    break;
            }
        }
        else
        {
            if (vidas == -1)
            {
                switch (countVidas)
                {
                    case 1: 
                        countVidas -= 1;
                        corazon_1.SetActive(false);
                        gameOver();
                        break;
                    case 2:
                        countVidas -= 1;
                        corazon_2.SetActive(false);
                        break;
                    case 3:
                        countVidas -= 1;
                        corazon_3.SetActive(false);
                        break;
                }
            }
        }
    }

    private void gameOver()
    {
        Debug.Log("El juego termino");
    }

}

