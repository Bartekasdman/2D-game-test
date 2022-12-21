using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{

    public GameObject Arrow;

    public float LaunchForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
         // Set up a raycast to check if the arrow hits anything
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // If the arrow hits something, teleport the character to the hit point
            transform.position = hit.point;
        }
    }

    void Shoot()
    {
        GameObject ArrowIns = Instantiate(Arrow,transform.position,transform.rotation);

        ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        
    }
    
    
}
