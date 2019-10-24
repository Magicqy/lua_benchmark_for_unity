using UnityEngine;
using System.Collections;
using LuaInterface;
public class benchmark : MonoBehaviour
{
    LuaState _luaState;
    bool inited = false;
    // Use this for initialization
    void Start()
    {
        Application.logMessageReceived += this.log;

        var startMem = System.GC.GetTotalMemory(true);

        var start = Time.realtimeSinceStartup;

        new LuaResLoader();
        _luaState = new LuaState();
        _luaState.Start();
        LuaBinder.Bind(_luaState);
        Debug.Log("start cost: " + (Time.realtimeSinceStartup - start));
        _luaState.DoFile("benchmark.lua");
        var endMem = System.GC.GetTotalMemory(true);
        Debug.Log("startMem: " + startMem + ", endMem: " + endMem + ", " + "cost mem: " + (endMem - startMem));
        inited = true;
    }

    private void OnDestroy()
    {
        if (_luaState != null)
        {
            _luaState.Dispose();
            _luaState = null;
        }
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
            var func = _luaState.GetFunction("test1");
            UnityEngine.Profiling.Profiler.BeginSample("test1");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 100, 120, 50), "Test2"))
        {
            logText = "";
            var func = _luaState.GetFunction("test2");
            UnityEngine.Profiling.Profiler.BeginSample("test2");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 200, 120, 50), "Test3"))
        {
            logText = "";
            var func = _luaState.GetFunction("test3");
            UnityEngine.Profiling.Profiler.BeginSample("test3");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 300, 120, 50), "Test4"))
        {
            logText = "";
            var func = _luaState.GetFunction("test4");
            UnityEngine.Profiling.Profiler.BeginSample("test4");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 10, 120, 50), "Test5"))
        {
            logText = "";
            var func = _luaState.GetFunction("test5");
            UnityEngine.Profiling.Profiler.BeginSample("test5");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 100, 120, 50), "Test6 jit"))
        {
            logText = "";
            var func = _luaState.GetFunction("test6");
            UnityEngine.Profiling.Profiler.BeginSample("test6");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 200, 120, 50), "Test6 non-jit"))
        {
            logText = "";
            var func = _luaState.GetFunction("test7");
            UnityEngine.Profiling.Profiler.BeginSample("test7");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        GUI.Label(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), logText);
    }
}