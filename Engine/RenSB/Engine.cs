using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace RenSB
{
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

    public class Preferences
    {
        public static string ProjectPath;
    }
    public class Engine : MonoBehaviour
    {
        public static GameObject SpritesObj = new GameObject("Sprites");

        public static void Init()
        {
            GameObject Main = new GameObject("RenSB");
            Canvas Canvas = Main.AddComponent<Canvas>();
            Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            SpritesObj.transform.SetParent(Canvas.transform);
            SpritesObj.AddComponent<RectTransform>();
            SpritesObj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            SpritesObj.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
            Debug.Log(Screen.width + " " + Screen.height);
        }

        public class Sprites
        {
            static Image[] ImagesArr = new Image[0];
            static GameObject[] ObjArr = new GameObject[0];

            public static void InitDialog(string DialogData, params SpriteData[] spritesData)
            {
                for (int c = 0; c < spritesData.Length; c++)
                {
                    try
                    {
                        Debug.Log(spritesData[c].Sprite + " " + spritesData[c].Coord + " " + spritesData[c].Name);
                        int W = spritesData[c].Sprite.texture.width;
                        int H = spritesData[c].Sprite.texture.height;
                        int Index = ImagesArr.Length;
                        Array.Resize(ref ImagesArr, ImagesArr.Length + 1); Array.Resize(ref ObjArr, ObjArr.Length + 1);

                        ObjArr[Index] = new GameObject();
                        ObjArr[Index].transform.SetParent(SpritesObj.transform);

                        ObjArr[Index].AddComponent<RectTransform>();
                        ObjArr[Index].GetComponent<RectTransform>().localPosition = new Vector3(spritesData[c].Coord.x, spritesData[c].Coord.y, 0);
                        ObjArr[Index].GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
                        ObjArr[Index].name = spritesData[c].Name;

                        ImagesArr[Index] = ObjArr[Index].AddComponent<Image>();
                        ImagesArr[Index].name = spritesData[c].Name + "Sprite";
                        ImagesArr[Index].sprite = spritesData[c].Sprite;
                    }
                    catch (Exception ex)
                    {
                        Debug.Log("ACHTUNG! " + ex);
                    }
                }
            }
        }

        public static void BG(string Image, Image BG)
        {

        }
    }
}
