
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "NewPlayerControllerAsset", menuName = "Game/Player Controller")]
public class SO_PlayerController : ScriptableObject
{

    [SerializeField]
    private InputActionAsset m_InputAsset = null;

    private Vector2 m_MoveVector = Vector2.zero;

    private void OnEnable() 
    {
        BindInput(true);
    }

    private void OnDisable() 
    {
        BindInput(false);
    }

    private void BindInput(bool p_AreEnabled)
    {
        if(m_InputAsset == null)
        {
            return;
        }

        if(p_AreEnabled)
        {
            m_InputAsset.FindAction("Player/Movement").performed += Move;
            m_InputAsset.FindAction("Player/Movement").canceled += Move;
            
            m_InputAsset.Enable();
        }
        else
        {
             m_InputAsset.FindAction("Player/Movement").performed -= Move;
            m_InputAsset.FindAction("Player/Movement").canceled -= Move;

            m_InputAsset.Disable();
        }
    }

    private void Move(InputAction.CallbackContext p_Ctx)
    {
        m_MoveVector = p_Ctx.ReadValue<Vector2>();
        m_MoveVector = Vector3.ClampMagnitude(m_MoveVector, 1f);
    }

    public Vector2 MovementVector => m_MoveVector;
}
