using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject Stock;

    void Start()
    {

    }
    RaycastHit hit;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var clone = Instantiate(Stock);
                Transform objectHit = hit.transform;
                Debug.Log(hit.point);
                clone.transform.position = hit.point + new Vector3(0,clone.transform.localScale.y/2);

            }
            // Do something with the object that was hit by the raycast.

        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hit.point, 3);
    }
}