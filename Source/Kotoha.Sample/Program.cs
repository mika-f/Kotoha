﻿using System;

namespace Kotoha.Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create a instance of Kotoha.
            var player = new KotohaPlayer();

            // Load plugins from specified directory.
            // When you set recursive is true, Kotoha searches plugins recursively into subdirectories.
            // Support plugins are:
            //   1. Engine plugin (e.g. Kotoha.Voiceroid2.dll)
            //     Engine plugin implements IKotohaEngine interface.
            //   2. Talker plugin (e.g. Kotoha.Akane.dll)
            //     Talker plugin implements IKotohaTalker interface.
            //   3. Feature plugin (e.g. Kotoha.Tuning.dll)
            //     Feature plugin implements IKotohaFeature interface.
            player.LoadPlugins($@"{Environment.CurrentDirectory}\plugins", true);

            // Kotoha also supports config (JSON format) file for talker definition.
            // player.LoadTalkers(@"D:\Users\mikazuki\Documents\GitHub\Kotoha\Source\Kotoha\bin\Debug\netstandard2.0\kotoha.json");

            // Initialize. You MUST initialize after loaded plugins.
            // player.Initialize();

            // Play voice.
            player.PlayAsync("こんばんは！", "Akane");

            // Save voice.
            // await player.SaveAsync("こんにちは", "Akane", @"D:\Users\mikazuki\Documents\GitHub\Kotoha\Source\Kotoha\bin\Debug\netstandard2.0\voice.mp3");

            // Finisihed.
            player.Dispose();
        }
    }
}