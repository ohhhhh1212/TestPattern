using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonTestDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnClear = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start1);
        m_btnClear.onClick.AddListener(OnClicked_Clear1);
    }

    void OnClicked_Start1()
    {
        string str = $"프로퍼티 : {GameMgr.Inst.m_Score}점\n";
        str += $"함수 : {GameMgr1.Inst().m_Score}점";

        m_txtResult.text = str;
    }

    void OnClicked_Clear1()
    {
        m_txtResult.text = "초기화";
    }
}
