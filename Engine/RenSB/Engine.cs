using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace RenSB
{
    //Структура спрайта, чисто для удобства
    public struct SpriteData
    {
        public Sprite Sprite;
        public Vector2 Coord;
        public string Name;

        public SpriteData(Sprite SpritePath, Vector2 xy, string SpriteName)
        {
            Sprite = SpritePath;
            Coord = xy;
            Name = SpriteName;
        }
    }

    //Здесь будут выставляться настройки для определенного проекта, например его расположение
    public class Preferences
    {
        public static string ProjectPath;
    }

    //Основной класс
    public class Engine : MonoBehaviour
    {
        //Основной GameObject для спрайтов
        public static GameObject Main = new GameObject("RenSB");
        public static void Init()
        {
            Canvas Canvas = Main.AddComponent<Canvas>();
            Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Debug.Log(Screen.width + " " + Screen.height);
        }

        public class Dialog
        {
            //Создаем "динамические" массивы объектов и имейджов (Никита, запили структуру)
            /* UPD. Нахер это дерьмо
            static Image[] ImagesArr = new Image[0];
            static GameObject[] ObjArr = new GameObject[0];
             */

            static List<GameObject> ObjList = new List<GameObject>();
            static List<Image> ImagesList = new List<Image>();

            //WIP
            public static void Init(string DialogData, params SpriteData[] spritesData)
            {
            GameObject SpritesObj = new GameObject("Sprites");
            SpritesObj.transform.SetParent(Main.transform);
            SpritesObj.AddComponent<RectTransform>();
            SpritesObj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            SpritesObj.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);

                for (int c = 0; c < spritesData.Length; c++)
                {
                    try
                    {
                        Debug.Log(spritesData[c].Sprite + " " + spritesData[c].Coord + " " + spritesData[c].Name);
                        int W = spritesData[c].Sprite.texture.width;
                        int H = spritesData[c].Sprite.texture.height;
                        int Index = ObjList.Count;
                        ObjList.Add(new GameObject());
                        ObjList[Index].transform.SetParent(SpritesObj.transform);

                        ObjList[Index].AddComponent<RectTransform>();
                        ObjList[Index].GetComponent<RectTransform>().localPosition = new Vector3(spritesData[c].Coord.x, spritesData[c].Coord.y, 0);
                        ObjList[Index].GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
                        ObjList[Index].name = spritesData[c].Name;

                        ImagesList.Add(ObjList[Index].AddComponent<Image>());
                        ImagesList[Index].name = spritesData[c].Name + "Sprite";
                        ImagesList[Index].sprite = spritesData[c].Sprite;
                    }
                    catch (Exception ex)
                    {
                        //Типичный ACHTUNG
                        Debug.Log("ACHTUNG! " + ex);
                    }
                }
            }

            public static void End()
            {
                for (int x = 0; x < ObjList.Count; x++)
                {
                    GameObject.Destroy(ObjList[x]);
                    Image.Destroy(ImagesList[x]);
                }

                ObjList.Clear();
                ImagesList.Clear();
            }
        }

        public class Sprites
        {
            public static void Add(params SpriteData[] Sprite)
            {

            }

            public static void Remove(params string[] spriteName)
            {

            }
        }
    }
}
