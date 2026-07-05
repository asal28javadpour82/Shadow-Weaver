using UnityEngine;

public class ShadowManager : MonoBehaviour
{
    public static ShadowManager Instance;

    [Header("Characters")]
    public GameObject player;
    public GameObject shadow;

    [Header("Stage Start")]
    public Transform startPoint;

    private bool shadowMode = false;

    private CameraController cameraController;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();

        shadow.SetActive(false);

        player.GetComponent<PlayerController>().enabled = true;
        shadow.GetComponent<PlayerController>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateShadow();
        }
    }

    private void ActivateShadow()
    {
        if (shadowMode)
            return;

        shadowMode = true;

        player.GetComponent<PlayerController>().enabled = false;

        shadow.transform.position = startPoint.position;

        shadow.SetActive(true);

        shadow.GetComponent<PlayerController>().enabled = true;

        if (cameraController != null)
        {
            cameraController.SetTarget(shadow.transform);
        }
    }
}
