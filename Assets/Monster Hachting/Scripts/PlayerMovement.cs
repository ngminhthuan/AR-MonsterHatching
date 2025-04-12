using UnityEngine;

public class PlayerMovement : APlayerComponent
{
    public GameObject robots;
    public float moveSpeed = 2f;
    public Joystick joystick;
    public float rotationSpeed = 5f;

    private Vector2 touchStartPos;
    private bool isDragging = false;

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0);

        if (moveDirection.magnitude > 0.1f)
        {
            robots.transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
            PlayerManager.Instance.PlayAnimation(PlayerAnimationType.RUNNING, true);
        }
        else
        {
            PlayerManager.Instance.PlayAnimation(PlayerAnimationType.RUNNING, false);
        }
    }

    void HandleRotation()
    {
        if (Input.GetMouseButtonDown(0)) // Start dragging
        {
            touchStartPos = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging) // While dragging
        {
            Vector2 touchDelta = (Vector2)Input.mousePosition - touchStartPos;
            float rotationY = touchDelta.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotationY, 0);
            touchStartPos = Input.mousePosition; // Update for smooth rotation
        }
        else if (Input.GetMouseButtonUp(0)) // Stop dragging
        {
            isDragging = false;
        }
    }
}
