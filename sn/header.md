#PHP的header函数

	void  header  ( string $string  [, bool $replace  = true  [, int $http_response_code  ]] )
	header函数是用来发送一个原生的HTTP头，要注意的是，header函数要在任何时间输出被发送之前设置，这些输出包括普通的html标签，文件的空白行或者php代码的空白
	没有返回值

非常常见的错误是在header之前使用了include或者require函数，方程或者使用了会引入另一个文件的函数

header函数的作用是给客户端发送头信息

头信息的作用主要有：
	
- 跳转
	
	header('Location:http://www.baidu.com‘);//这个跳转只有浏览器知道，用户看不到，跳转是立即的

- 指定网页内容

	 同样一个XML文件，如果头信息中指定：Content-type: application/xml 的话，浏览器会将其按照XML文件格式解析。但是，如果头信息中是：Content-type: text/xml 的话，浏览器就会将其看作存文本解析。（浏览器不是按照扩展名解析文件的，而是根据头信息来解析文件的）

- 附件

	header('Content-Disposition:attachment;filename=xxx');

**这样设置后打开该网页就自动下载**


示例：
		
	<?php
	 header ( 'Location: http://www.example.com/' );
	 exit;
	 ?>

##参数
###string

- 第一种
	
	header('HTTP/1.1 404 NOT FOUND');

该语句向浏览器发送状态码404，可以再network看到，从而可以设置404页面的样式，一般用在apache服务器找不到文件时调用的脚本

- 第二种即重定向Location

	<?php
	header ( "Location: http://www.baidu.com/" );  /* Redirect browser */
	
	/* Make sure that code below does not get executed when we redirect. */
	 exit;
	 ?> 

###replace参数

The optional replace  parameter indicates whether the header should replace a previous similar header, or add a second header of the same type. By default it will replace, but if you pass in FALSE  as the second argument you can force multiple headers of the same type. For example: 

第二个可选的参数表示使得这个header信息代替之前的一个相似的header信息，或者增加一个相似的类型的第二个头信息，默认情况下它会替换，但是如果设置第二个参数为false则强制设置多个相似类型的头信息

	<?php
	header ( 'WWW-Authenticate: Negotiate' );
	 header ( 'WWW-Authenticate: NTLM' ,  false );//强制加上两个信息
	 ?> 

	<?php
	header ( 'WWW-Authenticate: Negotiate' );
	 header ( 'WWW-Authenticate: NTLM');//默认替换前一个信息
	 ?> 


###http_replace_code参数
Forces the HTTP response code to the specified value. Note that this parameter only has an effect if the string  is not empty. 

强制设置http返回状态码，这个参数只有在第一个参数不为空的时候才起作用

###应用举例

**强制浏览器不进行缓存**

	<?php

	// Date in the past
	
	header("Expires: Mon, 26 Jul 1997 05:00:00 GMT");
	
	header("Cache-Control: no-cache");
	
	header("Pragma: no-cache");
	?>

例1：使浏览器重定向到PHP官方网站

- 立即重定向

	<?PHP
	Header("Location: http://www.php.net";);
	exit;   //在每个重定向之后都必须加上“exit",避免发生错误后，继续执行。
	?>
	
- 隔一段时间重定向

	<?php
	header("refresh:3;url=http://axgle.za.net");
	print('正在加载，请稍等...<br>三秒后自动跳转~~~');
	
	//header重定向 就等价于替用户在地址栏输入url
	?> 

例2：禁止页面在IE中缓存

**要使用者每次都能得到最新的资料，而不是 Proxy 或 cache 中的资料，可以使用下列的标头**

	<?PHP
	header( 'Expires: Mon, 26 Jul 1997 05:00:00 GMT' );
	header( 'Last-Modified: ' . gmdate( 'D, d M Y H:i:s' ) . ' GMT' );
	header( 'Cache-Control: no-store, no-cache, must-revalidate' );
	header( 'Cache-Control: post-check=0, pre-check=0', false );
	header( 'Pragma: no-cache' ); //兼容http1.0和https
	?>
	CacheControl = no-cache
	Pragma=no-cache
	Expires = -1

Expires是个好东东，如果服务器上的网页经常变化，就把它设置为-1，表示立即过期。如果一个网页每天凌晨1点更新，可以把Expires设置为第二天的凌晨1点。
当HTTP1.1服务器指定CacheControl = no-cache时，浏览器就不会缓存该网页。

旧式 HTTP 1.0 服务器不能使用 Cache-Control 标题。所以为了向后兼容 HTTP 1.0 服务器，IE使用Pragma:no-cache 标题对 HTTP 提供特殊支持。

如果客户端通过安全连接 (https://) 与服务器通讯，且服务器在响应中返回 Pragma:no-cache 标题，则 Internet Explorer 不会缓存此响应。

注意：Pragma:no-cache 仅当在安全连接中使用时才防止缓存，如果在非安全页中使用，处理方式与 Expires:-1 相同，该页将被缓存，但被标记为立即过期。

http-equiv meta标记：

在html页面中可以用http-equiv meta来标记指定的http消息头部。老版本的IE可能不支持html meta标记，所以最好使用http消息头部来禁用缓存。

例3:发送状态码

	header('http/1.1 404 Not Found');//必须严格按照此方式来写

第一部分为HTTP协议的版本(HTTP-Version)；第二部分为状态代码(Status)；第三部分为原因短语(Reason-Phrase)。


例4：指定附件

html标签 就可以实现普通文件下载。如果为了保密文件，就不能把文件链接告诉别人，可以用header函数实现文件下载。

	<?php
	header("Content-type: application/x-gzip");
	header("Content-Disposition: attachment; filename=文件名");
	header("Content-Description: PHP3 Generated Data");
	?>

###在header函数之前输入内容

一般来说在header函数前不能输出html内容，类似的还有`setcookie()` 和 `session `函数，这些函数**需要在输出流中增加消息头部信息**。如果在header()执行之前有echo等语句，当后面遇到header()时，就会报出 “Warning: Cannot modify header information - headers already sent by ….”错误。就是说在这些函数的前面不能有任何文字、空行、回车等，而且最好在header()函数后加上exit()函数。例如下面的错误写法，在两个 php代码段之间有一个空行：
	
	//some code here
	?>
	//这里应该是一个空行
	header(”http/1.1 403 Forbidden”);
	exit();
	?>

>原因是：PHP脚本开始执行时,它可以同时发送http消息头部(标题)信息和主体信息. http消息头部(来自 header() 或 SetCookie() 函数)**并不会立即发送**,相反,它被保存到一个列表中. **这样就可以允许你修改标题信息**,包括缺省的标题(例如 Content-Type 标题）.但是,一旦脚本发送了任何非标题的输出（例如,使用 HTML 或 print() 调用),**那么PHP就必须先发送完所有的Header,然后终止 HTTP header**.而后继续发送主体数据.**从这时开始,任何添加或修改Header信息的试图都是不允许的,并会发送上述的错误消息之一**。

**解决办法：**

修改php.ini打开缓存(output_buffering),或者在程序中使用缓存函数ob_start()，`ob_end_flush()`等。原 理是：`output_buffering`被启用时,在脚本发送输出时，PHP并不发送HTTP header。相反，它将此输出通过管道（pipe）输入到动态增加的缓存中（只能在PHP 4.0中使用，它具有中央化的输出机制）。你仍然可以修改/添加header，或者设置cookie，因为header实际上并没有发送。当全部脚本终止 时，PHP将自动发送HTTP header到浏览器，然后再发送输出缓冲中的内容。


##更多的示例


	<?php
	// ok
	header('HTTP/1.1 200 OK');
	//设置一个404头:
	header('HTTP/1.1 404 Not Found');
	//设置地址被永久的重定向
	header('HTTP/1.1 301 Moved Permanently');
	//转到一个新地址
	header('Location: http://www.example.org/');
	//文件延迟转向:
	header('Refresh: 10; url=http://www.example.org/');
	print 'You will be redirected in 10 seconds';
	//当然，也可以使用html语法实现
	// <meta http-equiv="refresh" content="10;http://www.example.org/ />
	// override X-Powered-By: PHP:
	header('X-Powered-By: PHP/4.4.0');
	header('X-Powered-By: Brain/0.6b');
	//文档语言
	header('Content-language: en');
	//告诉浏览器最后一次修改时间
	$time = time() - 60; // or filemtime($fn), etc
	header('Last-Modified: '.gmdate('D, d M Y H:i:s', $time).' GMT');
	//告诉浏览器文档内容没有发生改变
	header('HTTP/1.1 304 Not Modified');
	//设置内容长度
	header('Content-Length: 1234');
	//设置为一个下载类型
	header('Content-Type: application/octet-stream');
	header('Content-Disposition: attachment; filename="example.zip"');
	header('Content-Transfer-Encoding: binary');
	// load the file to send:
	readfile('example.zip');
	// 对当前文档禁用缓存
	header('Cache-Control: no-cache, no-store, max-age=0, must-revalidate');
	header('Expires: Mon, 26 Jul 1997 05:00:00 GMT'); // Date in the past
	header('Pragma: no-cache');
	//设置内容类型:
	header('Content-Type: text/html; charset=iso-8859-1');
	header('Content-Type: text/html; charset=utf-8');
	header('Content-Type: text/plain'); //纯文本格式
	header('Content-Type: image/jpeg'); //JPG图片
	header('Content-Type: application/zip'); // ZIP文件
	header('Content-Type: application/pdf'); // PDF文件
	header('Content-Type: audio/mpeg'); // 音频文件
	header('Content-Type: application/x-shockwave-flash'); //Flash动画
	//显示登陆对话框
	header('HTTP/1.1 401 Unauthorized');
	header('WWW-Authenticate: Basic realm="Top Secret"');
	print 'Text that will be displayed if the user hits cancel or ';
	print 'enters wrong login data';
	?>