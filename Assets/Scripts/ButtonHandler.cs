using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void LoadUIDesignScene()
    {
        SceneManager.LoadScene("UiDesign");
    }
}