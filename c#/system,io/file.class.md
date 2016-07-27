#Path的File类

提供用于**创建、复制、删除、移动和打开文件**的静态方法，并协助创建 FileStream 对象。

命名空间：System.IO

语法：public static class File

###备注

将 File 类用于典型的操作，如**复制、移动、重命名、创建、打开、删除和追加到文件**。也可将 File 类用于获取和设置文件**属性或有关文件创建、访问及写入操作的 DateTime 信息**。

许多 File 方法在您创建或打开文件时返回其他 I/O 类型。可以使用这些其他类型进一步处理文件。有关更多信息，请参见特定的 File 成员，如 OpenText、CreateText 或 Create。

由于所有的 **File 方法都是静态**的，所以如果只想执行一个操作，那么使用 File 方法的**效率**比使用相应的 FileInfo 实例方法可能更高。所有的 File 方法**都要求当前所操作的文件的路径**。

File 类的静态方法对所有方法都执行安全检查。如果打算多次重用某个对象，可考虑改用 FileInfo 的相应实例方法，因为并不总是需要安全检查。

**默认情况下**，将向所有用户**授予对新文件的完全读/写访问权限**。

下表描述了用于自定义各种 File 方法的行为的枚举。

###说明

在接受路径作为输入字符串的成员中，路径必须是**格式良好的**，否则将引发异常。例如，如果路径是完全限定的但以空格开头，则路径在类的方法中不会被修剪。因此，路径的格式不正确，并将引发异常。同样，路径或路径的组合不能被完全限定两次。例如，“c:\temp c:\windows”在大多数情况下也将引发异常。在使用接受路径字符串的方法时，请确保路径是格式良好的。

在接受路径的成员中，**路径可以是指文件或仅是目录**。指定路径也可以是相对路径或者服务器和共享名称的统一命名约定 (UNC) 路径。例如，以下都是可接受的路径：

•C# 中的“c:\\MyDir\\MyFile.txt”或 Visual Basic 中的“c:\MyDir\MyFile.txt”。


•C# 中的“c:\\MyDir”或 Visual Basic 中的“c:\MyDir”。


•C# 中的“MyDir\\MySubdir”或 Visual Basic 中的“MyDir\MySubDir”。


•C# 中的“\\\\MyServer\\MyShare”或 Visual Basic 中的“\\MyServer\MyShare”。


有关通用 I/O 任务的列表，请参见 通用 I/O 任务。

##File成员

公开成员/方法

AppendAllText  已重载。 将指定的**字符串追加到文件中**，如果文件还不存在则创建该文件。 
AppendText  创建一个 StreamWriter，它将 UTF-8 编码文本追加到现有文件。  
Copy  已重载。 将现有文件复制到新文件。 
Create  已重载。 在指定路径中创建文件。 
CreateText  创建或打开一个文件用于写入 UTF-8 编码的文本。  
Decrypt  解密由**当前帐户**使用 Encrypt 方法加密的文件。  
Delete  删除指定的文件。如果指定的文件不存在，**则不引发异常**。  
Encrypt  将某个文件加密，使得只有加密该文件的帐户才能将其解密。  
Exists  确定指定的文件是否存在。  
GetAccessControl  已重载。 获取一个 FileSecurity 对象，它封装指定文件的访问控制列表 (ACL) 条目。 
GetAttributes  获取在此路径上的文件的 FileAttributes(文件属性)。  
GetCreationTime  返回指定文件或目录的创建日期和时间。  
GetCreationTimeUtc  返回指定的文件或目录的创建日期及时间，其格式为协调通用时间 (UTC)。  
GetLastAccessTime  返回上次访问指定文件或目录的日期和时间。  
GetLastAccessTimeUtc  返回上次访问指定的文件或目录的日期及时间，其格式为协调通用时间 (UTC)。  
GetLastWriteTime  返回上次写入指定文件或目录的日期和时间。  
GetLastWriteTimeUtc  返回上次写入指定的文件或目录的日期和时间，其格式为协调通用时间 (UTC)。  
Move  将指定文件移到新位置，并提供指定新文件名的选项。  
Open  已重载。 打开指定路径上的 FileStream。 
OpenRead  打开现有文件以进行读取。  
OpenText  打开现有 UTF-8 编码文本文件以进行读取。  
OpenWrite  打开现有文件以进行写入。  
ReadAllBytes  打开一个文件，将文件的内容读入一个字符串，然后关闭该文件。  
ReadAllLines  已重载。 打开一个文本文件，将文件的所有行都读入一个字符串数组，然后关闭该文件。 
ReadAllText  已重载。 打开一个文本文件，将文件的所有行读入一个字符串，然后关闭该文件。 
Replace  已重载。 使用其他文件的内容替换指定文件的内容，这一过程将删除原始文件，并创建被替换文件的备份。 
SetAccessControl  对指定的文件应用由 FileSecurity 对象描述的访问控制列表 (ACL) 项。  
SetAttributes  设置指定路径上文件的指定的 FileAttributes。  
SetCreationTime  设置创建该文件的日期和时间。  
SetCreationTimeUtc  设置文件创建的日期和时间，其格式为协调通用时间 (UTC)。  
SetLastAccessTime  设置上次访问指定文件的日期和时间。  
SetLastAccessTimeUtc  设置上次访问指定的文件的日期和时间，其格式为协调通用时间 (UTC)。  
SetLastWriteTime  设置上次写入指定文件的日期和时间。  
SetLastWriteTimeUtc  设置上次写入指定的文件的日期和时间，其格式为协调通用时间 (UTC)。  
WriteAllBytes  创建一个新文件，在其中写入指定的字节数组，然后关闭该文件。如果目标文件已存在，则覆盖该文件。  
WriteAllLines  已重载。 创建一个新文件，在其中写入指定的字符串，然后关闭文件。如果目标文件已存在，则覆盖该文件。 
WriteAllText  已重载。 创建一个新文件，在文件中写入内容，然后关闭文件。如果目标文件已存在，则覆盖该文件。 
