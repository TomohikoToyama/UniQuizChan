using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ResourceLoad : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    private readonly string url = "http://abehiroshi.la.coocan.jp/abe-top-20190328-2.jpg";
    
    // 1フレーム目に処理する
    async void Start()
    {
        try
        {
            _image.texture = await DownloadTexture(url);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
    
    /// <summary>
    /// URLより画像を取得
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    async UniTask<Texture> DownloadTexture(string uri)
    {
        // 画像のURL
        var r = UnityWebRequestTexture.GetTexture(uri);

        await r.SendWebRequest(); // UnityWebRequestをawaitできる
        return DownloadHandlerTexture.GetContent(r);
    }
   
}
