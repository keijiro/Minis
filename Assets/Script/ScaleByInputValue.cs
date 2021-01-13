using UnityEngine;
using UnityEngine.InputSystem;

sealed class ScaleByInputValue : MonoBehaviour
{
    [SerializeField] Transform _transform = null;
    [SerializeField] InputAction _action = null;

    void OnEnable()
    {
        _action.performed += OnPerformed;
        _action.Enable();
    }

    void OnDisable()
    {
        _action.performed -= OnPerformed;
        _action.Disable();
    }

    void OnPerformed(InputAction.CallbackContext ctx)
      => _transform.localScale = Vector3.one * ctx.ReadValue<float>();
}
