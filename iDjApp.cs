// Copyright (c) 2023 Fox Council - iDj - https://github.com/FoxCouncil/iDj

using iDj.iTunes;

namespace iDj;

internal static class iDjApp
{
    /// <summary>The main entry point for the application.</summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
}