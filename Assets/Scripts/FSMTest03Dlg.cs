using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSMTest03Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtKey = null;
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Text m_txtState = null;
    [SerializeField] Text m_txtScore = null;
    [SerializeField] Text m_txtTime = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnStop = null;
    public BattleFSM m_BattleFSM = new BattleFSM();

    int score = 0;
    float time = 0;
    int randomKey = -1;
    int stack = 0;

    bool isFail = false;

    private void Update()
    {
        m_BattleFSM.OnUpdate();

        if (!m_BattleFSM.IsGameState())
            return;

        time += Time.deltaTime;
        m_txtTime.text = string.Format("Time : {0:0.0}", time);

        if (time >= 20.0f)
        {
            m_txtTime.text = "Time : 0";
            m_BattleFSM.SetResultState();
        }

        CheckRandomKey();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_BattleFSM.Init(OnCallback_Ready, OnCallback_Wave, OnCallback_Game, OnCallback_Result);
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnStop.onClick.AddListener(OnClicked_Stop);
    }

    void OnClicked_Start()
    {
        m_BattleFSM.SetReadyState();
        Invoke("Invoke_Start", 1.0f);
    }

    void Invoke_Start()
    {
        m_BattleFSM.SetGameState();
    }

    void OnClicked_Stop()
    {
        m_BattleFSM.SetNoneState();
        Clear();
    }

    void OnCallback_Ready()
    {
        Clear();
        m_txtState.text = "Ready";
    }
    void OnCallback_Wave()
    {
        m_txtState.text = "Wave";
        StartCoroutine(Co_WaveState());
    }
    void OnCallback_Game()
    {
        m_txtState.text = "Game";
        SetKey();
    }
    void OnCallback_Result()
    {
        if (isFail)
        {
            m_txtState.text = "Result(실패)";
            return;
        }

        if (score < 30)
            m_txtState.text = "Result(실패)";
        else
            m_txtState.text = "Result(성공)";
    }

    void Clear()
    {
        m_txtKey.text = "Key : 0";
        m_txtResult.text = "Result";
        m_txtState.text = "State";
        m_txtScore.text = "Score : 0";
        m_txtTime.text = "Time : 0";
        score = 0;
        time = 0;
        stack = 0;
        randomKey = -1;
        isFail = false;
    }

    IEnumerator Co_WaveState()
    {
        yield return new WaitForSeconds(0.8f);
        SetKey();
        m_BattleFSM.SetGameState();
    }

    void CheckRandomKey()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                if(randomKey == i)
                {
                    score += 10;
                    m_txtScore.text = $"Score : {score}";
                    m_txtResult.text = "정답";
                }
                else
                {
                    m_txtResult.text = "오답";
                    stack += 1;

                    if(stack >= 3)
                    {
                        m_BattleFSM.SetResultState();
                        isFail = true;
                        break;
                    }
                }

                m_BattleFSM.SetWaveState();
            }
        }
    }

    void SetKey()
    {
        randomKey = Random.Range(0, 10);
        m_txtKey.text = $"Key : {randomKey}";
    }

}
