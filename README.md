# lua_benchmark_for_unity

测试环境：
以github上的release版本为准：
slua-1.7.0
tolua-1.0.8.591

其中slua使用的是原生lua5.1，tolua使用的是luajit-2.1
unity版本2018.4.2f1，编译设置为il2cpp
测试例子来自slua中的perf示例程序，启动程序后依次执行一次

测试结果（华为荣耀9）：
case    test1   test2   test3   test4   test5   test6   test7
tolua   0.754   0.820   5.157   4.302   1.260   1.254   1.185
slua    1.369   2.907   10.527  6.035   1.705   4.567   4.058

测试结果（iPhone 6s）：
case    test1   test2   test3   test4   test5   test6   test7
tolua   0.173   0.232   1.113   1.897   0.568   0.366   0.346
slua    0.447   1.140   3.680   2.950   0.794   1.729   1.605

测试结果（网易MuMu，PC-i7-3.0GHZ-CPU-16G-RAM-Win10-x64）：
case    test1   test2   test3   test4   test5   test6   test7
tolua   0.112   0.134   0.003   1.179   0.358   0.0005  0.0006
slua    0.362   0.759   2.353   1.971   0.861   1.189   1.022