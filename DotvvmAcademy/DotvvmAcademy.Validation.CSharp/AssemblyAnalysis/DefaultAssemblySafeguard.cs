﻿using System;
using System.Diagnostics;

namespace DotvvmAcademy.Validation.CSharp.AssemblyAnalysis
{
    public class DefaultAssemblySafeguard : IAssemblySafeguard
    {
        private Lazy<Stopwatch> stopwatch = new Lazy<Stopwatch>(() => Stopwatch.StartNew());

        public DefaultAssemblySafeguard(int timeLimit = 1)
        {
            TimeLimit = timeLimit;
        }

        public int TimeLimit { get; }

        public void OnInstruction() => CheckTime();

        private void CheckTime()
        {
            if (stopwatch.Value.ElapsedTicks >= TimeSpan.TicksPerSecond * TimeLimit)
            {
                throw new AssemblySafeguardException($"The has ran longer than {TimeSpan.TicksPerSecond * TimeLimit} ticks ({TimeLimit} seconds).");
            }
        }
    }
}