using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PlayerMovement2D : MonoBehaviour
{
 Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [SerializeField] float movementSpeed = 5f;


    public void Move(Vector2 pDirection)
    {
        rb.linearVelocity = pDirection * movementSpeed;
    }
}
