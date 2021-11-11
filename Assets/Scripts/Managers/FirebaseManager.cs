using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
  public static string playerName;

  public void SubmitToDatabase(Response response)
  {
    Response user = ScriptableObject.CreateInstance<Response>();
    RestClient.Put("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/"+ "Tom" + ".json", user);
  }

  public void RetrieveFromDatabase()
  {
    RestClient.Get<ResponseData>("https://convergence-5c0db-default-rtdb.europe-west1.firebasedatabase.app/" + "Tom" + ".json").Then(response =>
    {
      ResponseData user = response;
    });
  }
  
}
