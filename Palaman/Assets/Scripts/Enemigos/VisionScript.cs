using UnityEngine;
using System.Collections;

public class VisionScript : MonoBehaviour {

    public int enemy;
    public wanflyScript wanfliS;
    public GrockScript GrockS;

    void OnTriggerEnter2D(Collider2D col)
    {
        // si entra dentro del rango de vision
        if (col.gameObject.name == "Shalike")
        {
            switch (enemy)
            {
                case 1:
                    wanfliS.stepPlayer = true;
                    Destroy(this.gameObject);// destruimos el campo de vision
                    break;
                case 2:
                    GrockS.stepPlayer = true;
                    break;
                default:
                    break;
            }
           
            
        }
    }

}
