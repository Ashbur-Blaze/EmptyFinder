\# EmptyFinder



一个用 C# 写的空文件查找工具。



\## 功能



\- 输入一个文件夹路径

\- 递归查找里面所有大小为 0 字节的文件

\- 打印每个空文件的路径

\- 输出找到的空文件总数

\- 可选：删除找到的空文件



\## 运行



需要 .NET SDK。



&#x20;   dotnet run -- "C:\\Users\\86137\\Desktop\\Test"



\## 输出示例



&#x20;   C:\\Users\\86137\\Desktop\\Test\\empty1.txt

&#x20;   C:\\Users\\86137\\Desktop\\Test\\sub\\empty2.txt

&#x20;   共找到 2 个空文件



&#x20;   是否删除这些空文件？(y/n):



\## 用途



\- 清理无用的空文件

\- 检查项目目录里有没有意外创建的空文件

\- 批量扫描磁盘中的 0 字节文件



\## 技术



\- C#

\- .NET

\- System.IO

\- System.Collections.Generic



\## 许可证



MIT

