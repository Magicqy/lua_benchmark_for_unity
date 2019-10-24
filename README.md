# lua_benchmark_for_unity

测试环境：
以github上的release版本为准：
slua-1.7.0
tolua-1.0.8.591
xlua-2.1.14

其中slua使用的是原生lua5.1，tolua使用的是luajit-2.1，xlua分为两个版本lua5.3和luajit2.1
unity版本2018.4.2f1，编译设置为il2cpp
测试例子修改自slua中的perf示例程序，启动程序后依次执行一次

测试结果（华为荣耀9）：
case    test1   test2   test3   test4   test5   test6
tolua   0.754   0.820   5.257   4.302   1.160   1.254
slua    1.369   2.907   10.327  5.935   1.658   4.367
xlua53  0.998   1.423   9.743   4.379   1.117   1.740
xluajit 0.471   0.742   3,891   4.014   1.046   0.794

测试结果（iPhone 6s）：
case    test1   test2   test3   test4   test5   test6
tolua   0.173   0.232   1.113   1.897   0.568   0.366
slua    0.447   1.140   3.680   2.950   0.794   1.729
xlua53
xluajit

测试结果（UnityEditor，PC-i7-3.0GHZ-CPU-16G-RAM-Win10-x64）：
case    test1   test2   test3   test4   test5   test6
tolua   0.116   0.123   0.534   1.639   0.399   0.244
slua    0.766   0.942   2.059   3.655   1.079   0.831
xlua53  0.126   0.177   1.211   1.608   0.391   0.346
xluajit 0.103   0.146   1.006   1.514   0.396   0.190