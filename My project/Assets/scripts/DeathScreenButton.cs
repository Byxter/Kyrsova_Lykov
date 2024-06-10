using UnityEngine;
using UnityEngine.UI;

public class DeathScreenButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on object: " + gameObject.name);
        }
    }

    private void OnButtonClick()
    {
        // ֽאיהול מבתוךע DeathScreenManager ט גûחמגול לועמה Restart
        DeathScreenManager deathScreenManager = FindObjectOfType<DeathScreenManager>();
        if (deathScreenManager != null)
        {
            deathScreenManager.Restart();
        }
        else
        {
            Debug.LogError("DeathScreenManager not found in the scene.");
        }
    }
}
