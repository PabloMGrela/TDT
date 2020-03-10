using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minimumY = 15f;
    public float maximumY = 80f;

    private float screenHeight = Screen.height;
    private float screenWidht = Screen.width;
    private bool doMovement = true;

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        zoomCamera();
    }

    private void moveCamera()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= screenHeight - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= screenWidht - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
    }

    private void zoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minimumY, maximumY);
        transform.position = position;
    }
}
