using UnityEngine;

public class characterController : MonoBehaviour
{
    private CharacterController _charController;
    private Vector3 _velocity;
    private bool _jump = false;
    private bool _isJumping = false;
    private Vector3 _movement;

    [Header("Locomotion Parameters")]
    [SerializeField]
    private float _groundSpeed = 100;
    [SerializeField]
    private float _jumpHeight = 3;
    private Transform _absoluteForward;
    [SerializeField]
    private float _dragOnGround = 10;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _absoluteForward = transform;
    }

    public void teleport(Vector3 v)
    {
        _charController.enabled = false;
        transform.position = v;
        _charController.enabled = true;
    }


    // Update is called once per frame
    private void Update()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetButton("Jump") && !_isJumping)
        {
            _jump = true;
        }
    }

    void FixedUpdate()
    {
        ApplyGround();
        ApplyGravity();
        ApplyMovement();
        ApplyGroundDrag();
        ApplyJump();
        _charController.Move(_velocity * Time.fixedDeltaTime);
    }


    private void ApplyJump()
    {
        if (_charController.isGrounded && _jump)
        {
            _isJumping = true;
            _jump = false;
            _velocity += -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
        }
        else if (_charController.isGrounded)
        {
            _isJumping = false;
        }
    }

    private void ApplyMovement()
    {
        Vector3 xzAbsoluteForward = Vector3.Scale(_absoluteForward.forward, new Vector3(1, 0, 1));
        Quaternion forwardRotation = Quaternion.LookRotation(xzAbsoluteForward);
        Vector3 relativeMovement = forwardRotation * _movement;
        _velocity += relativeMovement * _groundSpeed * Time.deltaTime; // F(= m.a) [m/s^2] * t [s]    }
    }

    private void ApplyGroundDrag()
    {
        _velocity.x = _velocity.x * (1 - Time.deltaTime * _dragOnGround);
        _velocity.z = _velocity.z * (1 - Time.deltaTime * _dragOnGround);
    }


    private void ApplyGravity()
    {
        if (!_charController.isGrounded)
        {
            _velocity += Physics.gravity * Time.fixedDeltaTime;
        }
    }

    private void ApplyGround()
    {
        if (_charController.isGrounded)
        {
            _velocity -= Vector3.Project(_velocity, Physics.gravity.normalized);
        }
    }

}
