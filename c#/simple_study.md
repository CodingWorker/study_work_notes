#var 关键字

当不知道要用什么类型时使用var关键字声明变量

#String.IsNullOrEmpty(字符串)
>判断指定的字符串是否为null后者为空（即空字符串""）
>参数为 null 或空字符串 ("")，则为 true；否则为 false。 

#Int32.TryParse 方法 
>将数字的字符串表示形式转换为它的等效 32 位有符号整数。一个指示操作是否成功的返回值。
>使用方法


百科上的解释：

	int.Parse()是一种类容转换；表示将数字内容的字符串转为int类型。
	
如果字符串为空，则抛出ArgumentNullException异常；
如果字符串内容不是数字，则抛出FormatException异常；
如果字符串内容所表示数字超出int类型可表示的范围，则抛出OverflowException异常；

int.TryParse 与 int.Parse 又较为类似，但它不会产生异常，**转换成功返回 true，转换失败返回 false**。**最后一个参数为输出值，如果转换失败，输出值为 0**


