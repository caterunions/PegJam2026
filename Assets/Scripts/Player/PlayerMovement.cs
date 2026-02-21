using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float groundSpeed;

    [SerializeField]
    private float spaceAcceleration;

    [SerializeField]
    private float maxSpaceSpeed;

    private Vector2 lastKnownMoveInput;

    private float angle;

    private bool canMove = true;
    public void Activate() { canMove = true; }
    public void Deactivate() { canMove = false; }

    private bool _grounded
    {
        get
        {
            return Physics.BoxCast(
                transform.position, // pos
                Vector3.one / 2, // half extents
                Vector3.down, // direction
                Quaternion.identity, // orientation
                2, // length
                LayerMask.GetMask("Ship")); // only check for ship layer
        }
    }

    public void HandleMove(Vector2 moveInput)
    {
        lastKnownMoveInput = moveInput;

        if(moveInput != Vector2.zero)
        {
            angle = (Mathf.Rad2Deg * Mathf.Atan2(moveInput.x, moveInput.y)) - 90;
        }
    }

    private void Update()
    {
        if(!canMove)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        if (_grounded)
        {
            rb.linearVelocity = new Vector3(lastKnownMoveInput.x * groundSpeed, 0, lastKnownMoveInput.y * groundSpeed);
        }
        else
        {
            rb.linearVelocity += new Vector3(
                lastKnownMoveInput.x * spaceAcceleration * Time.deltaTime, 
                0, 
                lastKnownMoveInput.y * spaceAcceleration * Time.deltaTime);
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpaceSpeed);
        }
    }
}
