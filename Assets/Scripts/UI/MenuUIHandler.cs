using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Simple methods for buttons
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToOptions()
    {
        SceneManager.LoadScene(2);
    }

    public void ToScores()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetName()
    {
        MainDataManager.Instance.currentPlayerName = inputField.text;
    }
}
