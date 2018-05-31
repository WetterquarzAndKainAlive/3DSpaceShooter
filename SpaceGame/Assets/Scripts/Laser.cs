using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private float tminus = 30f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.VelocityChange);
    }
	
	// Update is called once per frame
	void Update () {
        tminus -= Time.deltaTime;
        if (tminus <= 0)
            Destroy(gameObject);
    }
}
