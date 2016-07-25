#		C#中dictionary简介

##简介

在C#中,Dictionary提供快速的基于键值的元素查找。当你有很多元素的时候可以使用它。它包含在System.Collections.Generic名空间中。

**在使用前，你必须声明它的键类型和值类型。**

##详细说明

**必须包含名空间System.Collection.Generic **

Dictionary里面的每一个元素都是一个键值对(由二个元素组成：键和值)

**键必须是唯一的**,而值不需要唯一的 

键和值都可以是任何类型(比如：string, int, 自定义类型，等等)

通过一个键读取一个值的时间是接近O(1)
 
键值对之间的偏序可以不定义
 
###创建和初始化一个Dictionary对象

	**Dictionary myDictionary = new Dictionary<string, int>(); **//申明了一个键为string类型、value为int类型的字典

###添加键

使用Add方法

	static void Main(string[] args) 
	{ 
	  Dictionary d = new Dictionary(); 
	  d.Add("C#", 2); 
	  d.Add("C", 0); 
	  d.Add("C++", -1); 
	} 

###查找键

使用ContainsKey方法，在获得键值之前一定要使用该方法判断键是否存在，否则在不存在时会报告一个异常错误

	static void Main(string[] args) 
	{ 
	   Dictionary d = new Dictionary(); 
	   d.Add("C#", 2); 
	   d.Add("VB", 1); 
	   d.Add("C", 0); 
	   d.Add("C++", -1); 
	   if (d.ContainsKey("VB")) // True 
	   { 
	      int p = d["VB"]; //获得键值
	      Console.WriteLine(p); 
	     }  
	  
	     if (d.ContainsKey("C")) 
	     { 
	       int p1 = d["C"]; 
	       Console.WriteLine(p1); 
	     } 
	} 


###删除元素

使用Remove方法

	static void Main(string[] args) 
	{ 
	   Dictionary d = new Dictionary(); 
	   d.Add("C#", 2); 
	   d.Add("VB", 1); 
	   d.Add("C", 0); 
	   d.Add("C++", -1); 
	  
	   d.Remove("C");  //移除键   
	   d.Remove("VB"); 
	} 

使用`ContainsValue`查找值的存在

	static void Main(string[] args) 
	{ 
	    Dictionary d = new Dictionary(); 
	    d.Add("C#", 2); //添加键和值
	    d.Add("VB", 1); 
	    d.Add("C", 0); 
	    d.Add("C++", -1); 
	    if (d.ContainsValue(1)) //查找值，判断值是否存在
	    { 
	        Console.WriteLine("VB"); 
	    } 
	    if (d.ContainsValue(2)) 
	    { 
	       Console.WriteLine("C#"); 
	    } 
	    if (d.ContainsValue(0)) 
	    { 
	       Console.WriteLine("C"); 
	    } 
	    if (d.ContainsValue(-1)) 
	      { 
	          Console.WriteLine("C++"); 
	      }                
	} 

### `KeyNotFoundException`

如果你尝试读取字典中一个不存在的键，那么你会得到一个KeyNotFoundException。

所有在读取一个键之前，你**必须先使用ContainKey来核对键是否存在字典中**。

基于int键的Dictionary

	static void Main(string[] args) 
	{ 
	   Dictionary d = new Dictionary(); 
	   d.Add(1000, "Planet"); 
	   d.Add(2000, "Stars"); 
	   // lookup the int in the dictionary. 
	   if (d.ContainsKey(1000)) 
	   { 
	        Console.WriteLine(true); 
	   } 
	      Console.ReadLine(); 
	} 

###排序字典SortedDictionary

在排序字典中，当添加元素时字典必须进行排序，**所以插入的速度会比较慢点**。

但是因为元素是有序存储的，所以元素的**查找可以使用二分搜索等一些效率更高的搜索**。

##总结

在这篇文章中，简要地介绍C#中的Dictionary的使用。动手写写吧~
 
	using System;   
	using System.Collections.Generic; //使用字典要包括该类  
	  
	class DictionaryDemo   
	{   
		static void Main(string[] args)   
		{   
			DictionaryDemo001();   
			Console.ReadLine();   
			  
			DictionaryDemo002();   
			Console.ReadLine();   
			  
			DictionaryDemo003();   
			Console.ReadLine();   
		}   
	  
	/// <summary>   
	/// 一般用法   
	/// </summary>   
		static void DictionaryDemo001()   
		{   
			Dictionary<int, string> dict = new Dictionary<int, string>(); //声明时带键和值的类型  
			dict.Add(1, "111");//增加键和值
			dict.Add(2, "222");   
			  
			//判断是否存在相应的key并显示   
			if (dict.ContainsKey(2)) //判断字典是否存在键  
			{   
				Console.WriteLine(dict[2]); //类似关联数组 
			}   
			  
			//遍历Keys   
			foreach (var item in dict.Keys)  //遍历键 
			{   
				Console.WriteLine("Key:{0}", item);   
			}   
			  
			//遍历Values   
			foreach (var item in dict.Values) //遍历值  
			{   
				Console.WriteLine("value:{0}", item);   
			}   
			  
			//遍历整个字典   
			foreach (var item in dict) //遍历字典的键和值，使用item.Key, item.Value获得键好值
			{   
				Console.WriteLine("key:{0} value:{1}", item.Key, item.Value);   
			}   
		}   
	  
	/// <summary>   
	/// 参数为其它类型   
	/// </summary>   
		static void DictionaryDemo002()   
		{   
			Dictionary<string, string[]> dict = new Dictionary<string, string[]>();   
			dict.Add("1", "1,11,111".Split(','));   
			dict.Add("2", "2,22,222".Split(','));   
			Console.WriteLine(dict["2"][2]);   
		}   
	  
	/// <summary>   
	/// 调用自定义类   
	/// </summary>   
		static void DictionaryDemo003()   
		{   
			Dictionary<int, yongfa365> dict = new Dictionary<int, yongfa365>();   
			for (int i = 0; i < 10; i++)   
			{   
				yongfa365 y = new yongfa365();   
				y.UserCode = i;   
				y.UserName = "www.yongfa365.com " + i.ToString();   
				dict.Add(i, y);   
			}   
			foreach (var item in dict)  //遍历整个字典，键和值 
			{   
				Console.WriteLine("{0} One:{1} UserName:{2}", item.Key, item.Value.UserCode, item.Value.UserName);   
			}   
		}   
	}   
	  
	class yongfa365   
	{   
		public int UserCode { get; set; }   
		public string UserName { get; set; }   
	  
	}   
	
另一个文件

	using System;   
	using System.Collections.Generic;//必须包含该类   
	  
	class DictionaryDemo   
	{   
		static void Main(string[] args)   
		{   
			DictionaryDemo001();   
			Console.ReadLine();   
			  
			DictionaryDemo002();   
			Console.ReadLine();   
			  
			DictionaryDemo003();   
			Console.ReadLine();   
		}   
	  
	/// <summary>   
	/// 一般用法   
	/// </summary>   
		static void DictionaryDemo001()   
		{   
			Dictionary<int, string> dict = new Dictionary<int, string>();   
			dict.Add(1, "111");   
			dict.Add(2, "222");   
		  
			//判断是否存在相应的key并显示   
			if (dict.ContainsKey(2))   
			{   
				Console.WriteLine(dict[2]);   
			}   
			  
			//遍历Keys   
			foreach (var item in dict.Keys) //遍历键  
			{   
				Console.WriteLine("Key:{0}", item);   
			}   
			  
			//遍历Values   
			foreach (var item in dict.Values) //遍历值  
			{   
				Console.WriteLine("value:{0}", item);   
			}   
			  
			//遍历整个字典   
			foreach (var item in dict)   //遍历键和值
			{   
			Console.WriteLine("key:{0} value:{1}", item.Key, item.Value);   
			}   
			}   
		  
		/// <summary>   
		/// 参数为其它类型   
		/// </summary>   
		static void DictionaryDemo002()   
		{   
			Dictionary<string, string[]> dict = new Dictionary<string, string[]>();   
			dict.Add("1", "1,11,111".Split(','));   
			dict.Add("2", "2,22,222".Split(','));   
			Console.WriteLine(dict["2"][2]);   
		}   
			  
		/// <summary>   
		/// 调用自定义类   
		/// </summary>   
		static void DictionaryDemo003()   
		{   
			Dictionary<int, yongfa365> dict = new Dictionary<int, yongfa365>();   
			for (int i = 0; i < 10; i++)   
			{   
				yongfa365 y = new yongfa365();   
				y.UserCode = i;   
				y.UserName = "www.yongfa365.com " + i.ToString();   
				dict.Add(i, y);   
			}   
			foreach (var item in dict)   
			{   
				Console.WriteLine("{0} One:{1} UserName:{2}", item.Key, item.Value.UserCode, item.Value.UserName);   
			}   
		}   
	}   
	  
	class yongfa365   
	{   
		public int UserCode { get; set; }   
		public string UserName { get; set; }   
	  
	}   