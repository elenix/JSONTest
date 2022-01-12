using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class PostMethodTest : MonoBehaviour
{
    public TMP_InputField url;
    public TMP_InputField outputArea;
    public Button PostButton;
    TestData testData;
    TestData.Country country;

    //textfield
    public TMP_InputField id;
    public TMP_InputField nameText;
    public TMP_InputField status;
    public TMP_InputField la;
    public TMP_InputField lo;

    private void Start()
    {
        PostButton.onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());

    public void ParseData()
    {
        testData = new TestData();

        testData.id = int.Parse(id.text);
        testData.name = nameText.text;
        testData.status = status.text;

        country = new TestData.Country();

        country.lat = double.Parse(la.text);
        country.@long = double.Parse(lo.text);
    }

    IEnumerator PostData_Coroutine()
    {
        outputArea.text = "Loading.....";
        string _url = "http://localhost/test/test.json";
        WWWForm form = new WWWForm();

        //ParseData();
        form.AddField("id", 1);
        form.AddField("name", "El");
        form.AddField("status", "married");
        form.AddField("countryInfo", 567);
        form.AddField("countryInfo", 346);

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
