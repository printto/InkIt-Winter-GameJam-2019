using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float m_moveSpeed = 6;

    private GameObject m_player;
    private CharacterController m_charController;
    public PlayerMove(GameObject player)
    {
        m_player = player;
        m_charController = m_player.GetComponent<CharacterController>();
    }
    public void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 moveRight = Input.GetAxis("Horizontal") * m_moveSpeed * m_player.transform.right;
        Vector3 moveForward = Input.GetAxis("Vertical") * m_moveSpeed * m_player.transform.forward;
        m_charController.SimpleMove(moveForward + moveRight);
    }
}
