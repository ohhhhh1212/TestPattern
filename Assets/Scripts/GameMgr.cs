using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr1
{
    static GameMgr1 _inst = null;
    public static GameMgr1 Inst()
    {
        if (_inst == null)
            _inst = new GameMgr1();

        return _inst;
    }

    public int m_Score = 100;
}

//public class Test000
//{
//    public void Init()
//    {
//        GameMgr.Inst().m_Score = 200;
//        Debug.Log(GameMgr.Inst().m_Score);
//    }
//}

public class GameMgr
{
    static GameMgr _inst = null;
    public static GameMgr Inst
    {
        get
        {
            if (_inst == null)
                _inst = new GameMgr();

            return _inst;
        }
    }

    private GameMgr() { }

    public int m_Score = 100;
}

public class GameMgr2 : MonoBehaviour
{
    static GameMgr2 _inst = null;
    public static GameMgr2 Inst
    {
        get
        {
            if(_inst == null)
            {
                GameObject go = new GameObject("Singleton GameMgr");
                _inst =  go.AddComponent<GameMgr2>();
                DontDestroyOnLoad(go);
            }

            return _inst;
        }
    }
}

