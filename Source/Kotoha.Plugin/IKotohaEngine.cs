﻿using System;
using System.Diagnostics;

namespace Kotoha.Plugin
{
    public interface IKotohaEngine : IDisposable
    {
        /// <summary>
        ///     Find main executable file
        /// </summary>
        string FindMainExecutable();

        /// <summary>
        ///     Find process from currently launched processes.
        /// </summary>
        Process FindCurrentProcess();

        /// <summary>
        ///     This method called only once at the first use (call Speech or SaveAs method from Player).
        /// </summary>
        void Initialize(IntPtr hWnd);

        /// <summary>
        ///     Speech specified text by name
        /// </summary>
        /// <param name="text"></param>
        /// <param name="talker"></param>
        void Speech(string text, IKotohaTalker talker);

        /// <summary>
        ///     Save voice that speech text by name as path.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="talker"></param>
        /// <param name="path"></param>
        void SaveAs(string text, IKotohaTalker talker, string path);
    }
}