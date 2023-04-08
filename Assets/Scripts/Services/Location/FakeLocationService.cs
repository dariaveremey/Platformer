﻿using System;
using UnityEngine;

namespace Services.Location
{
    public class FakeLocationService:ILocationService
    {
        private const string Tag = nameof(FakeLocationService);
        public bool IsValid { get; private set; }
        public Coords Coords { get;private set;  }
        public void Bootstrap(Action completeCallback)
        {
            Debug.Log($"[{Tag},{nameof(Bootstrap)}]");
            IsValid = true;
            Coords = new Coords(53.904541f,27.561523f);
            completeCallback?.Invoke();
        }
    }
}