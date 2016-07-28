#PHP的ZipArchive类学习

####ZipArchive类：一个用Zip压缩的文件存档

1. ZipArchive::addEmptyDir — 在归档文件中加入一个空文件目录

	语法：bool ZipArchive::addEmptyDir  ( string $dirname  )
	说明：在归档文件中加入一个空文件目录
	参数为要添加的目录
	成功返回true，失败返回false

2. ZipArchive::addFile — 根据给的文件路径增加一个文件到zip归档文件

	语法：bool ZipArchive::addFile  ( string $filename  [, string $localname  = NULL    [, int $start  = 0  [, int $length  = 0  ]]] )
	说明：filename是要添加的文件名,localname参数如果给出则将使用这个别名来代替filename的名字
	成功返回true,失败返回false

	$zip = new ZipArchive;
	if ($zip->open('test.txt') === true) {
		$zip->addFile('/path/to/index.txt', 'newname.txt');
		$zip->close()
	} else {
		echo '实例化ZipArchive失败';
	}

3. ZipArchive::addFromString — 通过字符串内容来向ZipArchive归档文件中增加一个文件，将字符串内容写入文件

	语法：bool ZipArchive::addFromString  ( string $localname  , string $contents  )
	说明：localname为加入到归档文件的文件名，contents为将要写入文件中的内容
	成功返回true，失败返回false

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res == true) {
		$zip->addFromString('test.txt', 'file content goes here' );//在上面的压缩文件中加入文件test.txt,并将后面的字符串写入test.txt
		$zip->close();
	} else {
		echo '打开归档文件失败';
	}

4. ZipArchive::addGlob — 通过glob模式匹配来从一个文件目录里增肌文件，同名文件会覆盖

	语法：bool ZipArchive::addGlob  ( string $pattern  [, int $flags  = 0  [, array $options  = array()  ]] )
	说明：pattern是匹配的模式,flag是在增加文件到归档文件时，将文件名转换为localname的方法
	成功返回true，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$zip->addGlob('*.txt');//将当前目录下以txt结尾的文件添加到test.zip压缩文件里
		$zip->close();
	} else {
		echo '打开归档文件失败';
	}

5. ZipArchive::addPattern — 通过正则匹配模式将文件添加进归档文件

	语法：bool ZipArchive::addPattern  ( string $pattern  [, string $path  = '.'  [, array $options  = array()  ]] )
	说明：pattern为要添加的文件名的正则匹配模式，path指定要添加的文件所在的目录，默认为.即当前目录，第三个参数类似addGlob方法，参看那里的说明
	成功返回true，失败返回false

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$zip->addPattern('/*.html/');//不知道为什么这个方法会导致fastcgi失效
		$zip->close();
	} else {
		echo '打开归档文件失败';
	}

6. ZipArchive::close — 关闭处于活动状态的归档文件，活动状态指的是被打开和新创建的

	语法：bool ZipArchive::close  ( void )
	成功返回true，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$zip->addGlob('*.html');
		$zip->close();
	} else {
		echo '打开归档文件失败';
	}

7. ZipArchive::deleteIndex — 通过它的索引删除一个归档的文件
	
	语法：bool ZipArchive::deleteIndex  ( int $index  )
	成功返回true，失败返回false

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$zip->deleteIndex(0);//索引从0开始，根据文件添加的顺序编排索引，最先进入的索引为0
		$zip->close();
	}

8. ZipArchive::deleteName — 通过文件名删除一个归档的文件

	语法：bool ZipArchive::deleteName  ( string $name  )
	成功返回true,失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$zip->deleteName('index.html');
		$zip->close();
	}

9. ZipArchive::extractTo — 解压缩文件

	语法：bool ZipArchive::extractTo  ( string $destination  [, mixed  $entries  ] )
	说明：destination为解压到的地址，$entries为解压出的文件
	成功返回true失败返回false

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$zip->extractTo('D:\wnmp\haha', 'a.txt');//如果指定的文件路径不存在则会创建，如果指定了第二个参数则将只将其解压出来
		$zip->close();
	}

10. ZipArchive::getArchiveComment — 返回zip归档文件的comment

	语法：string ZipArchive::getArchiveComment  ([ int $flags  ] )
	若指定了参数$flags为ZipArchive::FL_UNCHANGED ，则返回原本未经改变的comment
	成功返回comment，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getArchiveComment());//string(0) ""
		$zip->close();
	}
	
11. ZipArchive::getCommentIndex — 通过索引返回一个归档的文件的comment

	语法：string ZipArchive::getCommentIndex  ( int $index  [, int $flags  ] )
	flag参数的含义与上面的相同。

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getCommentIndex(1));//string(0) ""
		$zip->close();
	}

12. ZipArchive::getCommentName — 通过文件名返回一个归档的文件的comment
	
	语法：string ZipArchive::getCommentName  ( string $name  [, int $flags  ] )
	name参数指定为归档的文件的名字
	成功返回true失败返回false

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getCommentName('b.txt'));
		$zip->close();
	}
	
13. ZipArchive::getFromIndex — 通过索引返回归档的文件的内容

	语法：string ZipArchive::getFromIndex  ( int $index  [, int $length  = 0  [, int $flags  ]] )
	说明：index为归档的文件的索引，length为读取的长度，默认为0表示读取所有的内容，
	成功返回文件内容，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getFromIndex(3));
		$zip->close();
	}
	//输出文件的内容：
	string(1103) " fastcgi_param SCRIPT_FILENAME $document_root$fastcgi_script_name; fastcgi_param QUERY_STRING $query_string; fastcgi_param REQUEST_METHOD $request_method; fastcgi_param CONTENT_TYPE $content_type; fastcgi_param CONTENT_LENGTH $content_length; fastcgi_param SCRIPT_NAME $fastcgi_script_name; fastcgi_param REQUEST_URI $request_uri; fastcgi_param DOCUMENT_URI $document_uri; fastcgi_param DOCUMENT_ROOT $document_root; fastcgi_param SERVER_PROTOCOL $server_protocol; fastcgi_param ...

14. ZipArchive::getFromName — 通过文件名返回归档的文件的内容

	语法：string ZipArchive::getFromName  ( string $name  [, int $length  = 0  [, int $flags  ]] )
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getFromName('50x.html'));
		$zip->close();
	}
	输出：
	string(537) "
	An error occurred.
	
	Sorry, the page you are looking for is currently unavailable.
	Please try again later.
	
	If you are the system administrator of this resource then you should check the error log for details.
	
	Faithfully yours, nginx ...
	
15. ZipArchive::getNameIndex — 返回索引指代的文件名

	语法：string ZipArchive::getNameIndex  ( int $index  [, int $flags  ] )
	如果参数flags的值为ZipArchive::FL_UNCHANGED ，则返回原本的未经改变的名字
	成功返回文件名，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getNameIndex(2));//输出 string(5) "c.txt"
		$zip->close();
	}
		
16. ZipArchive::getStatusString — 返回状态的错误信息，系统的后者zip错误信息

	语法：string ZipArchive::getStatusString  ( void )
	成功返回状态信息，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->getStatusString());//输出 string(8) "No error"
		$zip->close();
	}

17. ZipArchive::getStream — 通过名字获得一个归档的文件的文件句柄，对该文件句柄只能读取

	语法：resource ZipArchive::getStream  ( string $name  )
	成功返回文件句柄，失败返回false.

	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		$fp = $zip->getStream('a.txt');
		echo fread($fp,1024);//输出 121111111111111
		fclose($fp);
		$zip->close();

	}

18. ZipArchive::locateName — 通过localname返回归档文件的索引

	语法：int ZipArchive::locateName  ( string $name  [, int $flags  ] )
	成功返回文件名，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('test.zip');
	if ($res) {
		var_dump($zip->locateName('c.txt'));// int(2)
		
		$zip->close();
	}

19. ZipArchive::open — 打开一个归档文件

	语法：mixed  ZipArchive::open  ( string $filename  [, int $flags  ] )
	说明：打开一个系的归档文件以读、写和更改
	flag的取值有ZipArchive::OVERWRITE代表重写，   ZipArchive::CREATE代表创建，  ZipArchive::EXCL  ZipArchive::CHECKCONS 

	$zip = new ZipArchive;
	$res = $zip->open('testt.zip', ZipArchive::CREATE);//第二个是创建一个新的归档文件
	if ($res) {
		$zip->addGlob('*.txt');
		
		$zip->close();
	}
	
20. ZipArchive::renameIndex — 通过索引重命名一个归档的文件

	语法：bool ZipArchive::renameIndex  ( int $index  , string $newname  )
	index是归档文件的索引，newname是新的名字
	成功返回true，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('testt.zip', ZipArchive::CREATE);
	if ($res) {
		echo $zip->getNameIndex(2);//输出 c.txt
		$zip->renameIndex(2, 'ccc.txt');
		echo $zip->getNameIndex(2);//输出 ccc.txt
		$zip->close();
	}

21. ZipArchive::renameName — 通过名字重命名一个归档的文件

	语法：bool ZipArchive::renameName  ( string $name  , string $newname  )
	name是归档文件的名字，newname是新的名字
	
	$zip = new ZipArchive;
	$res = $zip->open('testt.zip', ZipArchive::CREATE);
	if ($res) {
		echo $zip->getNameIndex(0);//a.txt
		$zip->renameName('a.txt', 'aaa.txt');
		echo $zip->getNameIndex(0);//aaa.txt
		$zip->close();
	}

22. ZipArchive::setArchiveComment — 为归档文件设置一个comment

	语法：bool ZipArchive::setArchiveComment  ( string $comment  )
	成功返回true，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('testt.zip', ZipArchive::CREATE);
	if ($res) {
		$zip->setArchiveComment('哎呦，不错哦！');
		echo $zip->getArchiveComment();// 哎呦，不错哦！
		$zip->close();
	}

23. ZipArchive::setCommentIndex — 通过索引为归档的文件设置comment

	语法：bool ZipArchive::setCommentIndex  ( int $index  , string $comment  )
	成功返回true，失败返回false

24. ZipArchive::setCommentName — 通过名字为归档的文件设置comment

	语法：bool ZipArchive::setCommentName  ( string $name  , string $comment  )
	成功返回true，失败返回false

25. ZipArchive::statIndex — 通过索引获得归档文件的详细信息

	语法：array ZipArchive::statIndex  ( int $index  [, int $flags  ] )
	成功返回文件信息，失败返回false

	$zip = new ZipArchive;
	$res = $zip->open('testt.zip', ZipArchive::CREATE);
	if ($res) {
		$zip->setArchiveComment('哎呦，不错哦！');
		var_dump($zip->statIndex(2));
		$zip->close();
	}
	输出结果：
	
	array(7) {
	  ["name"]=>
	  string(7) "ccc.txt"
	  ["index"]=>
	  int(2)
	  ["crc"]=>
	  int(0)
	  ["size"]=>
	  int(0)
	  ["mtime"]=>
	  int(1469701566)
	  ["comp_size"]=>
	  int(0)
	  ["comp_method"]=>
	  int(0)
	}

26. ZipArchive::statName — 通过文件名字获得归档文件的详细信息

	语法：array ZipArchive::statIndex  ( int $index  [, int $flags  ] )
	成功返回文件信息，失败返回false

27. ZipArchive::unchangeAll — Undo all changes done in the archive

	语法：bool ZipArchive::unchangeAll  ( void )
	取消之前对归档文件的修改
	成功返回true，失败返回false
	
	$zip = new ZipArchive;
	$res = $zip->open('testt.zip', ZipArchive::CREATE);
	if ($res) {
		$zip->setArchiveComment('hhhh');
		$zip->unchangeAll();
		var_dump($zip->getArchiveComment());
		$zip->close();
	}

28. ZipArchive::unchangeArchive — Revert all global changes done in the archive.
	
	语法：bool ZipArchive::unchangeArchive  ( void )
	这个只改变取消了comment的修改

29. ZipArchive::unchangeIndex — 通过索引取消对归档的文件的修改

	语法：bool ZipArchive::unchangeIndex  ( int $index  )
	
30. ZipArchive::unchangeName — 通过名字取消对归档的文件的修改
	
	语法：bool ZipArchive::unchangeName  ( string $name  )




简介

压缩与归档扩展 

RarException::setUsingExceptions



在线手册：中文 英文

PHP 手册　├ 序言入门指引　├ 简介　├ 简明教程安装与配置　├ 安装前需要考虑的事项　├ Unix 系统下的安装　├ Mac OS X 系统下的安装　├ Windows 系统下的安装　├ 云计算平台上的安装　├ FastCGI 进程管理器（FPM）　├ PECL 扩展库安装　├ 还有问题？　├ 运行时配置语言参考　├ 基本语法　├ 类型　├ 变量　├ 常量　├ 表达式　├ 运算符　├ 流程控制　├ 函数　├ 类与对象　├ 命名空间　├ 异常处理　├ 生成器　├ 引用的解释　├ 预定义变量　├ 预定义异常　├ 预定义接口　├ 上下文（Context）选项和参数　├ 支持的协议和封装协议安全　├ 简介　├ 总则　├ 以 CGI 模式安装时　├ 以 Apache 模块安装时　├ 文件系统安全　├ 数据库安全　├ 错误报告　├ 使用 Register Globals　├ 用户提交的数据　├ 魔术引号　├ 隐藏 PHP　├ 保持更新特点　├ 用 PHP 进行 HTTP 认证　├ Cookie　├ 会话　├ 处理 XForms　├ 文件上传处理　├ 使用远程文件　├ 连接处理　├ 数据库永久连接　├ 安全模式　├ PHP 的命令行模式　├ 垃圾回收机制函数参考　├ 影响 PHP 行为的扩展　├ 音频格式操作　├ 身份认证服务　├ 日期与时间相关扩展　├ 针对命令行的扩展　├ 压缩与归档扩展　├ 信用卡处理　├ 加密扩展　├ 数据库扩展　├ 文件系统相关扩展　├ 国际化与字符编码支持　├ 图像生成和处理　├ 邮件相关扩展　├ 数学扩展　├ 非文本内容的 MIME 输出　├ 进程控制扩展　├ 其它基本扩展　├ 其它服务　├ 搜索引擎扩展　├ 针对服务器的扩展　├ Session 扩展　├ 文本处理　├ 变量与类型相关扩展　├ Web 服务　├ Windows 专用扩展　├ XML 操作PHP 核心：骇客指南　├ 序言　├ 内存管理　├ 变量的使用　├ 函数的编写　├ 类和对象的使用　├ 资源的使用　├ INI 设置的使用　├ 流的使用　├ "counter" 扩展 - 一个连续的实例　├ PHP 5 构建系统　├ 扩展的结构　├ PDO 驱动　├ 扩展相关 FAQ　├ Zend Engine 2 API 参考　├ Zend Engine 2 操作码列表　├ Zend Engine 1附录　├ PHP 及其相关工程的历史　├ Migrating from PHP 5.4.x to PHP 5.5.x　├ 从 PHP 5.3.X 迁移到 PHP 5.4.X　├ 从 PHP 5.2.x 移植到 PHP 5.3.x　├ Migrating from PHP 5.1.x to PHP 5.2.x　├ Migrating from PHP 5.0.x to PHP 5.1.x　├ 从 PHP 4 移植到 PHP 5　├ 类与对象（PHP 4）　├ PHP 的调试　├ 配置选项　├ php.ini 配置　├ 扩展库列表／归类　├ 函数别名列表　├ 保留字列表　├ 资源类型列表　├ 可用过滤器列表　├ 所支持的套接字传输器（Socket Transports）列表　├ PHP 类型比较表　├ 解析器代号列表　├ 用户空间命名指南　├ 关于本手册　├ Creative Commons Attribution 3.0　├ 索引　├ 更新日志

Index



用户评论:


[#1] singh206 at gmail dot com [2009-08-10 11:21:00]

Caution:  If you accidentally let an extra '/' slip into your filepath, such as, '/myzipstuff//myfile.mp3', Mac OS X will handle resolve this, and you won't notice 
