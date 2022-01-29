using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => _instance;
    private static UIManager _instance;
    private BookUI _book;
    [SerializeField]
    private BookUI bookPrefab;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public void SetBook()
    {
        if (_book == null)
        {
            OpenBook();
        }
        else
        {
            CloseBook();
        }
    }
    
    public void OpenBook()
    {
        _book = Instantiate(bookPrefab);
        _book.transform.position = Vector3.zero;
        _book.GetImages();
    }

    public void CloseBook()
    {
        _book.RemovePictures();
        Destroy(_book.gameObject);
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
