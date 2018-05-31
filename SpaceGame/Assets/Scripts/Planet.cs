using UnityEngine;

public class Planet : MonoBehaviour {

    public float rotationDamp = 20f;

	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationDamp * Time.deltaTime);
	}
}
