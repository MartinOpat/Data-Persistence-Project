using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public static MainMenuManager Instance;
    
    public string bestPlayerName;
    public string currentPlayerName;
    public int bestScore;
    
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData {
        public int bestScore;
        public string bestScoreName;
    }

    public void SaveScore() {
        SaveData data = new SaveData();

        data.bestScore = bestScore;
        data.bestScoreName = bestPlayerName;

        string json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestPlayerName = data.bestScoreName;
        }
    }
}
