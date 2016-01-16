using UnityEngine;
using System.Collections;

public class ShalikeVision : MonoBehaviour {

    public GameObject btnAtack, btnCavar;
    float timeOver;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            btnAtack.SetActive(true);
            btnCavar.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        btnAtack.SetActive(false);
        btnCavar.SetActive(true);
    }
}
