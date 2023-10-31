using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score
{
    public int m_Score = 0;
    public static int m_TotScore = 0;

    public Score(int score)
    {
        m_Score = score;
        m_TotScore += m_Score;
    }
}

public class TestStaticDlg : MonoBehaviour
{
    [SerializeField] Text m_txtResult = null;
    [SerializeField] Button m_btnStart = null;
    [SerializeField] Button m_btnClear = null;


    void Start()
    {
        Init();
    }

    void Init()
    {
        m_btnStart.onClick.AddListener(OnClicked_Start);
        m_btnClear.onClick.AddListener(OnClicked_Clear);
    }

    void OnClicked_Start()
    {
        Score kim = new Score(90);
        string str = $"Score = {kim.m_Score}, Total = {Score.m_TotScore}\n";

        Score park = new Score(80);
        str += $"Score = {park.m_Score}, Total = {Score.m_TotScore}\n";

        Score moon = new Score(95);
        str += $"Score = {moon.m_Score}, Total = {Score.m_TotScore}\n";

        m_txtResult.text = str;
    }

    void OnClicked_Clear()
    {
        m_txtResult.text = "√ ±‚»≠";
        Score.m_TotScore = 0;
    }
}
