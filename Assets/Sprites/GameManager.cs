using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxHP = 100;
    private int currentHP;

    public TextMeshProUGUI hpText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        currentHP = maxHP;
        UpdateHPText();
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPText();

        if (currentHP <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    void UpdateHPText()
    {
        hpText.text = "HP: " + currentHP;
    }
}
