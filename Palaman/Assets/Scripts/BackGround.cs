using UnityEngine;
using System.Collections;

public class backGround : MonoBehaviour {

    public float speed;
    public GameObject mybackground;
    private float setoff;

	// Use this for initialization
	void Start () 
    {
        setoff = mybackground.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if ( setoff < mybackground.transform.position.x )
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed) % 1, 0f);
            setoff = mybackground.transform.position.x;
        }
        else
        {
            if (setoff > mybackground.transform.position.x)
            {
                GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * -speed) % 1, 0f);
                setoff = mybackground.transform.position.x;
            }
        }
	}
}
