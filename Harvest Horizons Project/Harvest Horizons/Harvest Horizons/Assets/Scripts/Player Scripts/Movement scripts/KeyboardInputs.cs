using UnityEngine;

public class KeyboardInputs : MonoBehaviour
{
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode up = KeyCode.W;
    [SerializeField] KeyCode down = KeyCode.S;
    [SerializeField] KeyCode interact = KeyCode.Space;
    Vector2 Direction;


    public Vector2 GetInput()
    {
        Direction = Vector2.zero;

        if (Input.GetKey(left))
        {
            Direction.x = -1;
        }
        if (Input.GetKey(right))
        { Direction.x = 1; }
        if (Input.GetKey(up))
        { Direction.y = 1; }
        if (Input.GetKey(down))
        { Direction.y = -1; }

        return Direction;
    }
    public bool GetInteract()
    {
        return Input.GetKeyDown(interact); 
    }
}
