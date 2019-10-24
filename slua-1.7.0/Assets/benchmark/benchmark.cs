using UnityEngine;
using System.Collections;
using SLua;
public class benchmark : MonoBehaviour
{
    LuaSvr l;
    bool inited = false;
    // Use this for initialization
    void Start()
    {
        Application.logMessageReceived += this.log;

        var startMem = System.GC.GetTotalMemory(true);

        var start = Time.realtimeSinceStartup;
        l = new LuaSvr();
        l.init(null, () =>
        {
            Debug.Log("start cost: " + (Time.realtimeSinceStartup - start));

            var endMem = System.GC.GetTotalMemory(true);
            Debug.Log("startMem: " + startMem + ", endMem: " + endMem + ", " + "cost mem: " + (endMem - startMem));
            l.start("benchmark");
            inited = true;
        });
    }

    string logText = "";
    void log(string cond, string trace, LogType lt)
    {
        logText += cond;
        logText += "\n";
    }

    void OnGUI()
    {
        if (!inited)
            return;

        if (GUI.Button(new Rect(10, 10, 120, 50), "Test1"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test1");
            UnityEngine.Profiling.Profiler.BeginSample("test1");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 100, 120, 50), "Test2"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test2");
            UnityEngine.Profiling.Profiler.BeginSample("test2");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 200, 120, 50), "Test3"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test3");
            UnityEngine.Profiling.Profiler.BeginSample("test3");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 300, 120, 50), "Test4"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test4");
            UnityEngine.Profiling.Profiler.BeginSample("test4");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 10, 120, 50), "Test5"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test5");
            UnityEngine.Profiling.Profiler.BeginSample("test5");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 100, 120, 50), "Test6 jit"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test6");
            UnityEngine.Profiling.Profiler.BeginSample("test6");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 200, 120, 50), "Test6 non-jit"))
        {
            logText = "";
            var func = LuaSvr.mainState.getFunction("test7");
            UnityEngine.Profiling.Profiler.BeginSample("test7");
            func.call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        GUI.Label(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), logText);
    }
}