using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit2 : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoad = 0.5f;
    [SerializeField] private AudioClip exitSound; // ← ДОБАВЬ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SaveCurrentLevelCoins();
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        if (exitSound != null)
            AudioSource.PlayClipAtPoint(exitSound, transform.position);

        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("Lev3");
    }

    private void SaveCurrentLevelCoins()
    {
        if (GameManager.Instance != null)
        {
            int currentCoins = GameManager.Instance.GetCollectedCoins();
            int totalCoins = GameManager.Instance.GetTotalCoins();
            int savedCoins = PlayerPrefs.GetInt("Lev2_Coins", 0);

            if (currentCoins > savedCoins)
            {
                PlayerPrefs.SetInt("Lev2_Coins", currentCoins);
                PlayerPrefs.SetInt("Lev2_TotalCoins", totalCoins);
                PlayerPrefs.Save();
            }
        }
    }
}