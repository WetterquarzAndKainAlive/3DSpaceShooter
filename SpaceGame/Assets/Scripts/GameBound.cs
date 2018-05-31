using UnityEngine;

public class GameBound : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Boom");
            Destroy(other.gameObject);
            
            
        }
    }

}
