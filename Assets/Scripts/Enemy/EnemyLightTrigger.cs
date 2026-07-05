using UnityEngine;

public class EnemyLightTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();

            if (health != null)
            {
                Debug.Log("Shadow Hit By Light");

                health.Die();
            }
        }
    }
}
