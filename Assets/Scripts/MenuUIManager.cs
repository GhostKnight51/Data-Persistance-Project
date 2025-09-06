using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    [SerializeField] private TMP_InputField myInputField;

    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = BestScoreManager.Instance.GetBestScoreAndUser();

        myInputField.onEndEdit.AddListener(BestScoreManager.Instance.GetName);
    }

    // Update is called once per frame
    void Update()
    {
        playerName = BestScoreManager.Instance.playerName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
         Application.Quit();
#endif
    }
}
