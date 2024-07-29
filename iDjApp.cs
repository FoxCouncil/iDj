// Copyright (c) 2023 Fox Council - iDj - https://github.com/FoxCouncil/iDj

using CSCore.CoreAudioAPI;
using System.Diagnostics;

namespace iDj;

internal static class iDjApp
{
    /// <summary>The main entry point for the application.</summary>
    [MTAThread]
    static void Main()
    {
        //var realEnum = new MMDeviceEnumerator();
        //var realDevice = realEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

        //var realSessionManager = AudioSessionManager2.FromMMDevice(realDevice);

        //AudioSessionEnumerator realSessionEnumerator = realSessionManager.GetSessionEnumerator();

        //var count = realSessionEnumerator.Count;

        //for (int i = 0; i < count; i++)
        //{
        //    var audioSource = realSessionEnumerator[i];

        //    var audioSource2 = audioSource.QueryInterface<AudioSessionControl2>();

        //    Debug.WriteLine(audioSource2.Process.ProcessName);
        //}

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }

    public static string ToBase64(this Image image, string type)
    {
        using var stream = new MemoryStream();

        image.Save(stream, image.RawFormat);

        var imgBytes = stream.ToArray();

        var base64String = Convert.ToBase64String(imgBytes);

        return $"data:{type};base64,{base64String}";
    }
}