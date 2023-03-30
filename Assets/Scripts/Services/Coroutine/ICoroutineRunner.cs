using System.Collections;
using System.Collections.Generic;

namespace Services.Coroutine
{
    public interface ICoroutineRunner
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
}