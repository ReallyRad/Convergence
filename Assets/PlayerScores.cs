﻿using Proyecto26;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScores : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;
    
    private System.Random random = new System.Random(); 

    User user = new User();
    
    public static int playerScore;
    public static string playerName;
    

    // Start is called before the first frame update
    private void Start()
    {
        playerScore = random.Next(0, 101);
        scoreText.text = "Score: " + playerScore;
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDatabase();
    }
    
    public void OnGetScore()
    {
        RetrieveFromDatabase();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + user.userScore;
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Put("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/"+ playerName + ".json", user);
    }

    private void RetrieveFromDatabase()
    {
        RestClient.Get<User>("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/" + nameText.text + ".json").Then(response =>
            {
                user = response;
                UpdateScore();
            });
    }
}
