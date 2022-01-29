using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    [SerializeField]
    private Image image;

    public void SetPicture(Texture2D texture)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        image.sprite = sprite;
    }
}
