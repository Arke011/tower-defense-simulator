using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 30f;

    public float Border = 10f;

    public float scrollSpeed;

    public float minY;

    public float maxY;

    void Update()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - Border)
        {
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y >= Screen.height - Border)
        {
            
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - Border)
        {
            
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x >= Screen.width - Border)
        {
           
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

}
