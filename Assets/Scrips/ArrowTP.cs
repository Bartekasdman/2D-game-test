using UnityEngine;

public class ArrowTP : MonoBehaviour
{
    public GameObject BowScript; // Prefab for the arrow to be shot
    

    void Update()
    {
       
        
    }

    void TeleportToHitPoint(GameObject BowScript)
    {
        // Set up a raycast to check if the arrow hits anything
        RaycastHit hit;
        if (Physics.Raycast( transform.position, transform.forward, out hit))
        {
            // If the arrow hits something, teleport the character to the hit point
            transform.position = hit.point;
        }
    }
}