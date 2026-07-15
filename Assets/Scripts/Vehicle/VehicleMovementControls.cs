using UnityEngine;
using UnityEngine.InputSystem;

namespace Overdrunk.Vehicle
{
    [AddComponentMenu("Overdrunk/Vehicle/Vehicle Controller")]
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleMovementControls : MonoBehaviour
    {
        private Rigidbody _rb;

        [Header("Move speed")]
        [SerializeField]
        private float _speed = 10f;
        public float Speed{get => _speed;set => _speed = value;}
        private Vector2 _moveInput;
        private InputActions _inputAction;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _inputAction = new InputActions();
        }

        private void OnEnable()
        {
            _inputAction.Vehicle.Enable();

            _inputAction.Vehicle.Move.performed += MovePerformed;
            _inputAction.Vehicle.Move.canceled += MovePerformed;
        }
        private void OnDisable()
        {
            _inputAction.Vehicle.Move.performed -= MovePerformed;
            _inputAction.Vehicle.Move.canceled -= MovePerformed;

            _inputAction.Vehicle.Disable();
        }

        private void MovePerformed(InputAction.CallbackContext obj)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }


        private void FixedUpdate()
        {

            Vector2 _normalizedInput = Speed* Vector2.ClampMagnitude(_moveInput, 1f);

            _rb.linearVelocity = new Vector3(
                _normalizedInput.x, 
                _rb.linearVelocity.y, 
                _normalizedInput.y
            );
        }

    }
}