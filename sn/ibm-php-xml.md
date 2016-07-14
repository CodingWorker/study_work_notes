#面向 PHP 开发人员的 XML

##第 1 部分: PHP XML 开发 

###简介
- 简单的可预测的相对较小的xml文档，使用simplexml。
- 在必要时可以使用DOM,xml文件涉及ajax应用
- xml采用文本方式应用和描述信息的树状结构。

###编写xml文档

- xml的基本数据单位是元素，由起始标记和结束标记包围。标记的名称通常反应元素所包含的内容的类型。

		<books>
		 <book>
		 <title>Great American Novel</title>
		 <characters>
		 <character>
		 <name>Cliff</name>
		 <desc>really great guy</desc>
		 </character>
		 <character>
		 <name>Lovely Woman</name>
		 <desc>matchless beauty</desc>
		 </character>
		 <character>
		 <name>Loyal Dog</name>
		 <desc>sleepy</desc>
		 </character>
		 </characters>
		 <plot>
		 Cliff meets Lovely Woman. Loyal Dog sleeps, but wakes up to bark
		 at mailman.
		 </plot>
		 <success type="bestseller">4</success>
		 <success type="bookclubs">9</success>
		 </book>
		 </books>	

- XML 元素和属性名可以包含大写字母 A-Z、小写字母 a-z、数字 0-9、一些特殊字符和非英文字符以及三种标点符号：连字符、下划线和句点。
- xml是大小写敏感的，即<book>和<Book>代表的是不同的元素
- 每个xml文档有且只有一个根元素，根元素指没有父元素的元素
- 除了形成父子元素的元素嵌套外，xml元素还可以具有属性，属性是附加到元素起始和结束标记上的键值对，如上面的success元素

###xml的力量

- xml的基本语法有嵌套元素组成，部分元素具有属性和内容，元素通常含有两个标记：起始标记和结束标记
- xml中空白是有意义的

###xml的弱点
xml非常啰嗦，存储体积大，消耗带宽多

###PHP5新增加的xml扩展
 SAX 解析器、DOM、SimpleXML、XMLReader、XMLWriter 和 XSLT 处理程序，这些扩展都基于libxml2

##读取操作和写入xml
- 如果读取操作和写入的xml文档简单、可以测、比较小，则simplexml是一个不错的选择，适当的加上DOM更理想
- DOM和simplexml是功能最完善的

##DOM扩展
因为 DOM 要构造整个文档树，要花费大量的内存和处理器时间。因此，性能问题决定了使用 DOM 很难处理大型文档。本文中主要把 DOM 扩展用于导入 SimpleXML 格式（作为字符串）和输出 DOM 格式的 XML（作为 XML 文件）或者相反。

##simplexml文档
选择 SimpleXML 扩展解析 XML 文档。SimpleXML 扩展需要 PHP5 并包括和 DOM 的互操作性，以便编写 XML 文件和内置的 XPath 支持。SimpleXML 最适合简单的、类似记录的数据，比如从同一个应用程序其他部分传递来的 XML 文档或字符串。如果 XML 文档不是很复杂，嵌套不太深，没有混合内容，使用 SimpleXML 要比 DOM 简单得多

##使用DOM生成xml文档

	<?php

	 //Creates XML string and XML document using the DOM
	 $dom = new DomDocument('1.0');
	 
	 //add root - <books>
	 $books = $dom->appendChild($dom->createElement('books'));
	 
	 //add <book> element to <books>
	 $book = $books->appendChild($dom->createElement('book'));
	 
	 //add <title> element to <book>
	 $title = $book->appendChild($dom->createElement('title'));
	 
	 //add <title> text node element to <title>
	 $title->appendChild($dom->createTextNode('Great American
	 Novel'));
	 
	 //generate xml
	 $dom->formatOutput = true; // set the formatOutput attribute of
	 domDocument to true
	 // save XML as string or file
	 $test1 = $dom->saveXML(); // put string in test1
	 $dom -> save('test1.xml'); // save as file
	 ?>
		
##DOM和simplexml的互操作行

	 <?php
 
	 $sxe = simplexml_load_string('<books><book><title>Great American 
	Novel</title></book></books>');
	 
	 if ($sxe === false) {
	 echo 'Error while parsing the document';
	 exit;
	 }
	 
	 $dom_sxe = dom_import_simplexml($sxe);
	 if (!$dom_sxe) {
	 echo 'Error while converting XML';
	 exit;
	 }
	 
	 $dom = new DOMDocument('1.0');
	 $dom_sxe = $dom->importNode($dom_sxe, true);
	 $dom_sxe = $dom->appendChild($dom_sxe);
	 
	 echo $dom->saveXML('test2.xml');
	 
	 ?>

##使用简单的simplexml

###访问元素的值
	$xml=<<<xml
	<?xml version='1.0' standalone='yes'?>
	<books>
	<book>
	 <title>Great American Novel</title>
	 <characters>
	 <character>
	 <name>Cliff</name>
	 <desc>really great guy</desc>
	 </character>
	 <character>
	 <name>Lovely Woman</name>
	 <desc>matchless beauty</desc>
	 </character>
	 <character>
	 <name>Loyal Dog</name>
	 <desc>sleepy</desc>
	 </character>
	 </characters>
	 <plot>
	 Cliff meets Lovely Woman. Loyal Dog sleeps, but wakes up to bark
	 at mailman.
	 </plot>
	 <success type="bestseller">4</success>
	 <success type="bookclubs">9</success>
	 </book>
	 </books>
	xml;
	
	$xml=new SimpleXMLElement($xml);
	var_dump($xml->book[0]);
	echo $xml->book[0]->plot;

###访问元素的属性

	$xml = new SimpleXMLElement($xmlstr);
 
	 foreach ($xml->book[0]->success as $success) {
	 switch((string) $success['type']) { // Get attributes as element indices，可见要获得值需要强制类型转换
	 case 'bestseller':
	 echo $success, ' months on bestseller list';
	 break;
	 case 'bookclubs':
	 echo $success, ' bookclub listings';
	 break;
	 }
	 }
	要把元素或属性和字符串进行比较，或者将其传递给需要字符串参数的函数，必须使用（string）强制转换成字符串。否则，默认情况下 PHP 将元素看作对象，如清单 10 所示。

###修改文本节点

	$xml = new SimpleXMLElement($xmlstr);
 	$xml->book[0]->characters->character[0]->name = 'Big Cliff';
 	echo $xml->asXML();

	$xml->book->characters->character->name="afafafafafadfadfasdfa";
	var_dump($xml->book->characters->character->name);

###增加元素和属性

	 $character = $xml->book[0]->characters->addChild('character');
	 $character->addChild('name', 'Yellow Cat');
	 $character->addChild('desc', 'aloof');
	 
	 $success = $xml->book[0]->addChild('success', '2');
	 $success-> $rating->addAttribute('type', 'reprints');
	 
	 echo $xml->asXML();

- 增加元素

		$characters = $xml->book->characters;
		// print_r($characters);
		$character = $characters->addChild("character");
		$character->addChild("name","namenamename");
		$character->addChild("desc","descdescdesc");
		
		print_r($xml);

-增加属性

	$success = $xml->book->addChild('success', 'haha');
	$success->addAttribute('typetype', 'DIYtype');
	var_dump($xml->book->success[2]->asxml());

#第 2 部分: 高级 XML 解析技术

- 解析xml有两种方式：树和流
- 树解析需要将整个xml文档加载到内存，从而可以随机访问元素和编辑xml,在PHP中的解析器如DOM和simplexml，这两个解析器可与共享树结构
- 流解析不将文档加载到内存，而是每次提交少量数据已节约带宽和内存，在流解析中只能访问当前的节点而且不能将xml当做一个文档来编辑，解析器如sax和xmlreader

##基于树的解析器-DOM和SimpleXML

**DOM要创建整个的文档树，要占用大量的内存和处理器时间**

###使用DOM

使用DOM可以构建、修改、查询、验证和转换xml文档。可以利用所有得DOM方法和属性



