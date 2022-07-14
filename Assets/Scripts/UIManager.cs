using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    
    public GameObject inputField;
    
    public void StartGame() {
        SceneManager.LoadScene(1);

        if (MainMenuManager.Instance != null) {
            MainMenuManager.Instance.currentPlayerName = inputField.GetComponent<TMP_InputField>().text;
        }
    }
}
