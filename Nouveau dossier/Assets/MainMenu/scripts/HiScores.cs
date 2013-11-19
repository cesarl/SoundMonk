/// <summary>
/// HiScores.
/// By SGALVAN
/// </summary>

using UnityEngine;
using System.Collections;

[System.Serializable]

public class HiScores{ //: MonoBehaviour {
	public HiScores(){
		
	}
	
	/*	public 
	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {

	} 
*/	
	
	public void AddScore(string name, int score){
		int newScore;
		string newName;
		int oldScore;
		string oldName;
		newScore = score;
		newName = name;
		for(int i=0;i<10;i++){
			if(PlayerPrefs.HasKey(i+"HScore")){
				if(PlayerPrefs.GetInt(i+"HScore")<newScore){ 
					// new score is higher than the stored score
					oldScore = PlayerPrefs.GetInt(i+"HScore");
					oldName = PlayerPrefs.GetString(i+"HScoreName");
					PlayerPrefs.SetInt(i+"HScore",newScore);
					PlayerPrefs.SetString(i+"HScoreName",newName);
					newScore = oldScore;
					newName = oldName;
				}
			}else{
				PlayerPrefs.SetInt(i+"HScore",newScore);
				PlayerPrefs.SetString(i+"HScoreName",newName);
				newScore = 0;
				newName = "";
			}
		}
		
		
	}
	public string [,] GetHighScores(int numPly)
	{
		string[,] array = new string[numPly,2];
		for(int i = 0; i < numPly; i++)
		{
			//Debug.Log(PlayerPrefs.GetString(i + "HScoreName") + " has a score of: " +  PlayerPrefs.GetInt(i + "HScore"));
			array[i,0] = PlayerPrefs.GetString(i + "HScoreName");
			array[i,1] = (PlayerPrefs.GetInt(i + "HScore")).ToString();
			
		}
		return array;
	}
}
