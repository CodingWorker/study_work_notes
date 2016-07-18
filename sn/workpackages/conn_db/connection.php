<?php 
//检查是否装载mysqli扩展
$dbexten = 'mysqli';
if (!in_array($dbexten, get_loaded_extensions())) {
	die('请加载mysqli扩展!');
}
$mysqli = @new Mysqli('localhost', 'root', '');
$conn = $mysqli->connect_errno;
if ($conn !=0) {
	die('Connection Error:' . $mysqli->connect_error);
}
//设置字符集
$mysqli->set_charset('utf8');
//选择操作的数据库
$mysqli->select_db('test');
//准备sql语句
$sql = 'select * from user';
//获取结果
$result = $mysqli->query($sql);
if ($result) {
	print_r($result->fetch_array());
} else {
	die('查询失败!');
}