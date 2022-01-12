using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class PostMethodCovid : MonoBehaviour
{
    public TMP_InputField url;
    public TMP_InputField outputArea;
    public Button PostButton;
    CovidData covidData;

    //textfield
    public TMP_InputField updated;
    public TMP_InputField country;

    private void Start()
    {
        PostButton.onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        CovidData covidData = new CovidData();

        //covidData.updated = long.Parse(updated.text);
        covidData.country = country.text;


        outputArea.text = "Loading.....";
        string _url = url.text;
        WWWForm form = new WWWForm();

        //form.AddField("updated", covidData.updated.ToString());
        form.AddField("title", country.text.ToString());

        using (UnityWebRequest request = UnityWebRequest.Post(_url, form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ProtocolError)
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
