using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // پخش صدای جمع کردن کریستال
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayCoin();

            // اضافه شدن کریستال
            GameManager.Instance.AddCrystal();

            // حذف کریستال
            Destroy(gameObject);
        }
    }
}
