using UnityEngine;

public class Controller : MonoBehaviour {

	//public GameObject camera;
	public Camera ThirdPersonCam;
    public Camera FirstPersonCam;
    public GameObject[] gunsSocket;
    public GameObject[] guns;
    public GameObject laser;
    private bool boost = false;

    private float nextFire = 0;

    private Quaternion offset = new Quaternion(70, 0, 0, 0);

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
        ThirdPersonCam.enabled = true;
        FirstPersonCam.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w")) //Bewegung gradeaus
			transform.GetComponent<Rigidbody> ().AddForce (transform.forward * Time.deltaTime * 8000, ForceMode.Acceleration);
        if (Input.GetKeyDown("f"))
            boost = !boost;
		if(boost) //Bewegung boost
			transform.GetComponent<Rigidbody> ().AddForce (transform.forward * Time.deltaTime * 20000, ForceMode.Acceleration);
		if(Input.GetKey("s")) //Bewegung back
			transform.GetComponent<Rigidbody> ().AddForce (-transform.forward * Time.deltaTime * 1300, ForceMode.Acceleration);
		if (Input.GetKey ("d")) //Drehung nach rechts
			transform.GetComponent<Rigidbody> ().AddTorque (transform.localRotation * new Vector3 (0, Time.deltaTime * 50, 0), ForceMode.Acceleration);
		if (Input.GetKey ("a")) //Drehung nach links
			transform.GetComponent<Rigidbody> ().AddTorque (transform.localRotation * new Vector3 (0, Time.deltaTime * -50, 0), ForceMode.Acceleration);
		if (Input.GetKey ("q")) //Drehung um die lokale z-Achse nach links
			transform.GetComponent<Rigidbody> ().AddTorque (transform.localRotation * new Vector3 (0,0, Time.deltaTime * 30), ForceMode.Acceleration);
		if (Input.GetKey ("e")) //Drehung um die lokale z-Achse nach rechts
			transform.GetComponent<Rigidbody> ().AddTorque (transform.localRotation * new Vector3 (0,0, Time.deltaTime * -30), ForceMode.Acceleration);


        ThirdPersonCam.transform.RotateAround (transform.position, transform.up, -100 * Input.GetAxis("Mouse X") * Time.deltaTime);
        ThirdPersonCam.transform.RotateAround (transform.position, ThirdPersonCam.transform.rotation * new Vector3(1,0,0), -100 * Input.GetAxis("Mouse Y") * Time.deltaTime);

        
        foreach(GameObject gun in gunsSocket) {
            gun.transform.localRotation = Quaternion.AngleAxis(FirstPersonCam.transform.localRotation.y*100,Vector3.up);
        }
        /*
        foreach(GameObject gun in guns) {
            gun.transform.localRotation = Quaternion.AngleAxis(-cam.transform.localRotation.x * 100, Vector3.left);
        }
        */
        if (nextFire > 0)
            nextFire -= Time.deltaTime;
        else if(Input.GetAxis("Fire1") > 0)
            foreach(GameObject gun in guns){
                GameObject a = GameObject.Instantiate(laser);
                a.transform.position = gun.transform.position;
                a.transform.rotation = gun.transform.rotation;
                nextFire = 0.2f;
        }

        if(Input.GetKeyDown("v") && ThirdPersonCam.enabled)
        {
            ThirdPersonCam.enabled = false;
            FirstPersonCam.enabled = true;
        }
        else if(Input.GetKeyDown("v") && !ThirdPersonCam.enabled)
        {
            ThirdPersonCam.enabled = true;
            FirstPersonCam.enabled = false;
        }

	}
}
