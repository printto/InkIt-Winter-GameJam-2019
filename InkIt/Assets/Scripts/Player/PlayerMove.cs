using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove
{
    private float m_moveSpeed = 5;

    private float m_slopeForce = 3f;
    private float m_slopeForceRayLength = 1.5f;


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
        Vector3 moveRight = Input.GetAxis("Horizontal") * m_player.transform.right;
        Vector3 moveForward = Input.GetAxis("Vertical") * m_player.transform.forward;

        m_charController.SimpleMove(Vector3.ClampMagnitude(moveForward + moveRight, 1.0f) * m_moveSpeed);

        if ((moveRight != Vector3.zero || moveForward != Vector3.zero) && OnSlope())
        {
            m_charController.Move(Vector3.down * m_charController.height / 2 * m_slopeForce * Time.deltaTime);
        }
    }

    private bool OnSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_player.transform.position, Vector3.down, out hit, m_charController.height / 2 * m_slopeForceRayLength))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }
}
