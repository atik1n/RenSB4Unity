using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RenSB;

public class CStest : MonoBehaviour {

	void Start () {
        RenSB.Preferences.ProjectPath = "C:/Users/Никита/Dropbox/Приложения/smart BASIC/Katawa port/Katawa/Katawa Shoujo/";
        RenSB.Engine.Init();
        RenSB.Engine.Sprites.InitDialog("hi", new SpriteData(Resources.Load<Sprite>("Sprites/misha"), new Vector2(200, 0), "misha"));
	}
	
	void Update () {
	
	}
}
