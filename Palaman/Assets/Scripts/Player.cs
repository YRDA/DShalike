using UnityEngine;
using System.Collections;
using System.Threading;

public class player : MonoBehaviour {

    private Rigidbody2D myRB2D;
    public GameObject mycamera,peakObj;
    private Animator anima;

    public float speed;
    public bool rigth = false;
    public bool run = false;

    private Vector3 offset;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    bool grounded = false;

    public Transform blockFrontCheck;
    public bool jumping = false;
    public float jumpForce;
    public bool fronteo = false;

    mapGenerator controleX;

	void Start () {
        controleX = GameObject.Find("Generador").GetComponent<mapGenerator>();
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
        anima = gameObject.GetComponent<Animator>();
        offset = mycamera.transform.position;
	}
	
	void Update () {
        mycamera.transform.position = new Vector3(this.transform.position.x + offset.x,this.transform.position.y + offset.y + 2,this.transform.position.z + offset.z);
        caminar(0);
        saltar(false);
        cavar();
        ColocarBloque();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, whatIsGround);
        fronteo = Physics2D.OverlapCircle(blockFrontCheck.position, 0.2f, whatIsGround);

        if (fronteo || anima.GetBool("Jump")) speed = 0;
        else speed = 0.08f;

        if (grounded) jumping = false;
        else jumping = true;

        anima.SetBool("hSpeed", run);
        anima.SetBool("Ground", grounded);
        anima.SetBool("Jump",jumping);
    }

    public void caminar(int caminando)
    {
        if (caminando == -1 && !jumping)
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
            if (caminando == 1 && !jumping)
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

    public void saltar(bool Jump)
    {
        if (rigth)
        {
            if (grounded && fronteo && Jump)
            {
                Jump = false;
                fronteo = false;

                myRB2D.AddForce(new Vector2(50, jumpForce));

                anima.SetBool("Ground", false);
                anima.SetBool("Jump", true); 
            }
        }
        else
        {
            if (grounded && fronteo && Jump)
            {
                Jump = false;
                fronteo = false;

                myRB2D.AddForce(new Vector2(-50, jumpForce));

                anima.SetBool("Ground", false);
                anima.SetBool("Jump", true); 
            }
        }
    }

    private void cavar()
    {
        if(Input.GetKeyDown(KeyCode.Z) && grounded && !jumping && !run)
        {
            if (rigth)
            Instantiate(peakObj, new Vector3(this.transform.position.x + 1.5f, this.transform.position.y, -1f), transform.rotation);
            else
            Instantiate(peakObj, new Vector3(this.transform.position.x - 1.5f, this.transform.position.y, -1f), transform.rotation);
            
            anima.SetBool("Dig",true);
        }
    }

    void finCavar() {

        anima.SetBool("Dig", false);

    }

    void ColocarBloque()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            controleX.CalculoBloque(transform.position.x, transform.position.y,rigth);
        }
    }

}
