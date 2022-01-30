using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => _instance;
    private static UIManager _instance;
    private BookUI _book;
    private Chatbox chat;
    [SerializeField]
    private BookUI bookPrefab;
    [SerializeField]
    private Chatbox chatPrefab;

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
        _book = null;
    }

    public void SendText(string text)
    {
        if (chat == null)
        {
            chat = Instantiate(chatPrefab);
        }
        chat.SetText(text);
    }

    public void RemoveText()
    {
        Destroy(chat.gameObject);
        chat = null;
    }
    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
