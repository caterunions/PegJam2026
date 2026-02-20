using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _groundSpeed;

    [SerializeField]
    private float _spaceAcceleration;

    [SerializeField]
    private float _maxSpaceSpeed;

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
        if (_grounded)
        {
            _rb.linearVelocity = new Vector3(_lastKnownMoveInput.x * _groundSpeed, 0, _lastKnownMoveInput.y * _groundSpeed);
        }
        else
        {
            _rb.linearVelocity += new Vector3(
                _lastKnownMoveInput.x * _spaceAcceleration * Time.deltaTime, 
                0, 
                _lastKnownMoveInput.y * _spaceAcceleration * Time.deltaTime);
            _rb.linearVelocity = Vector3.ClampMagnitude(_rb.linearVelocity, _maxSpaceSpeed);
        }
    }
}
