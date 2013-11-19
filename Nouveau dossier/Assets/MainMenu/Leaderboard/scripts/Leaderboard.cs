using UnityEngine;
using System.Collections;

public class Leaderboard : MonoBehaviour {

	public Texture backgroundTexture;

	public GUIStyle style;
	public GUIStyle styleTitle;

	public int plyNum = 10;  // Number of players shown on the leaderboard

	void OnGUI(){

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		GUI.Label(new Rect(Screen.width * .3f, 20, Screen.width *.4f, 50),"Leaderboard", styleTitle);

		HiScores escor = new HiScores();
		string [,] array1 = new string[plyNum,2];
		array1 = escor.GetHighScores(plyNum);
		for(int i=0;i<plyNum;i++){
			GUI.Label(new Rect(Screen.width * .25f, 100 + i*50, 100, 100),array1[i,0], style);
			GUI.Label(new Rect(Screen.width * .65f, 100 + i*50, 100, 100),array1[i,1], style);
			//print (array1[i,1]);
		}

		if (GUI.Button (new Rect (Screen.width * .9f, Screen.height * .8f, 100, 100), "Back", style)) 
			Application.LoadLevel("mainMenu");


	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
