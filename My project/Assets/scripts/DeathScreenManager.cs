using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    public GameObject deathScreen; // ������ ������ ������

    // ����� ��� ����������� ������ ������
    public void ShowDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }
    }
    public void Restart()
    {
        EnemyCount.delEnem();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
