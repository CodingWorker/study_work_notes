#快速打造自己的MVC框架

M:Model--模型
V:View--视图
C：Controller--控制器

**MVC的关键**：从视图层分发业务逻辑

基本的url：http://bestshop.com/index.php?p=admin&c=goods&a=add，当然可以被采用其他方法重写url地址，从而隐藏相关项

###这里的有些不同于http里的url的含义

- 主机名：http://bestshop.com
- 入口文件：index.php
- 传递的参数：p=admin是请求的应用，c=goods是请求的应用里的控制器，a=add是请求控制器里的的方法


##前台控制器设计

index.php--->入口文件，http请求的唯一入口文件

该单入口文件是采用apache服务器的分布式配置.htaccess实现的，在这个文件中，我们可以使用重写模块告诉apache服务器重定向到我们的单入口文件，配置如下：

	<IfModule mod_rewrite.c>
	   Options +FollowSymLinks
	
	   RewriteEngine on
	   # Send request via index.php
	
	   RewriteCond %{REQUEST_FILENAME} !-f
	
	   RewriteCond %{REQUEST_FILENAME} !-d
	
	   RewriteRule ^(.*)$ index.php/$1 [L]
	</IfModule>

其实就是开启apache的重写模块

注意：当你重写此重写这个.htaccess文件后不用重启apache文件，但是当修改apache的其他配置文件的时候要重启apache

###另：
单入口文件还会进行一些初始化的操作，并且分发路由给对应的控制器和方法

##框架实例

###目录结构

- 定义项目名称文件目录：`/bestshop`,在此文件夹下建立应用和框架文件目录
- 定义应用目录：`/application`,此文件夹下存放应用程序目录
- 定义框架目录：`/framework`，此文件夹下放置框架文件
- 定义公共资源文件夹：`/public`，此文件夹下放置公共的静态资源，如html文件、css文件和js文件等
- 定义单入口文件：`/index.php`,注意这是文件，与以上目录处于同级目录

目录结构如下：

	/bestshop
	|_ /application
	|_ /framework
	|_ /public
	|_ index.php

###在应用目录application下在创建下一集目录

/config --存放应用的配置文件
/controllers --存放应用的控制类文件
/model -- 存放应用的模型文件
/view --存放应用的视图文件

总的目录结构如下：

	/bestshop
	|_applicaton
	| 	|_config
	|    |_controllers
	|    |_model
	|    |_view
	|_framework
	|_public
	|_index.php	
		
###在application/controller文件夹下，还需要创建两个文件夹，一个为fronted，另一个为backend

	/bestshop
	|_applicaton
	| 	|_config
	|    |_controllers
	|	 |    |_frontend
	|    |    |_backend
	|    |_model
	|    |_view
	|_framework
	|_public
	|_index.php
	
###同样还需要在view创建对应的两个文件夹
总的目录结构如下图

	/bestshop
	|_applicaton
	| 	|_config
	|    |_controllers
	|	 |    |_frontend
	|    |    |_backend
	|    |_model
	|    |_view
	|    |   |_frontend
	|	 |   |_backend
	|_framework
	|_public
	|_index.php


以上两步创建的frontend能d和backend是为了处理应用的前台和后台

问题：为什么不对model文件夹做同样的操作呢?

原因是：一般在应用中，我们可以将前台和后天看做两个网站，因此对应的是连个控制器和视图，但是无论前台还是后天，我们CRUD操作的数据库对象都是一个，因此只需要一个model目录；而且对于在后台对数据做的更新，前台的数据也能立即体现此变化。

##完善框架framework目录

	/core --定义框架核心目录
	/database -- 定义数据库目录（比如数据库启动类）
	/helpers -- 定义辅助函数类
	/libraries -- 定义类库目录

总的目录结构如下：

	/bestshop
	|_applicaton
	| 	|_config
	|    |_controllers
	|	 |    |_frontend
	|    |    |_backend
	|    |_model
	|    |_view
	|    |   |_frontend
	|	 |   |_backend
	|_framework
	|       |_core
	|		|_database
	|		|_helpers
	|		|_libraries
	|_public
	|_index.php


###完善public目录

创建目录

/css -- 存放css文件
/images -- 存放图片文件
/js -- 存放js文件
/uploads -- 存放上传临时文件夹

总的目录结构如下：

	/bestshop
	|_applicaton
	| 	|_config
	|    |_controllers
	|	 |    |_frontend
	|    |    |_backend
	|    |_model
	|    |_view
	|    |   |_frontend
	|	 |   |_backend
	|_framework
	|       |_core
	|		|_database
	|		|_helpers
	|		|_libraries
	|_public
	|	 |_css
	|    |_images
	|	 |_js
	|    |uploads
	|_index.php

以上就是当前总的MVC目录结构


##实现框架核心类

###在frame/core下建立一个Framework.class.php的文件，代码如下

	//framework/core/Framework.class.php
	<?php

		class Framework{	
			
			public static function run(){
				echo "run()";
			}
		}

###在入口文件引入框架的核心文件

	//index.php

	<?php 
	//引入框架核心文件
	require './framework/Framework.class.php';
	
	Framework::run();

##继续完善Framework.class.php

    <?php 

		class Framework{
			public static function run(){
				// echo 'run()';
				self::init();
				self::autoload();
				self::dispatch();
			}
		
			private static function init(){
				//初始化方法
			}
		
			private static function autoload(){
				//自动载入类方法
			}
		
			private static function dispatch(){
				//路由分发方法
			}
		}


###完善init方法

init方法就是定义所使用的类常量，该常量代表的是文件夹的路径

	<?php 

	class Framework{
		public static function run(){
			// echo 'run()';
			self::init();
			self::autoload();
			self::dispatch();
		}
	
		private static function init(){
			//定义路径常量,路径常量在带最后的斜线
			define('DS', DIRECTORY_SEPARATOR);
			defien('ROOT', getcwd() . DS);//由于这个文件被单入口文件引入了，因此在那里执行时getcwd()是整个项目的目录
			define('APP_PATH', ROOT . 'aplication' . DS);//应用的名字可以自己设置，可以再单入口文件中写入应用的常量名如define("APP_NAME", "Application");在此处使用这个常量来定义应用路径常量
			define('FRAMEWORK_PATH', ROOT . 'framework' .DS);	
			define('PUBLIC_PATH', ROOT . 'public' . DS);
			//定义应用目录
			define('CONFIG_PATH', APP_PATH . 'config' . DS);
			define('CONTROLLER_PATH', APP_PATH . 'controllers' . DS);
			define('MODEL_PATH', APP_PATH . 'models' . DS);
			define('VIEW_PATH', APP_PATH . 'view' . DS);
			//定义框架框架相关目录
			define('CORE_PATH', FRAMEWORK_PATH . 'core' . DS);
			define('DB_PATH', FRAMEWORK_PATH . 'database' . DS);
			define('LIB_PATH', FRAMEWORK_PATH . 'libraries' . DS);
			define('HELPER_PATH', FRAMEWORK_PATH . 'helpers' . DS);
			define('UPLOAD_PATH', FRMEWORK_PATH . 'uploads' . DS);
	
			//定义平台、控制器和动作常量
			define('PLATFORM', isset($_REQUEST['p']) ? $_REQUEST['p'] : 'home');
			define('CONTROLLER', isset($_REQUEST['c']) ? $_REQUEST['c'] : 'Index');
			defie('ACTION', isset($_REQUEST['a']) ? $_REQUEST['a'] : $_REQUEST['a']);
	
			define('CURR_CONTROLLER_PATH', CONTROLLER_PATH . PLATFORM . DS);
			define('CURR_VIEW_PATH', VIEW_PATH . PLATFORM . DS);
	
			//载入核心类
			require CORE_PATH . 'controller.class.php';
			require CORE_PATH . 'Loader.class.php';
			require CORE_PATH . 'Mysql.class.php';
			require CORE_PATH . 'Model.class.php';
	
			//载入配置文件
			$GLOBALS['config'] = include CONFIG_PATH . 'config.php';
	
			//开启session
			session_start();
	
	
	
		}
	
		private static function autoload(){
	
		}
	
		private static function dispatch(){
	
		}
	}


###完善autoload方法

注册自动加载函数，使用spl_autoload_register函数

		private static function autoload(){
			//注册一个自动加载函数
			spl_autoload_register(__CLASS__, 'load');
		}
	
		//定义一个load方法实现自动加载
		//在这里的自动加载函数可以加载类、模型等
		private static function load($classname){
			if (substr($classname, -10) == 'Controller') {
				//载入类
				require_once CURR_CONTROLLER_PATH . $classname . 'class.php';
			} elseif (substr($classname, -5) == 'Model') {
				//载入模型
				require_once MODEL_PATH . $classname . 'class.php';
			}
		}


每一个框架都有自己的命名规则，我们的也不例外。对于一个控制器类，它需要被命名成类似xxxController.class.php，对于一个模型类，需要被命名成xxModel.class.php。为什么在使用一个框架的时候你需要遵守它的命名规则呢？自动加载就是一条原因。


###完善dispatch方法

该方法主要处理路由/分发，其实就是从url地址读入参数并分发，调用指定控制器中的指定动作

	private static function dispatch(){
		$controller_name = CONTROLLER . 'Controller';
		$action_name = ACTION . 'Action';
		$controller = new $controller_name;
		$controller->$action_name();
	}

在这步中，index.php将会分发请求到对应的Controller::Aciton()方法中。

#最后，此框架的核心文件Framework.php如下：

	<?php 

	class Framework{
		public static function run(){
			// echo 'run()';
			self::init();
			self::autoload();
			self::dispatch();
		}
	
		private static function init(){
			//定义路径常量,路径常量在带最后的斜线
			define('DS', DIRECTORY_SEPARATOR);
			defien('ROOT', getcwd() . DS);//由于这个文件被单入口文件引入了，因此在那里执行时getcwd()是整个项目的目录
			define('APP_PATH', ROOT . 'aplication' . DS);//应用的名字可以自己设置，可以再单入口文件中写入应用的常量名如define("APP_NAME", "Application");在此处使用这个常量来定义应用路径常量
			define('FRAMEWORK_PATH', ROOT . 'framework' .DS);	
			define('PUBLIC_PATH', ROOT . 'public' . DS);
			//定义应用目录
			define('CONFIG_PATH', APP_PATH . 'config' . DS);
			define('CONTROLLER_PATH', APP_PATH . 'controllers' . DS);
			define('MODEL_PATH', APP_PATH . 'models' . DS);
			define('VIEW_PATH', APP_PATH . 'view' . DS);
			//定义框架框架相关目录
			define('CORE_PATH', FRAMEWORK_PATH . 'core' . DS);
			define('DB_PATH', FRAMEWORK_PATH . 'database' . DS);
			define('LIB_PATH', FRAMEWORK_PATH . 'libraries' . DS);
			define('HELPER_PATH', FRAMEWORK_PATH . 'helpers' . DS);
			define('UPLOAD_PATH', FRMEWORK_PATH . 'uploads' . DS);
	
			//定义平台、控制器和动作常量
			define('PLATFORM', isset($_REQUEST['p']) ? $_REQUEST['p'] : 'home');
			define('CONTROLLER', isset($_REQUEST['c']) ? $_REQUEST['c'] : 'Index');
			defie('ACTION', isset($_REQUEST['a']) ? $_REQUEST['a'] : $_REQUEST['a']);
	
			define('CURR_CONTROLLER_PATH', CONTROLLER_PATH . PLATFORM . DS);
			define('CURR_VIEW_PATH', VIEW_PATH . PLATFORM . DS);
	
			//载入核心类
			require CORE_PATH . 'controller.class.php';
			require CORE_PATH . 'Loader.class.php';
			require CORE_PATH . 'Mysql.class.php';
			require CORE_PATH . 'Model.class.php';
	
			//载入配置文件
			$GLOBALS['config'] = include CONFIG_PATH . 'config.php';
	
			//开启session
			session_start();
	
		}
	
		private static function autoload(){
			//注册一个自动加载函数
			spl_autoload_register(__CLASS__, 'load');
		}
	
		//定义一个load方法实现自动加载
		//在这里的自动加载函数可以加载类、模型等
		private static function load($classname){
			if (substr($classname, -10) == 'Controller') {
				//载入类
				require_once CURR_CONTROLLER_PATH . $classname . 'class.php';
			} elseif (substr($classname, -5) == 'Model') {
				//载入模型
				require_once MODEL_PATH . $classname . 'class.php';
			}
		}
	
		private static function dispatch(){
			$controller_name = CONTROLLER . 'Controller';
			$action_name = ACTION . 'Action';
			$controller = new $controller_name;
			$controller->$action_name();
		}
	}

##基础Controller类

其他控制器继承自此，自framework/core下建立Controller.class,php,这里将基础控制器命名为Controller

	class Controller{
		protected $loader;
	
		public function __construct(){
	
			$this->loader = new Loader();
	
		}
	
		public function redirect($url, $wait = 0)(){
	
			if ($wait ==0) {
				header('Location:' . $url);
			} else {
				include CURR_VIEW_PATH . 'message.html';
			}
	
			exit;
		}
	}


基础控制器有一个变量$loader，它是Loader类的实例化（后面介绍）。准确的说，`$this->loader`是一个变量指向了被实例化的Load类。在这里我不过多的讨论，但是这的确是一个非常关键的概念。我遇到过一些PHP开发者相信在这个语句之后：

	$this->loader = new Loader();
	
`$this->load`是一个对象。不，它只是一个引用。这是从Java中开始使用的，在Java之前，在C++和Objective C中被称为指针。引用是个封装的指针类型。


###加载类

在framework.class.php中，我们已经封装好了**应用的控制器和模型**的自动加载。但是如何自动加载在framework目录中的类呢？现在我们可以新建一个Loader类，它会加载framework目录中的类和函数。当我们加载framework类时，只需要调用这个Loader类中的方法即可。

	class Loader{

	    // Load library classes
	
	    public function library($lib){
	
	        include LIB_PATH . "$lib.class.php";
	
	    }
	
	
	    // loader helper functions. Naming conversion is xxx_helper.php;
	
	    public function helper($helper){
	
	        include HELPER_PATH . "{$helper}_helper.php";
	
	    }
	
	}


##封装模型

我们需要下面**两个类来封装基础Model类**：

- Mysql.class.php - 在framework/database下建立，它封装了**数据库的链接和一些基本查询方法**。
- Model.class.php - framework/core下建立，基础模型类，**封装所有的CRUD方法**。



###Mysql.class.php ：
	
	<?php 

	/*
	 *===============================================
	
	 * framework/database/Mysql.class.php
	 * 数据库操作类
	
	 *==============================================
	*/

	class Mysql{
	
		//先定义一个用来接受mysqli对象的变量
		protected $mysqli;
		//先定义一个连接变量，设置为false
		protected $conn = false;
		//定义一个sql变量来接受sql语句
		protected $sql;
	
		//构造函数 ，连接数据库服务器，选择数据库，设置字符集
		//参数配置项中是数据库的一些配置信息
		public function __construct($config = []){
			$host = isset($config['host']) ? $config['host'] : 'localhost';
			$user = isset($config['user']) ? $config['user'] : 'root';
			$password = isset($config['password']) ? $conifg['password'] : '';
			$port = isset($config['port']) ? $config['port'] : '3306';
			$dbname = isset($config['dbname']) ? $config['dbname'] : '';
			$charset = isset($config['charset']) ? $config['charset'] : 'utf8';
	
			//连接数据库
			$this->mysqli = mysqli($host, $user, $password, $port);
			$this->conn = $mysqli->connect_errno;
			if ($this->conn !=0) {
				die('Error' . $this->connect_error);
			}
			//选择数据库
			$this->select_db($dbname);
			//设置字符集
			$this->set_charset($charset);
		}
	
		//执行sql语句方法
		public function query($sql){
			$this->sql = $sql;
			//将sql语句写进日志
			$str = $sql . ' [' .date('Y-m-d H:i:s') . ']' .PHP_EOL;
			file_put_contents('log.txt', $str, FILE_APPEND);
	
			//执行查询语句
			$result = $this->mysqli->query($sql);
			if (! $result) {
				die($this->mysqli->errno() . ':' . $this->mysqli->error());
			}
	
			return $result;
		}
	
		//得到第一条记录的第一个字段
		public function getOne($sql){
			$result = $this->mysqli->query($sql);
			$row = $result->fetch_array(MYSLQI_NUM);
			if ($row) {
				return $row[0];
			} else {
				return false;
			}
		}
	
		//获得一次查询记录
		public function getRow($sql){
	
			$result = $this->mysqli->query($sql);
			if ($result) {
				$row = $result->fetch_row();
				return $row;
			} else {
				return false;
			}
		}
	
		//获得所有查询记录
		public function getAll($sql){
	
			$result = $this->mysqli->query($sql);
			if ($result) {
				$rows = $result->fetch_assoc();
				return $rows;
			} else {
				return false;
			}
	
		//获得查询结果的第一列的值
		public function getCol($sql){
			$result = $this->mysqli->query($sql);
			if ($result) {
				$colValue = $result->fetch_field();
				return $colValue;
			} else {
				return false;
			}
			
	
		}
	
		//获得最后一个插入的id
			public function getInsertId(){
				return $this->mysqli->insert_id;
			}
			
		}
	
	}
	

###Model.class.php

	<?php 
	
	//framewor/core/Model.class.php
	//Base Model Class
	
	class Model{
	
		protected $db;//数据库连接对象
		protected $table;//表名称
		protected $field = [];//字段名数组
	
		//构造函数
		public function __construct($table){
	
			//准备数据库配置
			$dbconfig['host'] = $GLOBALS['config']['host'];
			$dbconfig['user'] = $GLOBALS['config']['user'];
			$dbconfig['password'] = $GLOBALS['config']['password'];
			$dbconfig['dbname'] = $GLOBALS['config']['dbname'];
			$dbconfig['port'] = $GLOBALS['config']['port'];
			$dbconfig['charset'] = $GLOBALS['config']['charset'];
	
			//连接数据库
			$this->db = new mysqli($dbconfig);
			$this->table = $GLOBALS['config']['prefix'] . $table;
			$this->getFields();
		}
	
		//获得表的字段名
		public function getFields(){
	
			$sql = 'DESC' . $this->table;
			$result = $this->db->getAll($sql);
			foreach ($result as $v) {
				$this->fields[] = $v['Field'];
				if ($v['Key'] == 'PRI') {
					//获得主键字段
					$pk = $v['Field'];
				}
	
				if (isset($pk)) {
					$this->fields['pk'] = $pk;
				}
			}
	
		}
	
		//插入表记录
		public function insert($list){
	
			$field_list = '';
			$value_list = '';
	
			foreach ($list as $k => $v) {
				if (in_array($k, $this->fields)) {
					$fields_list .= '`' . $k . '`' . ',';
					$value_list .= '"' . $v . '"' .',';
				}
			}
	
			//移除最右边的逗号
			$field_list = rtrim($field_list, ',');
			$value_list = rtrim($value_list, ',');
	
			//准备sql语句
			$sql = 'INSERT INTO `{$this->table}` ({$field_list}) VALUES ({$value_list})';
	
			//执行插入语句
			if ($this->db->query($sql)) {
				//执行此步说明插入成功
				return $this->db->getInsertId();
			} else {
				//插入操作失败
				return false;
			}
		}
	
		//更新操作
		public function update($list){
			$uplist = '';//要更新的字段
			$where = 0;//更新条件
	
			foreach ($list as $k => $v) {
				//只有在此字段中的才是正确的更新操作
				if (in_arry($k, $this->fields)) {
					//如果字段为主键
					if ($k ==$this->fields['pk']) {
						//更新字段存在主键就以主键为条件
						$where = '`$k = $v';
					} else {
						//更新的字段不包含主键
						$uplist .= '`$k` = $v' . ',';
					}
				}
			}
	
			//去掉字段最右面的逗号
			$uplist = rtrim($uplist, ',');
	
			//准备sql语句
			$sql = 'UPDATE `{$this->table}` SET {$uplist} WHERE {$where}';
	
			if ($this->db->query($sql)) {
				//如果成功返回受影响的行数
				if ($rows = $this->db->affected_rows) {
					return $rows;
				} else {
					//没有受影响的行数，从而没有执行更新操作
					return false;
				}
			} else {
				//没有执行
				return false;
			}
		}
	
		//删除操作，需要传递主键
		public function delete($pk){
	
			$where = 0;//删除条件
	
			if (is_array($ok)) {
				//是数组
				$where = '`{$this->fields["pk"]}` in (' . implode("," ,$pk) . ')';
			} else {
				//如果pk只是一个字符串
				$where = '`{$this->fields["pk"]}=$pk';
			}
	
			//准备sql语句
			$sql = 'DELETE FROM `{$this->table}` WHERE $where';
			if ($this->db->query($sql)) {
				//如果成功返回受影响的函数
				if ($rows = $this->db->affected_rows) {
					return $rows;
				} else {
					//如果没有受影响的行数则返回false
					return false;
				}
			} else {
				//sql语句执行错误返回false
				return false;
			}
		}
	
		//基于主键查询
		public function selectByPk($pk){
	
			$sql = 'SELECT * FROM `{$this->table}` WHERE `{$this->fields["pk"]=$pk';
			return $this->db->getRows($sql);
	
		}
	
		//获得数据的总量
		public function total(){
	
			$sql = 'SELECT COUNT(*) FROM {$this->table}';//这样执行不好
			return $this->db->getOne($sql);
		}
	
		//获得指定页码的信息
		public function pageRows($offset, $limit, $where = ''){
	
			if ($where == '') {
				$sql = 'SELECT * FROM {$this->table} limit $offset, $limit';
			} else {
				$sql = 'SELECT * FROM {$this->table} WHERE $where limit $offset, $limit';
			}
	
			return $this->db->getAll($sql);
		}
	
	}
	

##实例化模型

在应用application下创建一个user模型，对应数据库里的user表

	<?php
	
	//application/models/UserModel.class.php
	
	class UserModel extends Model{
	
		public function getUsers(){
	
			$sql = 'SELECT * FROM $this->table';
			$users = $this->db->getAll($sql);
	
			return $users;
		}
	}


####后台的indexController

	<?php

	//application/controllers/admin/IndexController.class.php
	
	class IndexController extends BaseController{
	
		public function mainAction(){
	
			include CURR_VIEW_PATH . 'main.html';
	
			//加载Capthcha 类
			$this->loader->library('Captcha');
			$captcha = new Captcha;
			$captcha->hello();
			$userModel = new UserModel('user');
			$users = $userModel->getUsers();
		}
	
		public function indexAction(){
	
			$userModel = new UserModel('user');
			$user = $userModel->getUsers();
	
			//加载视图
			include CURR_VIEW_PATH . 'index.html';
		}
	
		 public function menuAction(){
	
	        include CURR_VIEW_PATH . "menu.html";
	
	    }
	
	    public function dragAction(){
	
	        include CURR_VIEW_PATH . "drag.html";
	
	    }
	
	    public function topAction(){
	
	        include CURR_VIEW_PATH . "top.html";
	
	    }
	
	}

控制器实例化了模型类，并将得到的数据传给了视图中的模板，从而在浏览器中就能看到数据了

