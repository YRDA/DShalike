using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ControlPreInventario : MonoBehaviour {

    public class Bloque
    {
        public bool disponible { get; set; }
        public int id { get; set; }
        public int tipo { get; set; }
        public int pzas { get; set; }
        
    }

    public List<Bloque> block = new List<Bloque>();
    public List<Bloque> preInven = new List<Bloque>();
    Animator animaBlock, animaCount;
    ControlPreInventario Inventario;
    public GameObject R , L;
    public int pagina = 1;

    void Start()
    {
        if (this.name != "btnJugar" && this.name != "Right" && this.name != "Left" && this.name != "Inventario" && this.name != "btnSalto")
        {
                Inventario = GameObject.Find("Inventario").GetComponent<ControlPreInventario>();
                string[] numeroSelect = this.name.Split("_"[0]);
                animaBlock = GameObject.Find("Bloques_" + numeroSelect[1]).GetComponent<Animator>();
                animaCount = GameObject.Find("Contador_" + numeroSelect[1]).GetComponent<Animator>();
        }

        if (this.name == "Right" || this.name == "Left")
            Inventario = GameObject.Find("Inventario").GetComponent<ControlPreInventario>();

        if (this.name == "btnJugar")
            Inventario = GameObject.Find("Inventario").GetComponent<ControlPreInventario>();

        if (this.name == "Inventario")
            CargaInventario();
    }

    void Update()
    {
        #region Botones
        if (this.name == "Inventario")
        {
            int bloqesLLenos = 0;
            foreach (var item in block)
            {
                if (!item.disponible)
                    bloqesLLenos += 1;
            }
            
            if (pagina == 1)
            {
                R.SetActive(false);
                if (bloqesLLenos <= 8)
                    L.SetActive(false);
                else
                    L.SetActive(true);
            }
            else
            {
                R.SetActive(true);
                L.SetActive(false);
            }
        }
        #endregion

        if (this.name != "btnJugar" && this.name != "Right" && this.name != "Left" && this.name != "Inventario" && this.name != "btnSalto")
        {
            switch (Inventario.pagina)
            {
                case 1:
                    for (int i = 1; i < 9; i++)
                    {
                        int contador = 0;
                        if (this.name == "SelectBloque_" + i)
                            for (int j = 0; j < Inventario.block.Count; j++)
                            {
                                if (!Inventario.block[j].disponible)
                                {
                                    contador += 1;
                                    if (contador == i)
                                    {
                                        ActualizaAnimas(1, j);
                                        break;
                                    }
                                }
                                else
                                    ActualizaAnimas(1, 16);
                            }
                        else
                            if (this.name == "PortaBloque_" + (i + 10))
                                ActualizaAnimas(2, i - 1);
                    }
                    break;
                case 2:
                    for (int i = 1; i < 9; i++)
                    {
                        int contador = 0;
                        if (this.name == "SelectBloque_" + i)
                            for (int j = 0; j < Inventario.block.Count; j++)
                            {
                                if (!Inventario.block[j].disponible)
                                {
                                    contador += 1;
                                    if (contador == (i + 8))
                                    {
                                        ActualizaAnimas(1, j);
                                        break;
                                    }
                                }
                                else
                                    ActualizaAnimas(1, 16);
                            }
                        else
                            if (this.name == "PortaBloque_" + (i + 10))
                                ActualizaAnimas(2, i - 1);
                    }
                    break;
            }
        }
    }

    void ActualizaAnimas(int tipo, int bloqe)
    {
        if (tipo == 1)
        {
            animaBlock.SetInteger("TypeIn", Inventario.block[bloqe].tipo);
            animaCount.SetInteger("Contador", Inventario.block[bloqe].pzas);
        }
        else
        {
            animaBlock.SetInteger("TypeIn", Inventario.preInven[bloqe].tipo);
            animaCount.SetInteger("Contador", Inventario.preInven[bloqe].pzas);
        }
    }

    void OnMouseDown()
    {
        #region botones
        if (this.name == "btnSalto")
        {
            Application.LoadLevel("Mini Mapa");
        }
        if (this.name == "btnJugar")
        {
            try
            {
                ActualizarDatos();
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
            Application.LoadLevel("Levels");
        }

        if (this.name == "Right")
        {
            if (Inventario.pagina != 2)
                Inventario.pagina += 1;
        }

        if (this.name == "Left")
        {
            if (Inventario.pagina != 1)
                Inventario.pagina -= 1;
        }
        #endregion

        #region Inventario
        for (int i = 1; i < 9; i++)
        {
            int j = 0, k = 0;
            if (this.name == ("SelectBloque_" + i))
                for (j = 0; j < Inventario.block.Count; j++)
                {
                    if (Inventario.block[j].tipo == animaBlock.GetInteger("TypeIn") && Inventario.block[j].pzas != 0)
                        for (k = 0; k < 4; k++)
                        {
                            // incremento
                            if (Inventario.preInven[k].tipo == animaBlock.GetInteger("TypeIn"))
                                if (Inventario.block[j].pzas == 1)
                                {
                                    Inventario.block[j].disponible = true;
                                    Inventario.block[j].pzas = 0;
                                    Inventario.block[j].tipo = 0;
                                    Inventario.preInven[k].pzas += 1;
                                    break;
                                }
                                else
                                {
                                    Inventario.block[j].pzas -= 1;
                                    Inventario.preInven[k].pzas += 1;
                                    break;
                                }
                            else
                                // Agrego un bloque nuevo
                                if (Inventario.preInven[k].disponible)
                                    if (Inventario.block[j].pzas == 1)
                                    {
                                        Inventario.preInven[k].disponible = false;
                                        Inventario.preInven[k].id = Inventario.block[j].id;
                                        Inventario.preInven[k].tipo = Inventario.block[j].tipo;
                                        Inventario.preInven[k].pzas += 1;

                                        Inventario.block[j].disponible = true;
                                        Inventario.block[j].pzas = 0;
                                        Inventario.block[j].tipo = 0;
                                        break;
                                    }
                                    else
                                    {
                                        Inventario.block[j].pzas -= 1;

                                        Inventario.preInven[k].disponible = false;
                                        Inventario.preInven[k].id = Inventario.block[j].id;
                                        Inventario.preInven[k].tipo = Inventario.block[j].tipo;
                                        Inventario.preInven[k].pzas += 1;
                                        break;
                                    }
                        }
                }
        }
        #endregion

        #region PreInventario
        for (int i = 0; i < 4; i++)
        {
            int j = 0;
            if (this.name == ("PortaBloque_" + (i + 11)))
                if (!Inventario.preInven[i].disponible)
                    for (j = 0; j < Inventario.block.Count; j++)
                    {
                        if (Inventario.preInven[i].id == Inventario.block[j].id)
                            if (Inventario.preInven[i].pzas == 1)
                            {
                                Inventario.block[j].disponible = false;
                                Inventario.block[j].tipo = Inventario.preInven[i].tipo;
                                Inventario.block[j].pzas += 1;

                                Inventario.preInven[i].disponible = true;
                                Inventario.preInven[i].tipo = 0;
                                Inventario.preInven[i].pzas = 0;
                                break;
                            }
                            else
                            {
                                Inventario.preInven[i].pzas -= 1;

                                Inventario.block[j].disponible = false;
                                Inventario.block[j].tipo = Inventario.preInven[i].tipo;
                                Inventario.block[j].pzas += 1;
                                break;
                            }
                    }
        }
        #endregion
    }

    void CargaInventario()
    {
        Globales script = GameObject.Find("GlobalesGO").GetComponent<Globales>();
        string direccion = script.pathForDocumentsFile("Dates.txt");
        var txtRead = new StreamReader(direccion);
        string[] datos = txtRead.ReadLine().Split("|"[0]);
        for (int i = 0; i < 17; i++)
        {
            int cantidad;
            int.TryParse(datos[i + 13], out cantidad);

            if (cantidad > 0)
                block.Add(new Bloque() { disponible = false, id = i + 13, tipo = i + 1, pzas = cantidad });
            else
                block.Add(new Bloque() { disponible = true, id = 0, tipo = 0, pzas = 0});

            if (i < 4)
                preInven.Add(new Bloque() { disponible = true, id = i, tipo = 0, pzas = 0});
        }

    }

    void ActualizarDatos()
    {
        Globales script = GameObject.Find("GlobalesGO").GetComponent<Globales>();
        string direccion = script.pathForDocumentsFile("Dates.txt");
        var txtRead = new StreamReader(direccion);
        string[] datos = txtRead.ReadLine().Split("|"[0]);
        txtRead.Close();
        var txtWrite = new StreamWriter(direccion);
        for (int i = 0; i < 16; i++)
            datos[i + 13] = Inventario.block[i].pzas.ToString();

        for (int i = 0; i < 4; i++)
        {
            datos[i + 32] = Inventario.preInven[i].tipo.ToString();
            datos[i + 38] = Inventario.preInven[i].pzas.ToString();
        }

        for (int i = 0; i < datos.Length -1; i++)
            txtWrite.Write( datos[i] + "|");

        txtWrite.Close();
   
    }
}
