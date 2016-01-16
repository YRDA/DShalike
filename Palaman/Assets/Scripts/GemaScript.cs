using UnityEngine;
using System.Collections;
using System.IO;

public class GemaScript : MonoBehaviour {

    Animator animaGema;
    public int intGema;
    bool boolSpecial;
    PowerBar barPowr;
    public GameObject[] gema = new GameObject[8];

    void Start()
    {
        if (this.name == "PanelSpecial(Clone)")
            CargarGemas();
        else
        {
            barPowr = GameObject.Find("SpecialBar").GetComponent<PowerBar>();
            animaGema = GameObject.Find("GemaBarra").GetComponent<Animator>();
        }
    }

    private void CargarGemas()
    {
        Globales dir = GameObject.Find("GlobalesGO").GetComponent<Globales>();
        string direccion = dir.pathForDocumentsFile("Dates.txt");
        var txtRead = new StreamReader(direccion);
        string[] datos = txtRead.ReadLine().Split("|"[0]);
        txtRead.Close();
        for (int i = 5; i < 13; i++)
        {
            if (datos[i] == "1")
                gema[i - 5].SetActive(true);
            else
                gema[i - 5].SetActive(false);
        }
    }

    void OnMouseOver()
    {
        string[] numGema;
        boolSpecial = true;
        numGema = this.name.Split("_"[0]);
        int.TryParse(numGema[1], out intGema);
        animaGema.SetInteger("Gemax", intGema);
    }

    void OnMouseUp()
    {
        if (boolSpecial)
        {
            boolSpecial = false;
            barPowr.PAUSA = false;
            barPowr.boolPanel = true;
            barPowr.booltime = true;
            Destroy(GameObject.Find("PanelSpecial(Clone)"));
        }
    }

}
