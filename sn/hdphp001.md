# ./hdphp/文件夹

----------

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

###glob扫描目录（参数中指定），以指定模式来查找文件

###scandir 扫描文件夹下的所有文件返回文件名，包括 .  和  ..

###filetype - 返回文件或目录的类型名称，对比is_file  --  is_dir
	string filetype  ( string $filename  )
	返回文件的类型。 
	返回文件的类型。 可能的值有 fifo，char，dir，block，link，file 和 unknown。 
	如果出错则返回 FALSE 。如果 stat 调用失败或者文件类型未知的话 filetype()  还会产生一个 E_NOTICE  消息。 

###filesize
 
###file_exists检测文件或目录是否存在


##setcookie设置cookie时将值尽量序列化
	setcookie($name, serialize($value), expire, path, domain);


#image文件夹
功能：检查文件合法性，制作缩略图，制作水印图

extension_loaded('gd');

####制作缩略图
**imagecopyresampled — 重采样拷贝部分图像并调整大小 **

	bool imagecopyresampled  ( resource $dst_image  , resource $src_image  , int $dst_x  , int $dst_y  , int $src_x  , int $src_y  , int $dst_w  , int $dst_h  , int $src_w  , int $src_h  )
	imagecopyresampled()  将一幅图像中的一块正方形区域拷贝到另一个图像中，平滑地插入像素值，因此，尤其是，减小了图像的大小而仍然保持了极大的清晰度。 
	可以用来制作缩略图

文件操作完后要及时地销毁资源，使用`imagedestroy`

**imagecopymerge**水印图处理

#str文件夹
功能：

	gbk转utf-8
	PHP代码压缩/去空白注释
	utf8换转gbk
	去除特殊符号：,.!;:<>\?'"@#$%^&*\(\)\-_\+=\|\\\{\}\[\]\/`
	获取随机数用来制作验证码
	
**token_get_all** — 将提供的源码按 PHP 标记进行分割（以PHP的token为分隔点），注意： token_get_all 的内存消耗极大

	array token_get_all  ( string $source  )
	token_get_all()  解析提供的 source  源码字符，然后使用 Zend 引擎的语法分析器获取源码中的 PHP 语言的解析器代号
	返回一个数组

	$tokens  =  token_get_all ( '/* comment */' );  
	print_r($tokens);
	$tokens  =  token_get_all ( '<?php echo; ?>' );  
	print_r($tokens);
	输出：	
	Array
	(
	    [0] => Array
	        (
	            [0] => 314
	            [1] => /* comment */
	            [2] => 1
	        )
	
	)

**strtr**字符串替换

	语法：string strtr  ( string $str  , string $from  , string $to  )
		  string strtr  ( string $str  , array $replace_pairs  )
	两个语法都能使用，使用第二个则数组中的键名即为$from，键值即为$to
	返回转换后的字符串

	$str = 'Content-type:text/html;';
	echo strtr($str, array('e'=>'ee', 't'=>'tt'));
	输出：Contteentt-ttypee:tteextt/httml;

**array_combine($arr, $arr2) - 创建一个数组，用一个数组的值作为其键名，另一个数组的值作为其值 **

	array array_combine  ( array $keys  , array $values  )
	返回一个 array ，用来自 keys  数组的值作为键名，来自 values  数组的值作为相应的值。 
	返回合并的array,如果两个数组的单元数不同则返回false

	$a  = array( 'green' ,  'red' ,  'yellow' );
	$b  = array( 'avocado' ,  'apple' ,  'banana' );
	$c  =  array_combine ( $a ,  $b);
	print_r($c);
	输出：	
	Array
	(
	    [green] => avocado
	    [red] => apple
	    [yellow] => banana
	)

**array_flip**是将数组的键和值对调，`array array_flip  ( array $trans  )`，注意 trans  中的值需要能够作为合法的键名，例如需要是 integer  或者 string 。如果值的类型不对将发出一个警告，并且有问题的键／值对将不会反转。

如果同一个值出现了多次，则最后一个键名将作为它的值，所有其它的都丢失了。 
	














