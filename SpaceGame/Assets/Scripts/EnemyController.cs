using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform target;
    public float rotationalDamp = 0.5f;
    public float movementSpeed = 10f;

    public float rayCastOffstetUpDown = 2.5f;
    public float rayCastOffstetLeftRight = 10f;
    public bool drawLines = true;
    public float detectionDist = 20f;

    public float shootCheckDist = 10f;

    public float distToGetFaster = 50f;

    void Update()
    {
        if (target != null)
        {
            Pathfinding();
            Move();
        }
    }

    void FixedUpdate()
    {
        
        if (target != null)
        {
            CheckDistance();
        }

    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * rayCastOffstetLeftRight;
        Vector3 right = transform.position + transform.right * rayCastOffstetLeftRight;

        Vector3 up = transform.position + transform.up * rayCastOffstetUpDown;
        Vector3 down = transform.position - transform.up * rayCastOffstetUpDown;

        if(drawLines)
        {
            Debug.DrawRay(left, transform.forward * detectionDist, Color.green);
            Debug.DrawRay(right, transform.forward * detectionDist, Color.green);

            Debug.DrawRay(up, transform.forward * detectionDist, Color.green);
            Debug.DrawRay(down, transform.forward * detectionDist, Color.green);
        }

        if(Physics.Raycast(left, transform.forward, out hit, detectionDist))
        {
            raycastOffset += Vector3.right;
            //Debug.Log("Hit Left");
        }
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDist))
        {
            raycastOffset -= Vector3.right;
            //Debug.Log("Hit Right");
        }

        if (Physics.Raycast(up, transform.forward, out hit, detectionDist))
        {
            raycastOffset -= Vector3.up;
            //Debug.Log("Hit Up");
        }
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDist))
        {
            raycastOffset += Vector3.up;
            //Debug.Log("Hit Down");
        }

        if(raycastOffset != Vector3.zero)
        {
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }

    void CheckDistance()
    {
		float d = Vector3.Distance (transform.position, target.transform.position);
       if(d < shootCheckDist)
        {
            movementSpeed = 0.1f;
            rotationalDamp = 1f;
        }
       else if (d > distToGetFaster)
        {
            movementSpeed = 20f;
            rotationalDamp = 2.5f;
        }
       else
        {
            movementSpeed = 10f;
            rotationalDamp = 0.5f;
        }
        
    }

}
