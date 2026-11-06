using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("Settings")]
    public Transform cameraTransform; 

    [Range(0f, 1f)]
    public float parallaxMultiplier;

    private Vector3 lastCameraPosition;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
       
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

       
        transform.position += new Vector3(deltaMovement.x * parallaxMultiplier, deltaMovement.y * parallaxMultiplier, 0);

        lastCameraPosition = cameraTransform.position;
    }
}
