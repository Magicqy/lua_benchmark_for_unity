using UnityEngine;
using System.Collections;
using XLua;
public class benchmark : MonoBehaviour
{
    LuaEnv _luaEnv;
    bool inited = false;
    // Use this for initialization
    void Start()
    {
        Application.logMessageReceived += this.log;

        var startMem = System.GC.GetTotalMemory(true);

        var start = Time.realtimeSinceStartup;
        _luaEnv = new LuaEnv();
        var script = Resources.Load<TextAsset>("benchmark").text;
        Debug.Log("start cost: " + (Time.realtimeSinceStartup - start));

        var endMem = System.GC.GetTotalMemory(true);
        Debug.Log("startMem: " + startMem + ", endMem: " + endMem + ", " + "cost mem: " + (endMem - startMem));
        _luaEnv.DoString(script);
        inited = true;
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
            var func = _luaEnv.Global.Get<LuaFunction>("test1");
            UnityEngine.Profiling.Profiler.BeginSample("test1");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 100, 120, 50), "Test2"))
        {
            logText = "";
            var func = _luaEnv.Global.Get<LuaFunction>("test2");
            UnityEngine.Profiling.Profiler.BeginSample("test2");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 200, 120, 50), "Test3"))
        {
            logText = "";
            var func = _luaEnv.Global.Get<LuaFunction>("test3");
            UnityEngine.Profiling.Profiler.BeginSample("test3");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(10, 300, 120, 50), "Test4"))
        {
            logText = "";
            var func = _luaEnv.Global.Get<LuaFunction>("test4");
            UnityEngine.Profiling.Profiler.BeginSample("test4");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 10, 120, 50), "Test5"))
        {
            logText = "";
            var func = _luaEnv.Global.Get<LuaFunction>("test5");
            UnityEngine.Profiling.Profiler.BeginSample("test5");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        if (GUI.Button(new Rect(200, 100, 120, 50), "Test6"))
        {
            logText = "";
            var func = _luaEnv.Global.Get<LuaFunction>("test6");
            UnityEngine.Profiling.Profiler.BeginSample("test6");
            func.Call();
            UnityEngine.Profiling.Profiler.EndSample();
        }

        GUI.Label(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), logText);
    }
}