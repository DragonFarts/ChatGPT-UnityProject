using System.Collections;
using UnityEngine;

public class RaycastDeleter : MonoBehaviour
{
    public GameObject insertGameObject;
    public float interval = 1000.0f; // interval in milliseconds

    private float lastTime;

    void Start()
    {
        lastTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastTime > interval / 1000.0f)
        {
            lastTime = Time.time;

            Ray ray = new Ray(insertGameObject.transform.position, insertGameObject.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
