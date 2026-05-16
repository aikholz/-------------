using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI coinText;
    private int totalCoins;
    private int collectedCoins;

    void Awake()
    {
        // Одиночка (Singleton)
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
    }

    void Start()
    {
        // Находим все монеты на сцене
        Coin[] coins = FindObjectsByType<Coin>(FindObjectsSortMode.None);
        totalCoins = coins.Length;
        collectedCoins = 0;

        UpdateUI();

        // Отладочная информация (можно удалить позже)
        Debug.Log($"=== Уровень: {UnityEngine.SceneManagement.SceneManager.GetActiveScene().name} ===");
        Debug.Log($"Найдено монет на сцене: {totalCoins}");
    }

    public void AddCoins(int amount)
    {
        collectedCoins += amount;
        Debug.Log($"Собрано монет: {collectedCoins} / {totalCoins}");
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (coinText != null)
            coinText.text = $"{collectedCoins} / {totalCoins}";
        else
            Debug.LogWarning("CoinText не назначен в GameManager!");
    }

    // Методы для доступа из других скриптов
    public int GetCollectedCoins() => collectedCoins;
    public int GetTotalCoins() => totalCoins;
}