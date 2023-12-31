using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShadowChimera
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset m_inputActionAsset;
        [SerializeField] private CharacterController m_characterController;
        [SerializeField] private float m_speedMove = 5f;

        public InputAction inputAction;

        private InputActionMap m_playerMap;
        private InputAction m_moveAction;
        private void Awake()
        {
            m_playerMap = m_inputActionAsset.FindActionMap("Player");
            m_moveAction = m_playerMap.FindAction("Move");


        }

        private void OnEnable()
        {
            m_playerMap.Enable();
        }

        private void OnDisable()
        {
            m_playerMap.Disable();
        }
        private void Update()
        {
           Vector2 move = m_moveAction.ReadValue<Vector2>();
            if (move != Vector2.zero) 
            {
                Vector3 dir = new Vector3(move.x, 0f, move.y);
                m_characterController.SimpleMove(move * m_speedMove);
            }
        }
    }
}
