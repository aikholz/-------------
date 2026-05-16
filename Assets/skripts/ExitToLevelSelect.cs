using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitToLevelSelect : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoad = 0.5f;
    [SerializeField] private AudioClip exitSound; // ← ДОБАВЬ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SaveCurrentLevelCoins();
            Time.timeScale = 1f;
            StartCoroutine(LoadLevelSelect());
        }
    }

    private IEnumerator LoadLevelSelect()
    {
        if (exitSound != null)
            AudioSource.PlayClipAtPoint(exitSound, transform.position);

        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("LevelSelect");
    }

    private void SaveCurrentLevelCoins()
    {
        if (GameManager.Instance != null)
        {
            int currentCoins = GameManager.Instance.GetCollectedCoins();
            int totalCoins = GameManager.Instance.GetTotalCoins();
            int savedCoins = PlayerPrefs.GetInt("Lev3_Coins", 0);

            if (currentCoins > savedCoins)
            {
                PlayerPrefs.SetInt("Lev3_Coins", currentCoins);
                PlayerPrefs.SetInt("Lev3_TotalCoins", totalCoins);
                PlayerPrefs.Save();
            }
        }
    }
}