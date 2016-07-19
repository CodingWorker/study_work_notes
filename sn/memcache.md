1. get值的$flag
		
		$mem=new Memcache();
		$conn=$mem->connect('localhost',11211);
		// $mem->set('mykey',"haha",0,0);
		// $mem->set('mykey1',"haha",0,0);
		$flag=false;
		print_r($mem->get('mykey1',$flag));//如果mykey1被找到了，$flag会改变，可能改变为0
		print_r($mem->get('mykey3',$flag));//如果mykey2没有被找到，则$flag不会改变
		var_dump($flag);

	参考：php学习手册

#memcache类方法

1. Memcache::add — 增加一个条目到缓存服务器

	bool Memcache::add  ( string $key  , mixed  $var  [, int $flag  [, int $expire  ]] )
	方法在缓存服务器之前不存在 key 时， 以 key 作为key存储一个变量 var 到缓存服务器。
	key:将要分配给变量的key
	var：将要被储存的变量，字符串和整型被以原文存储，其他类型序列化后存储
	flag:使用MEMCACHE_COMPRESSED标记对数据进行压缩（使用zlib)
	expire:当前写入缓存的数据失效时间
	成功返回true,失败返回false

2. Memcache::addServer — 向连接池中添加一个memcache服务器

		bool Memcache::addServer  ( string $host  [, int $port  = 11211  [, bool $persistent  [, int $weight  [, int $timeout  [, int $retry_interval  [, bool $status  [, callback  $failure_callback  [, int $timeoutms  ]]]]]]]] )
		该方法打开的连接将会在脚本执行结束后自动关闭，也可以使用close方法手动关闭。
		使用该方法的时候，只是增加服务器到连接池，网络连接并不会建立，而是等到真正使用的时候才建立。因此在连接池中加入大量的服务器是没有开销的，因为他们不可能被立即使用。
		persist:控制是否持久化连接，默认为True
		weight:为服务器创建的桶的数量，用来控制服务器被选中的权重，单个服务器被选中的概率是相对于所有服务器weight的总和而言的。
		timeout:连接持续时间，过长的连接时间可能会导致失去所有的缓存优势。
		retry_interval：服务器连接失败时重试的时间，默认值为15秒。如果设置为-1则不重试。
		status：控制此服务器是否可以被标记为在线状态。
		failure_callback ：允许用户指定一个运行时发生错误的毁掉函数。
		成功返回true,失败返回false

		$memcache=new Memcache();
		$conn=$memcache->connect('localhost',11211);
		if(!$conn){
			die('连接错误!');
		}
		echo $memcache->get('key1');
		$add_flag=$memcache->addServer('192.168.15.129', 11211);
		var_dump($add_flag);

3. Memcache::close — 关闭memcache连接

		bool Memcache::close  ( void )
		关闭memcache服务端的连接，这个函数不会关闭持久化连接，持久化连接仅仅会在web服务器关机/重启时关闭。
		成功返回true,失败返回false

		$memcache=new Memcache();
		$conn=$memcache->connect('localhost',11211);
		if(!$conn){
			die('连接错误!');
		}
		$memcache->close();
		var_dump($memcache->get('key1'));// false

4. Memcache::connect — 打开一个memcached服务端连接

		bool Memcache::connect  ( string $host  [, int $port  [, int $timeout  ]] )
		建立一个到memcached服务端的一个连接，使用该方法打开的连接在脚本结束后自动关闭，当然你也可以使用close方法手动关闭。
		
		$memcache=new Memcache();
		$conn=$memcache->connect('localhost', 11211);
		if($conn){
			$memcache->set('key1','haha');
		}
		$memcache->close();

5. Memcache::decrement — 减小元素的值

		int Memcache::decrement  ( string $key  [, int $value  = 1  ] )
		该方法将元素的值减少value,类似于increment方法
		注意：得到的新的元素的值不会小于0，不要将该方法用于压缩存储的数据，那样在使用get方法时会出错。
			  当元素不存在时会创建该key,值默认为0，并执行decement方法。
		成功返回true,失败返回false.

		$memcache=new Memcache();
		$conn=$memcache->connect('localhost',11211);
		if(!$conn){
			die('连接错误!');
		}
		$memcache->set('key1','haha');
		$memcache->set('key2',12);// 这个数可以被减
		$memcache->set('key3','12');// 这个数字字符串可以被减
		$flag1=@$memcache->decrement('key1');
		$flag2=@$memcache->decrement('key2');
		$flag3=@$memcache->decrement('key3');
		var_dump($flag1);
		var_dump($flag2);
		var_dump($flag3);
		echo $memcache->get('key1').'<br/>';
		echo $memcache->get('key2').'<br/>';
		echo $memcache->get('key3');
		输出：
		boolean false
		int 11
		int 11
		haha
		11
		11

6. Memcache::delete — 从服务端删除一个元素
		bool Memcache::delete  ( string $key  [, int $timeout  = 0  ] )
		该函数通过key删除一个元素。如果指定了timeout，那么该元素会在timeout秒后失效。
		成功返回true,失败返回false。
		
		$memcache->set('key1','haha');
		$memcache->set('key2',12);
		$memcache->set('key3','12');
		echo $memcache->get('key1');//haha
		$flag=$memcache->delete('key1');
		var_dump($flag);//true代表删除成功
		var_dump($memcache->get('key1'));//false，没有获得该值

7. Memcache::flush — 清洗（删除）已经存储的所有的元素

		bool Memcache::flush  ( void )
		该方法立即将memcache里存在的所有元素都删除。该方法并不会立即真正的删除元素，这太耗时了，它只是标记所有元素都失效，因此已经被使用的内存会被新的元素复写。
		成功返回true,失败返回false

		$memcache->set('key1','haha');
		$memcache->set('key2',12);
		$memcache->set('key3','12');
		echo $memcache->get('key1');//输出haha，说明set值成功
		$flag=$memcache->flush();
		var_dump($flag);//true,说明清空成功
		var_dump($memcache->get('key1'));//false
		var_dump($memcache->get('key2'));//false
		var_dump($memcache->get('key3'));//false

8. Memcache::get — 从服务端检回一个元素

		string Memcache::get  ( string $key  [, int &$flags  ] )
		或者：array Memcache::get  ( array $keys  [, array &$flags  ] )
		该方法返回之前存储的值，可以给该方法传递一个数组以获得一个数组的元素之，返回的数组仅仅包含从服务端查找到的键值对
		成功返回元素的值，失败返回false

		$memcache->set('key1','haha');
		$memcache->set('key2',12);
		$memcache->set('key3','12');	
		var_dump($memcache->get('key1'));
		var_dump($memcache->get('key2'));
		var_dump($memcache->get('key3'));
		输出：
		string 'haha' (length=4)
		int 12
		string '12' (length=2)
				
9. Memcache::getExtendedStats — 缓存服务器池中所有服务器统计信息

		array Memcache::getExtendedStats  ([ string $type  [, int $slabid  [, int $limit  = 100  ]]] )
		该方法返回一个二维关联数组的服务器统计信息。数组的key由host:port方式，无效的服务器返回的统计信息被设置为false。
		返回一个二维关联数组的服务器统计信息或者在失败时返回false。

		$result=$memcache->getExtendedStats();
		print_r($result);
		输出：	
		Array
		(
		    [localhost:11211] => Array
		        (
		            [pid] => 4708
		            [uptime] => 3055655081
		            [time] => 228493055
		            [version] => 1.4.2
		            [pointer_size] => 64
		            [rusage_user] => 0.078125
		            [rusage_system] => 0.156250
		            [curr_connections] => 11
		            [total_connections] => 402
		            [connection_structures] => 12
		            [cmd_get] => 574
		            [cmd_set] => 140
		            [cmd_flush] => 1
		            [get_hits] => 574
		            [get_misses] => 95
		            [delete_misses] => 1
		            [delete_hits] => 3
		            [incr_misses] => 0
		            [incr_hits] => 0
		            [decr_misses] => 0
		            [decr_hits] => 8
		            [cas_misses] => 0
		            [cas_hits] => 0
		            [cas_badval] => 0
		            [bytes_read] => 12191
		            [bytes_written] => 20264
		            [limit_maxbytes] => 67108864
		            [accepting_conns] => 1
		            [listen_disabled_num] => 0
		            [threads] => 4
		            [conn_yields] => 0
		            [bytes] => 367
		            [curr_items] => 5
		            [total_items] => 140
		            [evictions] => 0
		        )
		
		)

10. Memcache::getServerStatus — 用于获取一个服务器的在线/离线状态

		int Memcache::getServerStatus  ( string $host  [, int $port  = 11211  ] )
		host:主机监听地址
		port：主机监听端口，默认为11211
		返回服务器的状态，0表示服务器离线，非0表示在线。
		
		$result=$memcache->getServerStatus('localhost');
		print_r($result);//1,表示服务器在线
		$result=$memcache->getServerStatus('localhost','1211');//此时会报错

11. Memcache::getStats — 获取服务器统计信息

		array Memcache::getStats  ([ string $type  [, int $slabid  [, int $limit  = 100  ]]] )
		该方法返回一个关联数组记录服务器的统计信息。数组key是统计信息名，值就是统计信息值。
		成功返回关联数组表示的服务器的统计信息，失败返回false。
	
		$result=$memcache->getStats();//返回数据时getExtendedStats里的某一个主机的统计信息
		print_r($result);
		输出：		
		Array
		(
		    [pid] => 4708
		    [uptime] => 3055655568
		    [time] => 228493542
		    [version] => 1.4.2
		    [pointer_size] => 64
		    [rusage_user] => 0.078125
		    [rusage_system] => 0.156250
		    [curr_connections] => 11
		    [total_connections] => 417
		    [connection_structures] => 12
		    [cmd_get] => 574
		    [cmd_set] => 140
		    [cmd_flush] => 1
		    [get_hits] => 574
		    [get_misses] => 95
		    [delete_misses] => 1
		    [delete_hits] => 3
		    [incr_misses] => 0
		    [incr_hits] => 0
		    [decr_misses] => 0
		    [decr_hits] => 8
		    [cas_misses] => 0
		    [cas_hits] => 0
		    [cas_badval] => 0
		    [bytes_read] => 12212
		    [bytes_written] => 22532
		    [limit_maxbytes] => 67108864
		    [accepting_conns] => 1
		    [listen_disabled_num] => 0
		    [threads] => 4
		    [conn_yields] => 0
		    [bytes] => 367
		    [curr_items] => 5
		    [total_items] => 140
		    [evictions] => 0
		)

12. Memcache::getVersion — 返回服务器版本信息

		string Memcache::getVersion  ( void )
		返回一个字符串表示的服务端版本号。
		成功返回版本号，失败返回false.

		echo $memcache->getVersion();//1.4.2

13. Memcache::increment — 增加一个元素的值

		int Memcache::increment  ( string $key  [, int $value  = 1  ] )
		将指定的元素的值增加value，使用方法与decrement基本类似。

14. Memcache::pconnect — 打开一个到服务器的持久化连接

		mixed  Memcache::pconnect  ( string $host  [, int $port  [, int $timeout  ]] )
		该方法的使用与connect基本相同，不同的是这里建立的是持久化连接，该连接不会在脚本执行结束后或者调用close后关闭。
		成功返回true，失败返回false。

15. Memcache::replace — 替换已经存在的元素的值

		bool Memcache::replace  ( string $key  , mixed  $var  [, int $flag  [, int $expire  ]] )
		该方法通过key来查找元素并替换其值，当对应的元素key不存在时返回false。
		成功返回true，失败返回false。

		$memcache->set('key1','haha');
		echo $memcache->get('key1');//输出haha
		$flag=$memcache->replace('key1', 'heihei');
		var_dump($flag);//true，说明替换值成功
		var_dump($memcache->get('key1'));//输出heihei

16. Memcache::set — Store data at the server

		bool Memcache::set  ( string $key  , mixed  $var  [, int $flag  [, int $expire  ]] )
		该方法向key存储一个值。并设置相关的选项。
		var:要存储的值，字符串和数字化直接存储，其他类型序列化后存储。
		成功返回true，失败返回false。

		$value=[1,23,'haha'];
		$memcache->set('key1', $value);
		print_r($memcache->get('key1'));
		输出：
		Array
		(
		    [0] => 1
		    [1] => 23
		    [2] => haha
		)

17. Memcache::setCompressThreshold — 开启大值自动压缩

		bool Memcache::setCompressThreshold  ( int $threshold  [, float $min_savings  ] )
		threshold：控制多大值进行自动压缩的阈值
		min_saving：指定经过压缩实际存储的值的压缩率，支持的值必须在0和1之间，默认值为0.2表示20%压缩率。
		成功返回true,失败返回false。

		memcache_set_compress_threshold ( $memcache_obj ,  20000 ,  0.2 );

18. Memcache::setServerParams — 运行时修改服务器参数和状态

		bool Memcache::setServerParams  ( string $host  [, int $port  = 11211  [, int $timeout  [, int $retry_interval  = false  [, bool $status  [, callback  $failure_callback  ]]]]] )
		该方法可以在运行阶段修改服务器的参数。
		成功返回true，失败返回false。

		$memcache -> setServerParams ( 'memcache_host' ,  11211 ,  1 ,  15 ,  true ,  '_callback_memcache_failure' );
		print_r($memcache->getStats());

函数：
memcache_debug - 转换调试输出的开/关

	bool memcache_debug  ( bool $on_off  )
	该函数在$on_off设置为true时打开调试输出，在值为false是关闭调试输出。
	返回值：当PHP以--enalbe-debug选项构建时返回 TRUE 其他情况下返回 FALSE 。 
