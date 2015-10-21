using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class masterBlockCode : MonoBehaviour {

    string valuesBlock;
    int typeBlock = 0;
    Animator animaBlocks;
    creatorMap maping = new creatorMap();

	// Update is called once per frame

    void Start()
    {
        animaBlocks = gameObject.GetComponent<Animator>();
    }
	void Update () {
        animaBlocks.SetInteger("type",typeBlock);
	}

    void OnMouseDown()
    {
        //var maping = gameObject.AddComponent<creatorMap>();

        if (typeBlock == 8)
        {
            typeBlock = 0;
            maping.actualizarvalues(transform.position.x,transform.position.y,0,0);
        }
        else
        {
            typeBlock += 1;
            maping.actualizarvalues(transform.position.x, transform.position.y, 1, typeBlock);
        }
    }
}
