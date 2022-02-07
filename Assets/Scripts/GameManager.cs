using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState;
    public List<Unit> units;

    public AttackButton attackButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        attackButton.gameObject.SetActive(false);
        gameState = GameState.Battle;
    }

    private void FixedUpdate()
    {
        if (gameState != GameState.Battle) return;
        foreach (var unit in units)
        {
            unit.Action();
        }
    }

    public void GamePose()
    {
        gameState = GameState.Pose;
        attackButton.gameObject.SetActive(true);
    }

    public enum GameState
    {
        Pose,
        Battle
    }
}