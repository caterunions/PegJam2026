using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed;

    private Vector2 _lastKnownMoveInput;

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
        _lastKnownMoveInput = moveInput;
    }

    private void Update()
    {
        Debug.Log(_grounded);
        if (_grounded)
        {
            _rb.linearVelocity = new Vector3(_lastKnownMoveInput.x * _speed, 0, _lastKnownMoveInput.y * _speed);
        }
        
    }
}
