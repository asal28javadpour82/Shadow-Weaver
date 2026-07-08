using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    public float minX = -100f;
    public float maxX = 100f;

    private Vector3 offset;
    private float fixedY;

    void Start()
    {
        offset = transform.position - target.position;

        // ارتفاع دوربین همیشه ثابت می‌ماند
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, minX, maxX),
            fixedY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;

        transform.position = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, minX, maxX),
            fixedY,
            transform.position.z
        );
    }
}
