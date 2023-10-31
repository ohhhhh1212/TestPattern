using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextItem : MonoBehaviour
{
    public Image m_img = null;
    public int idx = 0;

    public delegate void DelegateFunc(TextItem item, bool select);
    public DelegateFunc OnSelectedFunc = null;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        GetComponent<Button>().onClick.AddListener(OnSelected);
    }

    void OnSelected()
    {
        if (OnSelectedFunc != null)
            OnSelectedFunc(this, true);
    }

    public void OnAddListner(DelegateFunc func)
    {
        OnSelectedFunc = new DelegateFunc(func);
    }

}
