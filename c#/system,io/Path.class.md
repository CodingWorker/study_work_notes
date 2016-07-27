#Path类

对包含文件或目录路径信息的 String 实例执行操作。这些操作是以跨平台的方式执行的

命名空间：System.IO

语法：public static class Path

备注： .NET Framework 不支持通过由设备名称构成的路径（如“\\.\PHYSICALDRIVE0”）直接访问物理磁盘。 

Path 类的字段以及 Path 类的某些成员的准确行为是与平台相关的。 

路径可以是绝对路径和相对路径，相对路径是以当前位置用作起点。

Path 类的大多数成员**不与文件系统交互**，并且**不验证**路径字符串指定的文件是否存在。修改路径字符串的 Path 类成员（例如 ChangeExtension）对文件系统中文件的名称没有影响。**但 Path 成员确实验证指定路径字符串的内容；**并且如果字符串包含在路径字符串中无效的字符（如 InvalidPathChars 中的定义），则引发 ArgumentException。例如，在基于 Windows 的桌面平台上，无效路径字符可能包括引号 (")、小于号 (<)、大于号 (>)、管道符号 (|)、退格 (\b)、null (\0) 以及从 16 到 18 和从 20 到 25 的 Unicode 字符。 

Path 类的成员使您可以快速方便地执行常见操作，例如确定文件扩展名是否是路径的一部分，以及将两个字符串组合成一个路径名。 

Path 类的**所有成员都是静态的**，因此无需具有路径的实例即可被调用。 

###说明：

在接受路径作为输入字符串的成员中，**路径必须是格式良好的**，否则将引发异常。例如，如果路径是完全限定的但以空格开头，则路径在类的方法中不会被修剪。因此，路径的格式不正确，并将引发异常。同样，路径或路径的组合不能被完全限定两次。例如，“c:\temp c:\windows”在大多数情况下也将引发异常。在使用接受路径字符串的方法时，请确保路径是格式良好的。

在接受路径的成员中，**路径可以是指文件或仅是目录**。指定路径也可以是相对路径或者服务器和共享名称的统一命名约定 (UNC) 路径。例如，以下都是可接受的路径： 

	• C# 中的“c:\\MyDir\\MyFile.txt”或 Visual Basic 中的“c:\MyDir\MyFile.txt”。 
	
	• C# 中的“c:\\MyDir”或 Visual Basic 中的“c:\MyDir”。 
	
	• C# 中的“MyDir\\MySubdir”或 Visual Basic 中的“MyDir\MySubDir”。 
	
	• C# 中的“\\\\MyServer\\MyShare”或 Visual Basic 中的“\\MyServer\MyShare”。 


因为所有这些操作都是对字符串执行的，所以不可能验证结果是否在所有方案中都有效。例如，GetExtension 方法分析您传递给它的字符串，**并且从该字符串返回扩展名。但是，这并不意味着在磁盘上存在具有该扩展名的文件**。 

有关通用 I/O 任务的列表，请参见 通用 I/O 任务。 

##Path字段

Path类型公开以下成员

1. AltDirectorySeparatorChar
>路径分隔符，类似PHP中的DIRECTORY_SEPARATOR,在unix平台是\,在 Windows 和 Macintosh 操作系统上为斜杠（“/”）。

2. DirectorySeparatorChar
>与上面的字段作用相同，都可以用来分隔路径，该字段的值在 Unix 上为斜杠（“/”），在 Windows 和 Macintosh 操作系统上为反斜杠（“\”）。

3. PathSeparator 
>用于在环境变量中分隔路径字符串的平台特定的分隔符。 在基于 Windows 的桌面平台上，默认情况下该字段的值是分号 (;)，但在其他平台上可能会有所不同。 

4. VolumeSeparatorChar
>提供平台特定的卷分隔符。 该字段的值在 Windows 和 Macintosh 上为冒号（“:”），在 Unix 操作系统上为斜杠（“/”）。这对于分析像“c:\windows”或“MacVolume:System Folder”这样的路径最为有用。 


##Path方法

- ChangeExtension   更改路径字符串的扩展名。   
- Combine   合并两个路径字符串。   
- GetDirectoryName   返回指定路径字符串的目录信息。   
- GetExtension   返回指定的路径字符串的扩展名。   
- GetFileName   返回指定路径字符串的文件名和扩展名。   
- GetFileNameWithoutExtension   返回不具有扩展名的指定路径字符串的文件名。   
- GetFullPath   返回指定路径字符串的绝对路径。   
- GetInvalidFileNameChars   获取包含不允许在文件名中使用的字符的数组。   
- GetInvalidPathChars   获取包含不允许在路径名中使用的字符的数组。   
- GetPathRoot   获取指定路径的根目录信息。   
- GetRandomFileName   返回随机文件夹名或文件名。   
- GetTempFileName   创建磁盘上唯一命名的零字节的临时文件并返回该文件的完整路径。   
- GetTempPath   返回当前系统的临时文件夹的路径。   
- HasExtension   确定路径是否包括文件扩展名。   
- IsPathRooted   获取一个值，该值指示指定的路径字符串是包含绝对路径信息还是包含相对路径信息。  
