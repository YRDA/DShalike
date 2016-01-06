using UnityEngine;
using System.Collections;

public class RotateFlash : MonoBehaviour {

    float speedRotation = 200;

	void Update () {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speedRotation));
	}
}
