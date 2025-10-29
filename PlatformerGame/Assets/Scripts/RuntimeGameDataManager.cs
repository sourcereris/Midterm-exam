using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// step 1
public class RuntimeGameDataManager : MonoBehaviour
{
    static public RuntimeGameDataManager instance;
    private int _count = 0;
    private int _dataStamp = 0;
    public int _playerLife = 3;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddCount(int c)
    {
        _count += c;
        _dataStamp += 1;
    }

    public int GetCount()
    {
        return _count;
    }

    public int GetDataStamp()
    {
        return _dataStamp;
    }

    public void SetPlayerLife(int c)
    {
        _playerLife = c;
        if (_playerLife < 0)
            _playerLife = 0;
        _dataStamp += 1;
    }

    public int GetPlayerLife()
    {
        return _playerLife;
    }
}
