using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static BestScoreManager Instance;

    public string playerName;
    public string playerNameBestScore;

    public int bestScore = 0;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadBestScore();
    }

    public void GetName(string name)
    {
        playerName = name;
    }

    public void CheckScore(int score)
    {
        if (score > bestScore) 
        {
            bestScore = score;
            SaveBestScore();
            playerNameBestScore = playerName;
        }

    }

    public string GetBestScoreAndUser()
    {
        return $"Best Score: {playerNameBestScore}: {bestScore}";
    }

    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public int highestScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();

        data.playerName = playerNameBestScore;
        data.highestScore = bestScore;

        string json =JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameBestScore = data.playerName;
            bestScore = data.highestScore;
        }
    }
}
