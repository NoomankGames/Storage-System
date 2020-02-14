/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum Axes { Horizontal, Vertical }
    public Axes axis = Axes.Horizontal;

    public float sensitivity = 3.0f;
    [HideInInspector] public float rotationX = 0.0f;//Current object rotation along the X axis
    [HideInInspector] public float rotationY = 0.0f;//Current object rotation along the Y axis

    [SerializeField] private float _minimumXAngle = -90.0f;
    [SerializeField] private float _maximumXAngle = 90.0f;

    private void Start()
    {
        rotationX = transform.localEulerAngles.x;
        rotationY = transform.localEulerAngles.y;
    }

    private void LateUpdate()
    {
        if (axis == Axes.Horizontal)
        {
            HorizontalLook();
        }
        else if (axis == Axes.Vertical)
        {
            VerticalLook();
        }
    }

    /// <summary>
    /// Horizontal rotation (along the Y axis) allows you to rotate an object by moving the mouse (along the X axis)
    /// </summary>
    private void HorizontalLook()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
    }

    /// <summary>
    /// Vertical rotation (along the X axis) allows you to rotate an object by moving the mouse (along the Y axis)
    /// </summary>
    private void VerticalLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, _minimumXAngle, _maximumXAngle);
        transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}