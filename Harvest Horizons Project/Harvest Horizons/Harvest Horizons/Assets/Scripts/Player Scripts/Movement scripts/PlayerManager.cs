using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement2D movement2D => GetComponent<PlayerMovement2D>();
    KeyboardInputs keyboardInputs => GetComponent<KeyboardInputs>();
    TileManager tileManager; 

    [SerializeField] private Grid grid;
    private void Start()
    {
        tileManager = FindFirstObjectByType<TileManager>(); 
    }
    private void Update()
    {
        movement2D.Move(keyboardInputs.GetInput());

        if (keyboardInputs.GetInteract())
        {
            Vector3Int tilePosition = grid.WorldToCell(transform.position);
            tileManager.TillGround(tilePosition);
        }
    }

}
