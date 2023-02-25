using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {
    public static void SetTimeout(Action action, int timeout_milis, MonoBehaviour self) {
        self.StartCoroutine(DoTimeout(action, timeout_milis));
    }

    public static IEnumerator DoTimeout(Action action, int timeout_milis) {
        yield return new WaitForSeconds((float)timeout_milis/1000f);
        action.Invoke();
    }
}