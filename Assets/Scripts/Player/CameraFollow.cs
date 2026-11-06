using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; 
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 0, -10f);

    [Header("Settings Boundaries")]
    public Vector2 minBounds; // vector de la esquina inferior izquierda 
    public Vector2 maxBounds; // vector de la esquina superior derecha 

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 position = target.position + offset;

   
        float clampedX = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, position.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);
    }
}
