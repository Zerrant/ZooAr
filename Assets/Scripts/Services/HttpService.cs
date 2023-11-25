using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class HttpService {
    public static string IpAddress => _ipAddress;
    public static string JwtToken => _jwtToken;

    private static string _ipAddress = "https://90b2-188-233-108-141.ngrok-free.app";
    private static string _jwtToken;

    public static IEnumerator Login(LoginContract loginContract, Action callback = null) {
        using var webRequest = MakeRawPostRequest($"{_ipAddress}/api/sso/login", loginContract);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success) {
            Debug.Log(webRequest.result.ToString());
            yield break;
        }

        _jwtToken = webRequest.downloadHandler.text;
        callback?.Invoke();
    }

    public static IEnumerator Register(RegisterContract registerContract, Action callback = null) {
        using var webRequest = MakeRawPostRequest($"{_ipAddress}/api/sso/register", registerContract);
        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success) {
            Debug.Log(webRequest.result.ToString());
            yield break;
        }

        _jwtToken = webRequest.downloadHandler.text;
        callback?.Invoke();
    }

    public static IEnumerator GetAssetBundle(long id, Action<AssetBundle> callback = null) {
        using var webRequest = UnityWebRequestAssetBundle.GetAssetBundle($"{_ipAddress}/api/animals/{id}/model", 0);
        webRequest.SetRequestHeader("Authorization", $"Bearer {_jwtToken}");

        yield return webRequest.SendWebRequest();
        var bundle = DownloadHandlerAssetBundle.GetContent(webRequest);

        callback?.Invoke(bundle);
    }

    public static IEnumerator GetPreview(long id, Action<Texture2D> callback = null) {
        using var webRequest = UnityWebRequestTexture.GetTexture($"{_ipAddress}/api/animals/{id}/preview");
        webRequest.SetRequestHeader("Authorization", $"Bearer {_jwtToken}");

        yield return webRequest.SendWebRequest();
        var texture = DownloadHandlerTexture.GetContent(webRequest);

        callback?.Invoke(texture);
    }

    public static IEnumerator GetAnimalPage(Action<PageResult<Animal>> callback) {
        using var webRequest = new UnityWebRequest($"{_ipAddress}/api/animals/page?Page=0&Limit=25")
        {
            method = UnityWebRequest.kHttpVerbGET,
            downloadHandler = new DownloadHandlerBuffer()
        };

        webRequest.SetRequestHeader("Accept", "text/plain");
        webRequest.SetRequestHeader("Authorization", $"Bearer {_jwtToken}");

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success) {
            Debug.Log(webRequest.result.ToString());
            Debug.Log(webRequest.downloadHandler.text);
            yield break;
        }

        var data = JsonUtility.FromJson<PageResult<Animal>>(webRequest.downloadHandler.text);
        callback?.Invoke(data);
    }

    public static IEnumerator ActivateCard(string code, Action<long> callback) {
        using var webRequest = new UnityWebRequest($"{_ipAddress}/api/cardcodes/activate?code={code}")
        {
            method = UnityWebRequest.kHttpVerbPOST,
            downloadHandler = new DownloadHandlerBuffer()
        };

        webRequest.SetRequestHeader("Accept", "*/*");
        webRequest.SetRequestHeader("Authorization", $"Bearer {_jwtToken}");

        yield return webRequest.SendWebRequest();

        callback?.Invoke(webRequest.responseCode);
    }

    public static UnityWebRequest MakeRawPostRequest(string url, object content) {
        var jsonData = JsonUtility.ToJson(content);
        var webRequest = new UnityWebRequest(url)
        {
            method = UnityWebRequest.kHttpVerbPOST,
            downloadHandler = new DownloadHandlerBuffer(),
            uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData))
        };

        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Accept", "text/plain");

        return webRequest;
    }
}
