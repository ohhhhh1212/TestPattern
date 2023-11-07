using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSMTest02Dlg : MonoBehaviour
{
    public BattleFSM m_BattleFSM = new BattleFSM();
    [SerializeField] Text m_txtState = null;
    [SerializeField] Text m_txtHP = null;
    [SerializeField] Text m_txtTime = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnAttack = null;

    int hp = 100;
    int time = 10;

    private void Update()
    {
        m_BattleFSM.OnUpdate();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_BattleFSM.Init(OnCallback_Ready, OnCallback_Wave, OnCallback_Game, OnCallback_Result);
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAttack.onClick.AddListener(OnClicked_Attack);
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

    void OnClicked_Clear()
    {
        Clear();
        m_BattleFSM.SetNoneState();
    }

    void Clear()
    {
        m_txtHP.text = "Monster HP : 100";
        m_txtTime.text = "Time : 10";
        hp = 100;
        time = 10;
        m_txtState.text = "State";
    }

    void OnClicked_Attack()
    {
        if (!m_BattleFSM.IsGameState())
            return;

        hp -= 10;
        if(hp <= 0)
        {
            m_txtHP.text = "Monster HP : 0";
            m_BattleFSM.SetResultState();
            return;
        }

        m_txtHP.text = $"Monster HP : {hp}";
    }

    void OnCallback_Ready()
    {
        m_txtState.text = "Ready";
    }
    void OnCallback_Wave()
    {

    }
    void OnCallback_Game()
    {
        Clear();
        m_txtState.text = "Game";
        StartCoroutine(Co_Timer());
    }
    void OnCallback_Result()
    {
        if (hp <= 0)
            m_txtState.text = "Result(성공)";
        else
            m_txtState.text = "Result(실패)";
    }

    IEnumerator Co_Timer()
    {
        while (m_BattleFSM.IsGameState())
        {
            m_txtTime.text = $"Time : {time}";
            yield return new WaitForSeconds(1f);

            time -= 1;

            if(time <= 0)
            {
                m_txtTime.text = "Time : 0";
                m_BattleFSM.SetResultState();
            }
        }
    }

}
