using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    #region Variables

    public GameObject PanelMain, PanelCredits, PanelOptions;

    //Build ID scene number for load on start
    public int SceneToLoad;
    #endregion

    // Use this for initialization
    void Start()
    {
        SceneToLoad = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick(string button)
    {
        switch (button)
        {
            case "start":
                StartGame();
                break;

            case "options":
                Options();
                break;

            case "credits":
                Credits();
                break;

            case "quit":
                Quit();
                break;
            case "back":
                Back();
                break;

            default:
                break;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    private void Options()
    {
        PanelMain.SetActive(false);
        PanelCredits.SetActive(false);
        PanelOptions.SetActive(true);
    }

    private void Credits()
    {
        PanelMain.SetActive(false);
        PanelCredits.SetActive(true);
        PanelOptions.SetActive(false);
    }

    private void Back()
    {
        PanelMain.SetActive(true);
        PanelCredits.SetActive(false);
        PanelOptions.SetActive(false);
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }

}
