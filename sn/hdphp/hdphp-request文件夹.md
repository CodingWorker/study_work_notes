request文件是用来处理请求的类

功能：

- 获取变量
- 获取客户端IP:通过$_SERVER
- 判断是否为https请求，也是通过$_SERVER
- 手机判断，通过$_SERVER['HTTP_USER_AGENT']/$_SERVER['ALL_HTTP']等
- 

**ip2long**转换一个包含IPv4网络协议的带有点的地址为一个恰当的地址的整型

	int ip2long  ( string $ip_address  )
	这个函数将一个网络标准格式的带点的标准网络格式转换为一个ipv4网络地址的整型
	返回一个ipv4地址或者在出错误时返回false
	
	$ip = getipbyname('www.baidu.com');\
	echo ip2long($ip);//1945097072


	