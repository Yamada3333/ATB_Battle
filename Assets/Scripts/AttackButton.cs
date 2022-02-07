using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public Unit unit;

    public void OnClickAttackButton()
    {
        unit.Attack();
        GameManager.instance.gameState = GameManager.GameState.Battle;
        gameObject.SetActive(false);
    }
}