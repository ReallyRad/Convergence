using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using ScriptableObjectArchitecture;
using UnityEngine;
using System.Linq;
public class FirebaseManager : MonoBehaviour
{
  private string playerName;
  [SerializeField] private GameEvent _responseLogged;
  [SerializeField] private ExperimentStage _experimentStage;
  [SerializeField] private StatisticsGameEvent _statisticsAvailable;
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
                     + playerName
                     //+ _experimentStage.stage + "/"
                     + "/responses/" 
                     + responseIndex 
                     + ".json", response);
      responseIndex++;  
    }
    _responseLogged.Raise();
  }

  public void RetrieveFromDatabase()
  {
    //count the number of tp, fp, tn, fn, mean reaction tiems, mean confidence ratings 

    RestClient.Get("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/" + playerName + "/responses.json").Then(response =>
    {
      Statistics statistics = new Statistics();
      int i = 0;
      foreach (ResponseData responseData in JsonHelper.ArrayFromJson<ResponseData>(response.Text))
      {
        switch (responseData.responseType)
        {
          case ResponseType.falseNegative:
            statistics.falseNegativeCount++;
            break;
          case ResponseType.falsePositive:
            statistics.falsePositiveCount++;
            break;
          case ResponseType.trueNegative:
            statistics.trueNegativeCount++;
            break;
          case ResponseType.truePositive:
            statistics.truePositiveCount++;
            break;
        }

        statistics.meanReactionTime += responseData.responseTime;
        statistics.meanConfidenceRating += responseData.confidence;

        i++;
      }

      statistics.meanReactionTime =  statistics.meanReactionTime  / i;
      statistics.meanConfidenceRating = statistics.meanConfidenceRating / i;
      
      _statisticsAvailable.Raise(statistics);
    });
    
  }
  
}
