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

2. 