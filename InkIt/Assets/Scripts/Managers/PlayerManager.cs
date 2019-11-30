using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private PlayerLook m_playerLook;
    private PlayerMove m_playerMove;

    private GameObject m_player;
    public PlayerManager(GameObject player)
    {
        m_player = player;
        m_playerLook = new PlayerLook(m_player);
        m_playerMove = new PlayerMove(m_player);
    }

    public void Update()
    {
        m_playerLook.Update();
        m_playerMove.Update();
    }
}
