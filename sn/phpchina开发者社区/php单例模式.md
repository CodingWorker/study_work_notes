#PHP单例模式开发

##单例模式的特点
1. 某个类只能有一个实例
2. 这个类必须自行创建他自己的实例（即类内的方法或者属性来实例化自己的类）
3. 这个类必须自行向整个系统提供这个实例

##单例模式的要点

1. $_instance必须声明为静态的私有变量
2. 构造函数和克隆函数必须声明为私有的，这是为了防止外部程序new类从而失去单例模式的意义，构造函数声明为私有的从而就不可以在外部new实例化类了（会产生不能访问私有方法的错误）
3. getinstance()方法必须声明为公有的，必须调用此方法以返回唯一实例的引用
4. ::操作符只能访问静态变量或者静态函数
5. PHP的单例模式是相对而言的，因为PHP的解释运行机制使得每个PHP页面被解析执行后，所有的相关资源都会被回收。

在PHP中，所有的变量都是页面级的，即在页面执行完毕后自动清空。

不过，在实际的应用中，同一个页面中可能会存在多个业务逻辑，这时单例模式就起到了很重要得作用。可以避免重复的new对象（new对象会消耗内存资源），所以PHP的单例模式相对的。
（**其他业务可能不需要单例模式，只有在某一个页面里面需要多次重复new同一类时才适合使用单例模式**）。

	<?php 
	
	class Person{
	
		private $name;
		private $sex;
		private $age;
		private $height;
		private $weight;
	
		public static $_instance = null;
	
		//为了定义单例模式的类必须将构造函数申明为私有的
		private function __construct(){
	
			$this->name = 'zhangsan';
			$this->sex = '男';
			$this->age = 23;
			$this->heigth = '170cm';
			$this->weight = '70kg';
		}
	
		private function __clone(){
	
		}
	
		public static function getInstance(){
			if (!self::$_instance instanceof Person) {//这里写Person和self都可以
				echo '不是类实例';
				self::$_instance = new self;//这里写Person和self都可以
			} else {
				echo '是类的实例';
			}
	
			return self::$_instance;
		}
	
		public function getName(){
			return $this->name;
		}
	
		public function getSex(){
			return $this->sex;
		}
	
		public function getAge(){
			return $this->age;
		}
	}
	
	$person = Person::getInstance();
	echo $person->getAge();	


###单例模式的优点：
- 避免了大量的new操作，new操作会消耗内存和系统资源


###单例模式的缺点
- PHP的变量都是页面级的，当每次页面执行完毕后就会被清空，因此单例模式没有意义
- 但是当在一个页面里存在多个应用场景的时候，需要大量的new操作，此时单例模式的就比较有意义


##适用场合

###传统编码：

	在场景1
	$db = new DB();
	$db->addUserInfo();

	在场景2
	$db = new DB();
	$db->updataData();
这时就需要做大量的new 操作

###单例模式编码

	在数据库处理层
	getInstance返回数据库
	
	在场景1
	$db = DB::getInstance();
	$db->addUserInfo()

	在场景2
	$db = DB::getInstance();
	$db->updateData()

此时都使用了数据库对象，但只有一次new，getInstance()判断$_instance是否实例化了类（在第一次没有则将类实例化并赋值给$_instance），没有就实例化，有则直接返回示例话的对象。

##单例模式实现的核心

- 要有存储类实例化对象的私有化静态变量$_instance
- 构造函数和克隆函数必须声明为私有，放置外部new实例化或者克隆(会生成一个新的对象，设置为私有后则会报错)；而复制对象则执行的是一个对象目标
- 必须提供一个静态的方法getInstance实现类的实例化并返回该实例化对象