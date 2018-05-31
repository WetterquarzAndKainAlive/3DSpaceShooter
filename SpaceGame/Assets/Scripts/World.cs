using UnityEngine;

public class World : MonoBehaviour {

	public GameObject[] astroids;

    //private Random r;

    /**mindestens 10*/
    public float maxAstroidRadius;
	public float astroidDistance;
	public int numAstroids;

	// Use this for initialization
	void Start () {
		//r = new Random ();
		Vector3[] points = new Vector3[numAstroids];
		for (int i = 0 ; i < points.Length ; i++) {
			Vector3 point = new Vector3 (Random.Range (0f, 2800f), Random.Range (0f, 2800f), Random.Range (0f, 2800f));
			for (int 	j = 0 ; j < points.Length ; j++) {
				if (Vector3.Distance(point, points[j]) < maxAstroidRadius * 2 + astroidDistance) {
					points[j] = new Vector3(-1,-1,-1);
				}
			}
			points [i] = point;
		}

		for (int i = 0 ; i < points.Length ; i++) {
			if(points[i] != new Vector3(-1,-1,-1)) {
				GameObject a = GameObject.Instantiate (astroids [Random.Range (0, astroids.Length)]);
				a.transform.localScale *= Random.Range (10, maxAstroidRadius*2);
				a.transform.localPosition = points[i];
                a.transform.rotation = Random.rotation;
			}
		}
	}
}