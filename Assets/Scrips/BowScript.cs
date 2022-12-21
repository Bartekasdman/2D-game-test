using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{

    Vector2 Direction;

    public float force;

    public GameObject PointPrefab;

    public GameObject[] Points;

    public int numberOfpoints;


    // Start is called before the first frame update
    void Start()
    {
       Points = new GameObject[numberOfpoints];

       for (int i = 0; i < numberOfpoints; i++)
       {
        Points[i] = Instantiate(PointPrefab,transform.position,Quaternion.identity);
       }
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      Vector2 bowPos = transform.position;

      Direction = MousePos - bowPos;

      faceMouse(); 

      for (int i = 0; i < Points.Length; i++)
      {
        Points[i].transform.position = PointPosition(i * 0.1f);
      } 
    }

    void faceMouse()
    {
        transform.right = Direction;
        
    }
    // arrow fall pattern
    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t*t);

         return currentPointPos;
    }
    void TeleportToHitPoint(GameObject ArrowClone)
    {
        // Set up a raycast to check if the arrow hits anything
        RaycastHit hit;
        if (Physics.Raycast(ArrowClone.transform.position, ArrowClone.transform.forward, out hit))
        {
            // If the arrow hits something, teleport the character to the hit point
            transform.position = hit.point;
        }
    }
    
    
}
