###version_compare — 对比两个「PHP 规范化」的版本数字字符串

	mixed  version_compare  ( string $version1  , string $version2  [, string $operator  ] )
	
	if (version_compare(PHP_VERSION, '5.5.0', '>')) {
		echo '1';
	}

	echo PHP_VERSION;

###PHP_SAPI

###trim — 去除字符串首尾处的空白字符（或者其他字符） 

	语法：string trim  ( string $str  [, string $charlist  = " \t\n\r\0\x0B"  ] )
	string trim  ( string $str  [, string $charlist  = " \t\n\r\0\x0B"  ] )

	此函数返回字符串 str  去除首尾空白字符后的结果。如果不指定第二个参数， trim()  将去除这些字符：
	charlist为可选参数，过滤字符也可由 charlist  参数指定。一般要列出所有希望过滤的字符，也可以使用 “..” 列出一个字符范围。 
	返回值为过滤后的字符串。 

	$str = '  f fafasfafa /';
	echo trim($str, '/');
	输出：f fafasfafa，去掉空格的同时去掉/

###is_numeric — 检测变量是否为数字或数字字符串 
	bool is_numeric  ( mixed  $var  )
	如果 var  是数字和数字字符串则返回 TRUE ，否则返回 FALSE 。 


###is_int — 检测变量是否是整数 
	bool is_int  ( mixed  $var  )
	如果 var  是 integer  则返回 TRUE ，否则返回 FALSE 。 
	若想测试一个变量是否是数字或数字字符串（如表单输入，它们通常为字符串），必须使用 is_numeric() 。

###glob扫描目录，以指定模式来查找文件

###scandir 扫描文件夹下的所有文件，包括 .  和  ..

###filetype - 返回文件或目录的类型名称，对比is_file
	string filetype  ( string $filename  )
	返回文件的类型。 
	返回文件的类型。 可能的值有 fifo，char，dir，block，link，file 和 unknown。 
	如果出错则返回 FALSE 。如果 stat 调用失败或者文件类型未知的话 filetype()  还会产生一个 E_NOTICE  消息。 

###filesize
 



##setcookie设置cookie时将值尽量序列化
setcookie($name, serialize($value), expire, path, domain);