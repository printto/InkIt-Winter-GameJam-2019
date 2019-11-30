using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagersBehavior : MonoBehaviour
{
    public static ManagersBehavior Instance;
    public GameObject Player;


    private GameManager gameManager;
    private PlayerManager playerManager;

    private void Awake()
    {
        gameManager = new GameManager();
        playerManager = new PlayerManager(Player);
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        gameManager.Update();
        playerManager.Update();
    }
}
