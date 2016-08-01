#Redis实现微博关注

##关注的四种状态：
- 关注
- 粉丝
- 双向关注（互粉）
- 无关系

###关键就在于连个集合：
1. 关注集合follows
2. 粉丝集合fans

	假设要查找的集合为：finds
	
	可以遍历要查找的集合：
	
	如果item同时在follows和fans两个集合中，那么就是互粉
	
	否则：如果item在follows集合中就是我的关注
	
	否则：如果item在fans集合中，就是我的粉丝
	
	否则：item与我无关系
	
	可已经上述结果信息存入到redis

代码：

	<?php 
	
	function getRelationShip($finds){
	
		is_null($finds) && return '';
		if (is_string($finds)) {
			if (in_array($finds, $follows) || in_array($finds, $fans)) {
				$msg = '互粉关系';
			} elseif (in_array($finds, $follows)) {
				$msg = '关注关系';
			} elseif (in_array($finds, $fans)) {
				$msg = '粉丝关系';
			} else {
				$msg = '无关系';
			}
		} else {//非字符串就为数组
			foreach ($finds as $v) {
				if (is_string($v)) {
					if (in_array($v, $follows) || in_array($v, $fans)) {
						$msg = '互粉关系';
					} elseif (in_array($v, $follows)) {
						$msg = '关注关系';
					} elseif (in_array($v, $fans)) {
						$msg = '粉丝关系';
					} else {
						$msg = '无关系';
					}
				}
			}
		}
		return $msg;
	
	}

再将此查询结果放到redis里面，利用url参数作为redis里的key