using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegateTest02Dlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnClear = null;
    [SerializeField] TextItem[] m_textItems = null;

    string[] m_city = { "����", "����", "�λ�" };

    TextItem m_curItem = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < m_textItems.Length; i++)
        {
            m_textItems[i].OnAddListner(CallBack_Select);
            m_textItems[i].idx = i;
        }

        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void CallBack_Select(TextItem item, bool select)
    {
        ClearColor();
        m_curItem = item;

        m_curItem.m_img.color = Color.green;

        m_txtResult.text = $"{m_city[m_curItem.idx]}";
    }

    void OnClicked_Start()
    {
        if (m_curItem == null)
        {
            m_txtResult.text = "���ø� �������ּ���.";
            return;
        }

        string str = $"����� ������ ���ô� {m_city[m_curItem.idx]}�Դϴ�.";
        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        ClearColor();
        m_curItem = null;
        m_txtResult.text = "�ʱ�ȭ";
    }

    void ClearColor()
    {
        if (m_curItem != null)
            m_curItem.m_img.color = Color.white;
    }

}
