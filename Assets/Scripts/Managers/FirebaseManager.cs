using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using ScriptableObjectArchitecture;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
  private string playerName;
  [SerializeField] private GameEvent _responseLogged;
  [SerializeField] private ExperimentStage _experimentStage;
  private int responseIndex;
  private List<Response> _responses;
  
  private void Start()
  {
    playerName = Guid.NewGuid().ToString();
    _responses = new List<Response>();
  }

  public void SubmitToDatabase(Response response)
  {
    if (!_experimentStage.practiceRound)
    {
      _responses.Add(response);
      RestClient.Put("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/" 
                     + playerName + "/" 
                     + _experimentStage.stage + "/"
                     + "/responses/" 
                     + responseIndex 
                     + ".json", response);
      responseIndex++;  
    }
    _responseLogged.Raise();
  }

  public void RetrieveFromDatabase()
  {
    RestClient.Get<ResponseData>("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/" + playerName + ".json").Then(response =>
    {
      ResponseData user = response;
    });
  }
  
}
