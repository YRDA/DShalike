using UnityEngine;
using System.Collections;

public class ControlLevel01 : MonoBehaviour {

    public GameObject jugador, mycamera, caverna, caverna_;
    string moviepath = "Movies/Level 01.wmv";
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    }
}
