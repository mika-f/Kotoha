﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kotoha.Plugin;

namespace Kotoha
{
    public class KotohaPlayer : IDisposable
    {
        private readonly PluginHost _pluginHost;

        public KotohaPlayer()
        {
            _pluginHost = new PluginHost();
        }

        public void Dispose()
        {
            _pluginHost?.Dispose();
        }

        public void LoadPlugins(string directory, bool recursive = false)
        {
            _pluginHost.LoadAssemblies(directory, recursive);
        }

        public void LoadConfigs(string path)
        {
            _pluginHost.LoadJsonConfig(path);
        }

        public void LoadClasses(IEnumerable<IKotohaTalker> talkers)
        {
            _pluginHost.LoadClasses(talkers);
        }

        public void Initialize()
        {
            _pluginHost.Initialize();
        }

        public async Task SpeechAsync(string text, string name)
        {
            var engine = _pluginHost.GetTalkEngine(name);
            await engine.SpeechAsync(text, _pluginHost.KotohaTalkers.SingleOrDefault(w => w.Name == name));
        }

        public async Task SaveAsAsync(string text, string name, string path)
        {
            var engine = _pluginHost.GetTalkEngine(name);
            await engine.SaveAsAsync(text, _pluginHost.KotohaTalkers.SingleOrDefault(w => w.Name == name), path);
        }
    }
}