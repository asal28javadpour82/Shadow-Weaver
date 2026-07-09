using UnityEngine;
using UnityEngine.Tilemaps;

public class MirrorWorldManager : MonoBehaviour
{
    public static MirrorWorldManager Instance;

    [Header("Tilemaps")]
    public GameObject lightWorld;
    public GameObject mirrorWorld;

    [Header("Player")]
    public Transform player;

    [Header("Start Point")]
    public Transform startPoint;

    [Header("Enemy")]
    public GameObject snail;

    [Header("Background")]
    public GameObject backgroundNormal;
    public GameObject backgroundMirror;

    private TilemapCollider2D lightCollider;
    private TilemapCollider2D mirrorCollider;

    private bool isMirrorWorld = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        lightCollider = lightWorld.GetComponent<TilemapCollider2D>();
        mirrorCollider = mirrorWorld.GetComponent<TilemapCollider2D>();

        // شروع بازی در دنیای عادی
        lightWorld.SetActive(true);
        mirrorWorld.SetActive(false);

        if (snail != null)
            snail.SetActive(true);

        // بک‌گراند
        if (backgroundNormal != null)
            backgroundNormal.SetActive(true);

        if (backgroundMirror != null)
            backgroundMirror.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchWorld();
        }
    }

    public void SwitchWorld()
    {
        isMirrorWorld = !isMirrorWorld;

        // تغییر دنیا
        lightWorld.SetActive(!isMirrorWorld);
        mirrorWorld.SetActive(isMirrorWorld);

        RefreshCollider();

        // بازگرداندن Player به Start
        if (player != null && startPoint != null)
        {
            player.position = startPoint.position;
        }

        // ریست Shadow
        if (ShadowManager.Instance != null)
        {
            ShadowManager.Instance.ResetShadow();
        }

        // فقط در دنیای عادی دشمن فعال باشد
        if (snail != null)
        {
            snail.SetActive(!isMirrorWorld);
        }

        // تغییر بک‌گراند
        if (backgroundNormal != null)
            backgroundNormal.SetActive(!isMirrorWorld);

        if (backgroundMirror != null)
            backgroundMirror.SetActive(isMirrorWorld);

        Debug.Log(isMirrorWorld
            ? "Mirror World Activated"
            : "Normal World Activated");
    }

    private void RefreshCollider()
    {
        if (lightCollider != null)
        {
            lightCollider.enabled = false;
            lightCollider.enabled = true;
        }

        if (mirrorCollider != null)
        {
            mirrorCollider.enabled = false;
            mirrorCollider.enabled = true;
        }

        Physics2D.SyncTransforms();
    }
}