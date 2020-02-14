/*
 * author : Kirakosyan Nikita
 * e-mail : noomank.games@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    public float walkSpeed = 5.0f;

    private CharacterController _characterController = null;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// The method allows you to move the object along the X and Z axes using WASD or arrows
    /// </summary>
    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * walkSpeed;
        float deltaZ = Input.GetAxis("Vertical") * walkSpeed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = transform.TransformVector(movement);
        movement = Vector3.ClampMagnitude(movement, walkSpeed);
        movement *= Time.deltaTime;

        _characterController.Move(movement);
    }
}