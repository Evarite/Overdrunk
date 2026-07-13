using UnityEngine;
using UnityEngine.InputSystem;

namespace Overdrunk.Player
{
    [AddComponentMenu("Overdrunk/Player/Movement Controller")]
    [RequireComponent(typeof(Rigidbody))]
    public class MovementControls : MonoBehaviour
    {
        private Rigidbody _rb;

        public float Speed = 10f;

        private Vector2 _moveInput;
        private PlayerCharacterInputActions _inputAction;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _inputAction = new PlayerCharacterInputActions();
        }

        private void OnEnable()
        {
            _inputAction.Player.Enable();

            _inputAction.Player.Move.performed += Move_performed;
            _inputAction.Player.Move.canceled += Move_performed;

        }
        private void OnDisable()
        {
            _inputAction.Player.Move.performed -= Move_performed;
            _inputAction.Player.Move.canceled -= Move_performed;

            _inputAction.Player.Disable();
        }

        private void Move_performed(InputAction.CallbackContext obj)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Vector3 _moveInput3 = new Vector3(_moveInput.x, _rb.linearVelocity.y, _moveInput.y);
            _rb.linearVelocity = _moveInput3 * Speed;
        }

    }
}