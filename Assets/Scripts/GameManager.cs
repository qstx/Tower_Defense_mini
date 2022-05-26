using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using MyTowerDefense;

public class GameManager : MonoBehaviour
{
    static public GameManager singleton;
    [SerializeField]
    private WaveManager waveManager;
    [SerializeField]
    private GameObject StartPanel;
    [SerializeField]
    private GameObject PausePanel;
    [SerializeField]
    private GameObject OverPanel;
    [SerializeField]
    private TMPro.TextMeshProUGUI moneyText;
    private int money = 100;
    [SerializeField]
    public int Money { set { money = value; UpdateMoneyShow(); } get { return money; } }
    private void Awake()
    {
        if (!singleton)
            singleton = this;
        else
            Debug.LogError("GameManager singleton");
        StartPanel.SetActive(true);
        PausePanel.SetActive(false);
        OverPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoneyShow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StartPanel.activeSelf == false && PausePanel.activeSelf == false && OverPanel.activeSelf == false)
            {
                Pause();
            }
        }
        if (WaveManager.singleton.isOver)
        {
            OverPanel.SetActive(true);
        }
    }
    private void UpdateMoneyShow()
    {
        moneyText.text = "$"+Money.ToString();
    }
    private void Pause()
    {
        Time.timeScale = 0;
        StartPanel.SetActive(false);
        PausePanel.SetActive(true);
        OverPanel.SetActive(false);
    }
    public void OnStartBtnClicked()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
        PausePanel.SetActive(false);
        OverPanel.SetActive(false);
    }
    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnResumeBtnClicked()
    {
        Time.timeScale = 1;
        StartPanel.SetActive(false);
        PausePanel.SetActive(false);
        OverPanel.SetActive(false);
    }
    public void OnExitBtnClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
