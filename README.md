# lua_benchmark_for_unity

测试环境：
以github上的release版本为准：
slua-1.7.0
tolua-1.0.8.591

其中slua使用的是原生lua5.1，tolua使用的是luajit-2.1
unity编译设置为il2cpp，测试设备：华为荣耀9

测试结果：
case    tolua   slua
test1   0.742   1.385
test2   0.850   2.911
test3   5.282   10.105
test4   4.315   6.040
test5   1.248   1.706
test6   1.242   4.413
test7   1.181   4.031