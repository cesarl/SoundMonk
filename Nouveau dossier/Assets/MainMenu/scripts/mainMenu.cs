/// <summary>
/// Main menu.
/// Attached to Main Camera
///  by SGALVAN
/// </summary>

using UnityEngine;
using System.Collections;


public class mainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture buttStart;
	public Texture buttLeader;

	public GUIStyle style;

	public AudioClip son;
	//public AudioClip son2;

	public float buttStartX;
	public float buttStartY;
	public float buttLeaderX;
	public float buttLeaderY;
	public float guiPlacementX1;
	public float guiPlacementX2;
	public float guiPlacementY1;



	void OnGUI(){
				//Display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);



//
		buttStartX = Screen.width * .2f;
		buttLeaderX = Screen.width * .2f;
		buttStartY = buttStartX / 4.5f;
		buttLeaderY = buttLeaderX / 4.5f;

		//Display buttons
		if (GUI.Button (new Rect (Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, buttStartX, 
		                          buttStartY), buttStart, "")) {
			audio.clip = son;
			audio.PlayOneShot(son);
			System.Threading.Thread.Sleep((int)(son.length * 1000));
			Application.LoadLevel (2); 
			print ("Play Game");

		}
		if (GUI.Button (new Rect (Screen.width * guiPlacementX2, Screen.height * guiPlacementY1, buttLeaderX, 
		                          buttLeaderY), buttLeader, "")) {
			audio.clip = son;
			audio.PlayOneShot(son);

//			HiScores escor = new HiScores();
//			for(int i=0;i<10;i++){
//				escor.AddScore("Player " + i, i+20); //			 Line to add a new score
//
//			}
			print ("LEADERBOARD");
			//if (!audio.isPlaying)
			System.Threading.Thread.Sleep((int)(son.length * 1000));
			Application.LoadLevel("Leaderboard");
		}


	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// New class

