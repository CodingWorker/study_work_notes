#编码规范

1. 不包含BOM头

2. 驼峰命名法,类的开头要大写

3. 类中的常量大写

4. 方法名必须符合驼峰命名法，开头小写

5. PHP 5.3及以后的代码必须使用正式的命名空间,之前的版本可以使用伪命名空间的写法，即使用下滑线来区分

6. 常量必须大写，单词间一下划线来分隔
	
		如 const VAR
		   const VAR_DOR


7. 类的属性可以使用小写，词间一下滑线分隔

		如 public $a;
		   public $sub_title

8. 代码使用4个空格符来缩进

9. 命名空间和use声明语句后必须有一个空白行

10. 类的属性和方法必须添加访问控制修饰符，abstract和final必须声明在访问修饰符之前，而static必须生命在访问修饰符之后

11. 符合规范的代码

		<?php
		namespace Vendor\Package;
		
		use FooInterface;
		use BarClass as Bar;
		use OtherVendor\OtherPackage\BazClass;
		
		class Foo extends Bar implements FooInterface
		{
		    public function sampleFunction($a, $b = null)
		    {
		        if ($a === $b) {
		            bar();
		        } elseif ($a > $b) {
		            $foo->bar($arg1);
		        } else {
		            BazClass::bar($arg2, $arg3);
		        }
		    }
		
		    final public static function bar()
		    {
		        // method body
		    }
		}
		?>

12. 纯PHP代码文件必须省略最后的结束标签?>

13. 纯PHP代码文件必须以一个空白行作为结束，即写到最后在回车一行

14. 使用4个空格进行缩进，尽量不用tab键，除非tab键严格缩进4个空格，不过空格缩进灵活性更好

15. PHP的关键字要小写，常量也必须小写，如true/false/null

16. name use关键字规范代码

		<?php
		namespace Vendor\Package;
		
		use FooClass;
		use BarClass as Bar;
		use OtherVendor\OtherPackage\BazClass;
		
		// ... additional PHP code ...

17. 类的开始花括号必须独占一行，结束花括号也必须在类主体后独占一行，规范代码：

		class ClassName extends ParentClass implements \ArrayAccess, \Countable
		{
		    // constants, properties, methods
		}

18. implements的继承列表也可以分成多行，如

		class ClassName extends ParentClass implements
		    \ArrayAccess,
		    \Countable,
		    \Serializable
		{
		    // constants, properties, methods
		}

19. 不要使用下划线来区分方法和属性是protected还是private,方法名称后一定不能有空格，开始花括号要独占一行，结束花括号也必须在方法主体后单独成一行，参数左括号和右括号之前不能有空格
**规范案例**

		<?php
		namespace Vendor\Package;
		
		class ClassName
		{
		    public function fooBarBaz($arg1, &$arg2, $arg3 = [])
		    {
		        // method body
		    }
		}

20. 参数列表中每个逗号后面必须有空格，而逗号之前则不能有空格，默认参数必须放在参数列表的末尾

		<?php
		namespace Vendor\Package;
		
		class ClassName
		{
		    public function foo($arg1, &$arg2, $arg3 = [])
		    {
		        // method body
		    }
		}	

		

21. abstract和final以及static的放置

		<?php
		namespace Vendor\Package;
		
		abstract class ClassName
		{
		    protected static $foo;
		
		    abstract protected function zim();
		
		    final public static function bar()
		    {
		        // method body
		    }
		}

22. 控制结构的关键字后必须有一个空格，右括号后也开始花括号间必须有一个空格

		<?php
		if ($expr1) {
		    // if body
		} elseif ($expr2) {
		    // elseif body
		} else {
		    // else body;
		}

		应该使用关键词 elseif 代替所有 else if ，以使得所有的控制关键字都像是单独的一个词。


23. switch和case，如果存在非空的case直穿语句，主体里必须有类似//no break的注释

		<?php
		switch ($expr) {
		    case 0:
		        echo 'First case, with a break';
		        break;
		    case 1:
		        echo 'Second case, which falls through';
		        // no break
		    case 2:
		    case 3:
		    case 4:
		        echo 'Third case, return instead of break';
		        return;
		    default:
		        echo 'Default case';
		        break;
		}

##语句规范示例

- while语句和do while语句

		<?php
		while ($expr) {
		    // structure body
		}

- for语句

		<?php
		for ($i = 0; $i < 10; $i++) {
		    // for body
		}	

- foreach语句

		<?php
		foreach ($iterable as $key => $value) {
		    // foreach body
		}

- try-catch语句

		<?php
		try {
		    // try body
		} catch (FirstExceptionType $e) {
		    // catch body
		} catch (OtherExceptionType $e) {
		    // catch body
		}

- 闭包
	
		<?php
		$closureWithArgs = function ($arg1, $arg2) {
    		// body
		};
		
		$closureWithArgsAndVars = function ($arg1, $arg2) use ($var1, $var2) {
		    // body
		};

		$longArgs_noVars = function (
		    $longArgument,
		    $longerArgument,
		    $muchLongerArgument
		) {
		   // body
		};
		
		$noArgs_longVars = function () use (
		    $longVar1,
		    $longerVar2,
		    $muchLongerVar3
		) {
		   // body
		};
		
		$longArgs_longVars = function (
		    $longArgument,
		    $longerArgument,
		    $muchLongerArgument
		) use (
		    $longVar1,
		    $longerVar2,
		    $muchLongerVar3
		) {
		   // body
		};

##日志接口规范



##autoload自动载入类

###一个完整的类名必须具有以下结构

		\<命名空间>(\<子命名空间>)*\<类名>

- 完整的类名必须有一个顶级命名空间
- 完整的类名可以有一个或多个子命名空间
- 完整的类名必须有一个最终类名
- 完整的类名中任意一部分的中的下划线都是没有特殊含义的
- 完整的类名可以由任意大小写字母组成
- 所有类名都必须是大小写敏感的

###当根据完整的类名载入相应的文件
- 完整的类名中，去掉最前面的命名空间分隔符，前面连续的一个或多个命名空间和子命名空间，作为“命名空间前缀”，其必须与至少一个“文件基目录”相对应；
- 紧接命名空间前缀后的子命名空间必须与相应的”文件基目录“相匹配，其中的命名空间分隔符将作为目录分隔符。
- 末尾的类名必须与对应的以 .php 为后缀的文件同名。
- 自动加载器（autoloader）的实现一定不能抛出异常、一定不能触发任一级别的错误信息以及不应该有返回值。

##正确的例子:


下表展示了符合规范完整类名、命名空间前缀和文件基目录所对应的文件路径。

| 完整类名                       | 命名空间前缀         | 文件基目录                | 文件路径
| ----------------------------- |--------------------|--------------------------|-------------------------------------------
| \Acme\Log\Writer\File_Writer  | Acme\Log\Writer    | ./acme-log-writer/lib/   | ./acme-log-writer/lib/File_Writer.php
| \Aura\Web\Response\Status     | Aura\Web           | /path/to/aura-web/src/   | /path/to/aura-web/src/Response/Status.php
| \Symfony\Core\Request         | Symfony\Core       | ./vendor/Symfony/Core/   | ./vendor/Symfony/Core/Request.php
| \Zend\Acl                     | Zend               | /usr/includes/Zend/      | /usr/includes/Zend/Acl.php


注意：实例并**不**属于规范的一部分，且随时**会**有所变动。



