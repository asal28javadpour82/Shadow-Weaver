using UnityEngine;

public class ShadowManager : MonoBehaviour
{
    public static ShadowManager Instance;

    public GameObject player;
    public GameObject shadow;

    private bool shadowMode = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleShadow();
        }
    }

    void ToggleShadow()
    {
        shadowMode = !shadowMode;

        if (shadowMode)
        {
            shadow.SetActive(true);

            shadow.transform.position = player.transform.position;

            player.GetComponent<PlayerController>().enabled = false;

            shadow.GetComponent<PlayerController>().enabled = true;
        }
        else
        {
            player.transform.position = shadow.transform.position;

            shadow.SetActive(false);

            player.GetComponent<PlayerController>().enabled = true;
        }
    }
}
