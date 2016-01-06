using UnityEngine;
using System.Collections;

public class GemaScript : MonoBehaviour {

    Animator animaGema;
    public int intGema;
    bool boolSpecial;
    PowerBar barPowr;

    void Start()
    {
        barPowr = GameObject.Find("SpecialBar").GetComponent<PowerBar>();
        animaGema = GameObject.Find("GemaBarra").GetComponent<Animator>();
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
