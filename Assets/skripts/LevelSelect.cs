using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    [Header("Coins Display Text")]
    [SerializeField] private TextMeshProUGUI coinsTextLev1;
    [SerializeField] private TextMeshProUGUI coinsTextLev2;
    [SerializeField] private TextMeshProUGUI coinsTextLev3;

    [Header("Total Coins Per Level")]
    [SerializeField] private int totalCoinsLev1 = 25;
    [SerializeField] private int totalCoinsLev2 = 30;
    [SerializeField] private int totalCoinsLev3 = 30;

    void Start()
    {
        UpdateCoinsDisplay();
    }

    private void UpdateCoinsDisplay()
    {
        if (coinsTextLev1 != null)
        {
            int collected = PlayerPrefs.GetInt("Lev1_Coins", 0);
            coinsTextLev1.text = $"{collected}/{totalCoinsLev1}\nCoins";
        }

        if (coinsTextLev2 != null)
        {
            int collected = PlayerPrefs.GetInt("Lev2_Coins", 0);
            coinsTextLev2.text = $"{collected}/{totalCoinsLev2}\nCoins";
        }

        if (coinsTextLev3 != null)
        {
            int collected = PlayerPrefs.GetInt("Lev3_Coins", 0);
            coinsTextLev3.text = $"{collected}/{totalCoinsLev3}\nCoins";
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Lev1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Lev2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Lev3");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}