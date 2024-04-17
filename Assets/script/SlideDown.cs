using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDown : MonoBehaviour
{
    public float slideSpeed = 5f; // Speed of sliding
    public float slideRayLength = 1f; // Length of the ray used to detect surface
    public LayerMask slideLayerMask; // Layer mask for detecting surfaces to slide on
    private Rigidbody rb;
    public string slideableObjectTag = "SlideableObject";

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
    // Cast a ray downwards to detect surfaces
    RaycastHit hit;
    if (Physics.Raycast(transform.position, -transform.up, out hit, slideRayLength, slideLayerMask))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name); // Log the name of the hit object

            // Check if the hit object has the specified tag
            if (hit.collider.CompareTag(slideableObjectTag))
            {
                // If the ray hits a surface with the specified tag, calculate the slide direction
                Vector3 slideDirection = Vector3.ProjectOnPlane(-transform.up, hit.normal).normalized;

                // Apply sliding force
                rb.AddForce(slideDirection * slideSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
