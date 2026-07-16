using UnityEngine;
using UnityEngine.InputSystem;

namespace Overdrunk.Player
{
    [AddComponentMenu("Overdrunk/Player/Player Movement Controls")]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementControls : MonoBehaviour
    {
        private Rigidbody _rb;

        [field: SerializeField] public float Speed { get; set; } = 10f;

        private Vector2 _moveInput;

        private void Awake() => _rb = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            GameManager.Instance.InputActions.Player.Move.performed += MovePerformed;
            GameManager.Instance.InputActions.Player.Move.canceled += MovePerformed;

        }
        private void OnDisable()
        {
            GameManager.Instance.InputActions.Player.Move.performed -= MovePerformed;
            GameManager.Instance.InputActions.Player.Move.canceled -= MovePerformed;
        }

        private void MovePerformed(InputAction.CallbackContext obj) =>
            _moveInput = obj.ReadValue<Vector2>();

        private void FixedUpdate()
        {
            Vector2 normalizedInput = Speed * Vector2.ClampMagnitude(_moveInput, 1f);

            _rb.linearVelocity = new Vector3(
                normalizedInput.x,
                _rb.linearVelocity.y,
                normalizedInput.y
            );
        }
    }
}