using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;

        // دوربین فوراً روی هدف جدید قرار بگیرد
        transform.position = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        // Offset جدید فقط در محور Z
        offset = new Vector3(0f, 0f, offset.z);
    }
}
