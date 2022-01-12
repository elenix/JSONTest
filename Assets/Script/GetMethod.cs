using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class GetMethod : MonoBehaviour
{
    public TMP_InputField url;
    public TMP_InputField outputArea;
    public Button GetButton;
    public Button PostButton;

    private void Start()
    {
        GetButton.onClick.AddListener(GetData);
    }

    void GetData() => StartCoroutine(GetData_Coroutine());

    IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading.....";
        string _url = url.text;
        using (UnityWebRequest request = UnityWebRequest.Get(_url))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ProtocolError)
            {
                outputArea.text = request.error;
            }
            else
            {
                outputArea.text = request.downloadHandler.text;
            }
        }
    }
}
