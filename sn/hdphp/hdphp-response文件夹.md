response响应处理类

功能：

- 发送状态码，使用了header函数
- Ajax输出数据类型转换，包括text html xml json,然后将数据转换并发送头信息告诉Content-Type


**`json_encode`函数**，将数组转换为json数据

	$arr = ['a'=>1, 'b'=>2, 'c'=>3, 'd'=>4, 'e'=>5];
	print_r(json_encode($arr));