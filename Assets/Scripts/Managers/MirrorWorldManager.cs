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

        lightWorld.SetActive(true);
        mirrorWorld.SetActive(false);

        if (snail != null)
            snail.SetActive(true);
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

        lightWorld.SetActive(!isMirrorWorld);
        mirrorWorld.SetActive(isMirrorWorld);

        RefreshCollider();

        // Player برگردد ابتدای مرحله
        if (player != null && startPoint != null)
        {
            player.position = startPoint.position;
        }

        // ریست کامل Shadow
        if (ShadowManager.Instance != null)
        {
            ShadowManager.Instance.ResetShadow();
        }

        // فقط در Light World دشمن فعال باشد
        if (snail != null)
        {
            snail.SetActive(!isMirrorWorld);
        }

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