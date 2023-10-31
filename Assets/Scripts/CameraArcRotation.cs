using UnityEngine;

public class CameraArcRotation : MonoBehaviour
{
    private Vector3 initialMousePos;
    private Vector3 currentMousePos;
    private float rotationSpeed = 1.0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            currentMousePos = Input.mousePosition;

            Vector3 initialPosition = ScreenToWorldPoint(initialMousePos);
            Vector3 currentPosition = ScreenToWorldPoint(currentMousePos);

            float angle = Vector3.SignedAngle(initialPosition, currentPosition, Vector3.up);

            // Вращаем камеру вокруг нулевых координат сцены
            transform.RotateAround(Vector3.zero, Vector3.up, angle * rotationSpeed);

            initialMousePos = currentMousePos;
        }
    }

    Vector3 ScreenToWorldPoint(Vector3 screenPos)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}