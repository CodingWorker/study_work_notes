<?php 	
//单文件上传
// print_r($_FILES);
if (empty($_FILES)) {
	die('上传文件出错!');
}
$files = $_FILES['files'];
if ($files['error'] != 0) {
	die('上传文件出错!');
}
$fileName = $files['name'];
$fileTmpName = $files['tmp_name'];
$fileSize = $files['size'];
$fileExten = strchr($fileName,'.');
$fileTypeArr = ['.txt', '.jpg', 'jpeg', 'png', 'gif'];
$max_upload_filesize = 8000;
if (!in_array($fileExten, $fileTypeArr)) {
	die('文件类型不正确!');
}
if (!$fileSize>$max_upload_filesize) {
	die('文件太大了!');
}
if (!is_uploaded_file($fileTmpName)) {
	die('上传文件出错');
}
$dest_folder = 'E:\test';
$fileNameNew = $dest_folder . '/' . time() . $fileExten;
if (move_uploaded_file($fileTmpName, $fileNameNew)) {
	echo '上传文件成功!';
} else {
	die('上传文件失败!');
}