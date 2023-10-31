using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSMTest : MonoBehaviour
{
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] Button m_btnAttack = null;
    [SerializeField] Text m_txtHP = null;
    [SerializeField] Text m_txtTime = null;
    [SerializeField] Text m_txtState = null;

    int monsterHp = 100;
    int time = 20;
    bool isTiming = false;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
        m_btnAttack.onClick.AddListener(OnClicked_Attack);
    }

    void OnClicked_Start()
    {
        StartCoroutine(Co_Start());
    }

    IEnumerator Co_Start()
    {
        m_txtState.text = "Ready";
        yield return new WaitForSeconds(1f);

        m_txtState.text = "Start";
        isTiming = true;
        StartCoroutine(Co_Timer());
    }

    IEnumerator Co_Timer()
    {
        while(isTiming)
        {
            m_txtTime.text = $"Time : {time}";
            yield return new WaitForSeconds(1f);
            time -= 1;

            if(time <= 0)
            {
                m_txtTime.text = "Time : 0";
                ResultState(false);
                break;
            }
        }
    }

    void OnClicked_Attack()
    {
        monsterHp -= 10;

        if (monsterHp <= 0)
        {
            ResultState(true);
            m_txtHP.text = "MonsterHP = 0";
            return;
        }

        m_txtHP.text = $"MonsterHP = {monsterHp}";
    }

    void ResultState(bool isWin)
    {
        if(isWin)
            m_txtState.text = "Result(½Â¸®)";
        else
            m_txtState.text = "Result(ÆÐ¹è)";

        isTiming = false;
    }

    void OnClicked_Clear()
    {
        time = 20;
        monsterHp = 100;
        m_txtHP.text = "MonsterHP = 100";
        m_txtTime.text = "Time : 20";
        isTiming = false;
    }
}
