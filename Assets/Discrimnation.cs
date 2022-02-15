using System.Diagnostics;
using ScriptableObjectArchitecture;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Discrimnation : MonoBehaviour //OfflineDetection
{
    private Stopwatch _stopwatch;
    [SerializeField] private GameEvent _discriminationDone;
    [SerializeField] private Response _response;
    
    private void Awake()
    {
        _stopwatch = new Stopwatch();
    }
    
    public void MelodyThere(bool there)
    {
        _response.experimentStage = Stage.offline; 
        if (there) _response.response = ResponseValue.yes;
        else _response.response = ResponseValue.no;
        _stopwatch.Stop();
        Debug.Log( "Time to answer discrimination rating :" + _stopwatch.ElapsedMilliseconds);
        _response.responseTime = (int) _stopwatch.ElapsedMilliseconds;
        _discriminationDone.Raise();
        _stopwatch.Reset();
    }

    public void Show()
    {
        GetComponent<PanelDimmer>().Show();
        _stopwatch.Start();
    }
}
