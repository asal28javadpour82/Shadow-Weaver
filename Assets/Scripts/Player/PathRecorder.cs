using System.Collections.Generic;
using UnityEngine;

public class PathRecorder : MonoBehaviour
{
    public static PathRecorder Instance;

    public List<Vector3> recordedPath = new List<Vector3>();

    public float recordInterval = 0.05f;

    private float timer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        recordedPath.Clear();

        recordedPath.Add(transform.position);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            timer = 0;

            recordedPath.Add(transform.position);
            
        }
        Debug.Log(recordedPath.Count);
    }
}
