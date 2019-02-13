using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    [SerializeField] float spinSpeed = 90;
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

    private void Rotate()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}
