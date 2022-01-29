        using System.Collections;
        using System.Collections.Generic;
        using ScriptableObjectArchitecture;
        using UnityEngine;

        public class BookUI : MonoBehaviour
        {
            private readonly List<Transform> pictures = new List<Transform>();
            private int currentPage = 0;

            [SerializeField]
            private int maxImagePerPages = 4;
            [SerializeField]
            private  int numberOfPages = 2;
            [SerializeField] 
            private Picture imagePrefab;
            [SerializeField] 
            private GameObject basicImagePrefab;
            [SerializeField]
            private Texture2DCollection images;
            [SerializeField]
            private List<Transform> pages = new List<Transform>();
            public void GetImages()
            {
                Picture picture;
                Transform currentPage;
                for (int i = 0; i < numberOfPages; i++)
                {
                    currentPage = pages[i];
                    for (int y = 0; y < maxImagePerPages; y++)
                    {
                        if (images.Count > y + maxImagePerPages*(i))
                        {
                            picture = Instantiate(imagePrefab, currentPage);
                            pictures.Add(picture.transform);
                            picture.SetPicture(images[y + maxImagePerPages*(i)]);
                        }
                        else
                        {
                            pictures.Add(Instantiate(basicImagePrefab, currentPage).transform);
                        }
                    }
                }
            }

            public void RemovePictures()
            {
                for (int i = pictures.Count - 1; i >= 0; i--)
                {
                    Destroy(pictures[i].gameObject);
                    pictures.RemoveAt(i);
                }
            }
        }