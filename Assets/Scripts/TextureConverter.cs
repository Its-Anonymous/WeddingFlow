using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureConverter : MonoBehaviour
{
    public static string Texture2DToBase64(Texture2D texture)
    {
            Debug.Log("Texture2DToBase64");
        byte[] imageData = null;
        if (texture == null)
        {
            texture = ScreenManager.instance.apiControllerRef.Player_DummyAvatar;
        }
       // Debug.Log(imageData.Length + "imageData.Length");
        if (texture.isReadable)
        {
            imageData = texture.EncodeToJPG();
        }

        //Debug.LogError("Convert.ToBase64String(imageData).Length: " +Convert.ToBase64String(imageData));
        return Convert.ToBase64String(imageData);
    }

    public static byte[] Texture2DToByte(Texture2D texture)
    {
        byte[] imageData = null;
        if (texture == null) texture = ScreenManager.instance.apiControllerRef.Player_DummyAvatar;
        //Debug.Log(imageData.Length + "imageData.Length");
        if (texture.isReadable)
        {
            imageData = texture.EncodeToJPG();
        }
        //Debug.LogError("Convert.ToBase64String(imageData).Length: " +Convert.ToBase64String(imageData));
        return (imageData);
    }

    public static Texture2D Base64ToTexture2D(string encodedData)
    {
        if (encodedData == null) return ScreenManager.instance.apiControllerRef.Player_DummyAvatar;
        byte[] imageData = Convert.FromBase64String(encodedData);
        Texture2D texture = ScreenManager.instance.apiControllerRef.Player_DummyAvatar;
        int width, height;
        try
        {
            GetImageSize(imageData, out width, out height);

            texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
            texture.hideFlags = HideFlags.HideAndDontSave;
            texture.filterMode = FilterMode.Point;
            texture.LoadImage(imageData);
        }
        catch (Exception ex)
        {
            Debug.Log("Base64ToTexture2D: image could not be converted");
        }
        return texture;
    }

    public static Texture2D ByteToTexture2D(byte[] encodedData)
    {
        byte[] imageData = encodedData;
        Texture2D texture;//= Controller.instance.dummyPlayer;
        int width, height;
        try
        {
            GetImageSize(imageData, out width, out height);

            texture = new Texture2D(width, height, TextureFormat.ARGB32, false, true);
            texture.hideFlags = HideFlags.HideAndDontSave;
            texture.filterMode = FilterMode.Point;
            texture.LoadImage(imageData);
        }
        catch (Exception ex)
        {
            texture = ScreenManager.instance.apiControllerRef.Player_DummyAvatar;
            Debug.Log("Base64ToTexture2D: image could not be converted");
        }
        return texture;
    }

    private static void GetImageSize(byte[] imageData, out int width, out int height)
    {
        width = ReadInt(imageData, 3 + 15);
        height = ReadInt(imageData, 3 + 15 + 2 + 2);
    }
    private static int ReadInt(byte[] imageData, int offset)
    {
        return (imageData[offset] << 8) | imageData[offset + 1];
    }
}