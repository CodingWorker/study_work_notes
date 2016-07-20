
#配置文件翻译

	#user  nobody;//运行的用户及用户组，例如 user ningx ningx
	worker_processes  8;//工作的进程数目，根据硬件调整，通常等于CPU的数量或者2倍数量于CPU
    worker_cpu_affinity 00000001 00000010 00000100 00001000 00010000 00100000 01000000 10000000;

为每个进程分配cpu，上例中将8 个进程分配到8 个cpu，当然可以写多个，或者将一个进程分配到多个cpu。	

	#error_log  logs/error.log;
	#error_log  logs/error.log  notice;
	#error_log  logs/error.log  info;//以上三项配置分别制定错误日志、notice日志和info日志的存放路径
	
	#pid        logs/nginx.pid;//pid文件的存放位置
	worker_rlimit_nofile 65535;

worker_rlimit_nofile 65535,这个指令是指当一个nginx 进程打开的最多文件描述符数目，理论值应该是最多打开文件数（ulimit -n）与nginx 进程数相除，但是nginx 分配请求并不是那么均匀，所以最好与ulimit -n 的值保持一致。现在在linux 2.6内核下开启文件打开数为65535，worker_rlimit_nofile就相应应该填写65535。
	
	events {
		#use epoll;该命令只有在linux系统里才有
	    worker_connections  1024;
	}
	
use epoll;//epoll是多路复用IO(I/O Multiplexing)中的一种方式,但是仅用于linux2.6以上内核,可以大大提高nginx的性能  
worker_connections  1024;//每个工作进程worker_progress的最大处理连接数量，根据硬件进行调整。和前面的工作进程worker_progress配合使用。可以将该值设置的尽量大些只要CPU不跑到100%。通过该值和前面的worker_progress可知道每台nginx的最大连接数为worker_progresses*worker_connections
	
	http {
	    include       mime.types;//包含进mime类型文件，该文件里设置了mime类型定义
	    default_type  application/octet-stream;//默认类型

 default_type  application/octet-stream;//指定默认类型为二进制流,也就是当文件类型（在文件头content-type）未 定义时使用application/octet-stream，ctet-stream代表的是文件的形式传输的，这样做的好处是可以传输多种格式的文件，不管你是jpeg还是png都可以通过这种方式传送过去
	
	    #log_format  main  '$remote_addr - $remote_user [$time_local] "$request" '
	    #                  '$status $body_bytes_sent "$http_referer" '
	    #                  '"$http_user_agent" "$http_x_forwarded_for"';//以上几项设置日志记录的格式
		
		#log_format  php   '$remote_addr $http_x_forwarded_for $remote_user [$time_local] "$request" '
        #                                        '$status $body_bytes_sent "$http_referer" '
        #                                        '"$http_user_agent" $upstream_response_time $request_time 0';
        #log_format  upstreamlog   '$remote_addr $http_x_forwarded_for $remote_user [$time_local] "$request" '
        #                                       '$status $body_bytes_sent "$http_referer" '
        #                                       '"$http_user_agent" $upstream_response_time $request_time 1';


$remote_addr与$http_x_forwarded_for用以记录客户端的ip地址
$remote_user用来记录客户端用户名称
$time_local用来记录访问时间与时区
$request用来记录请求的url与http协议
$status用来记录请求的状态码，成功为200
$body_bytes_sent记录发送给客户端文件主体内容大小
$http_referer用来记录从哪个页面链接访问过来的
$http_user_agent用来记录客户浏览器的相关信息

注意：通常web服务器放在反向代理的后面即apache放在nginx后处理，因此就不能获取到客户端IP地址了，通过$remote_addr拿到的ip地址为反向代代理服务器的ip地址。反向代理服务器在转发请求的http头信息中，可以增加x_forwarded_for信息，用以记录原有客户端的ip地址和原来客户端的请求的服务器地址
	
	    #access_log  logs/access.log  main;

设置access_log的存放路径，在使用log_format指令设置了日志格式后需要该指令来设置access_log日志文件的存放路径
	
		rewrite_log on;
	    sendfile        on;
	    #tcp_nopush     on;

rewrite_log指令开启或者关闭将ngx_http_rewrite_module模块指令的处理日志以notice级别记录到错误日志中。
sendfile指令指定nginx是否调用函数sendfile函数（zero copy方式）来输出文件。对于普通的应用，必须将此值设置为on，如果用来下载等应用磁盘IO重负载的应用，可以设置为off。这样设置以平衡磁盘与网络的IO处理速度，降低系统负载（uptime）。
tcp_nopush此选项允许或禁止使用socke的TCP_CORK的选项，此选项仅在使用sendfile的时候使用，设置为on从而可以调用tcp_cork方法，这个也是默认的，结果就是数据包不会马上传送出去，等到数据包最大时，一次性的传输出去，这样有助于解决网络堵塞。
	
	    #keepalive_timeout  0;
	    keepalive_timeout  65;

keepalive_timeout设置连接的超时时间，如果设置为0则不限制连接时间（秒）。根据实际情况设置

	    #gzip  on;

该指令设置是否开启gzip压缩。

		resolver 10.202.72.118;

另外还需要在http字段内，用resolver指定一下DNS服务器，否则会发生 “nginx 502 bad gateway” 的错误。例如采用Google提供的DNS服务：
resolver 8.8.8.8;

	proxy_cache_path /data/openresty/nginx/cache/api levels=1:2 keys_zone=apicache:2048m inactive=1d max_size=5g;

>`proxy_cache_path`指令控制nginx的缓存路径，
levels=1:2表示缓存目录的第一级目录是1个字符，第二级目录是两个字符，如nginx/cache/api/apicache/a/1b
`keys_zone`=apicache:2048m表示这个zone名称为apicache,分配的内存大小为2048MB;
inactive=1d指令表示这个zone中的缓存文件如果在1天内都没有访问，那么文件会被cache manager进程删除掉
max_size=5g指令表示这个zone的硬盘容量为5GB。

#配置虚拟机
	
	    server {
	        listen       80;//配置监听端口为80
	        server_name  localhost;//配置访问域名

代理配置

		client_max_body_size 300m;//允许客户端请求的最大单文件字节数
        client_body_buffer_size 128k;//缓冲区代理缓冲用户端请求的最大字节数
        proxy_connect_timeout 600;//nginx与后端服务器的超时时间
        proxy_read_timeout 600;//连接成功后后端服务器响应时间（代理接收超时）
        proxy_send_timeout 600;//后端服务器数据回传时间（代理发送超时）
        proxy_buffer_size 64k;//设置代理服务器（nginx)保存用户头信息的缓冲区大小
        proxy_buffers   4 32k;//proxy_buffers缓冲区，网页平均在32k一下的情况下这样设置
        proxy_busy_buffers_size 64k;//高负荷下缓冲大小(proxy_buffers*2)
        proxy_temp_file_write_size 64k;//设定缓存文件夹大小，大于这个值将从upstream服务器传
	
	        #charset koi8-r;//设定字符集
	
	        #access_log  logs/host.access.log  main;//设置本虚拟主机的访问日志的地址
	
			默认请求
	        location / {
	            root   html;//定义服务器的默认网站根目录位置
	            index  index.html index.htm;//定义首页默认索引文件的名称
	        }
	
	        #error_page  404              /404.html;//定义错误提示页面
	
	        # redirect server error pages to the static page /50x.html
	        #
	        error_page   500 502 503 504  /50x.html;
	        location = /50x.html {
	            root   html;
	        }

>以上设置错误重定向到网站自定义的静态页面
	
	        # proxy the PHP scripts to Apache listening on 127.0.0.1:80
	        #
	        #location ~ \.php$ {
	        #    proxy_pass   http://127.0.0.1;
	        #}

代理功能设置，该处的设置将所有PHP脚本定向到apache的监听地址和监听端口127.0.0.1:80
location设置浏览器访问的url正则匹配， ~ \.php$类似正则匹配，表示请求的是以.php结尾的文件。proxy_pass表示代理转递到的IP地址和端口，这里为http://127.0.0.1，默认端口为80
	
	        # pass the PHP scripts to FastCGI server listening on 127.0.0.1:9000
	        #
	        #location ~ \.php$ {
	        #    root           html;
	        #    fastcgi_pass   127.0.0.1:9000;
	        #    fastcgi_index  index.php;
	        #    fastcgi_param  SCRIPT_FILENAME  /scripts$fastcgi_script_name;
	        #    include        fastcgi_params;
	        #}

与上面的命令类似，将所有PHP脚本定向到FastCGI服务器监听的IP地址和端口。
location设置浏览器访问的url正则匹配，\.php$表示以.php结尾的文件。
root           html;//设置根目录
fastcgi_pass   127.0.0.1:9000;//转递到fast_pass监听的IP地址和端口号：127.0.0.1:9000
fastcgi_index  index.php;//
fastcgi_param  SCRIPT_FILENAME  /scripts$fastcgi_script_name;
include        fastcgi_params;//包含进fastcgi的配置文件
	
	        # deny access to .htaccess files, if Apache's document root
	        # concurs with nginx's one
	        #
	        #location ~ /\.ht {
	        #    deny  all;
	        #}

该命令禁止访问.htaccess文件，如果apache的文档根目录与nginx's根目录共同作用。就是为了避免都设置后错乱。
设置访问格式：访问的文件中包含.ht的话，全部禁止访问deny  all

###下面来个配置好的例子
		
		location ~ /moli20/moli-tv/epg1 {//这个命令指定当浏览器访问server_name//moli20/moli-tv/epg1时，使用以下的规则
                add_header Source newapi;
                include fastcgi_params;
                fastcgi_pass 127.0.0.1:9000;
                fastcgi_param   SCRIPT_FILENAME                 $document_root/epg.php;
                fastcgi_param SCRIPT_NAME         epg.php;
        }

####说明，一些内容参见配置文件fastcgi_params：

	response header一般都是以key：value的形式，例如：“Content-Encoding：gzip、Cache-Control:no-store”，设置的命令为：
	复制代码 代码如下:
	add_header Cache-Control no-store
	add_header Content-Encoding gzip
	这里就是指定source为newapi，在浏览器头信息中包含此项Source:newapi
	包含进文件fastcgi_params,Nginx有两份fastcgi配置文件，分别是「fastcgi_params」和「fastcgi.conf」，它们没有太大的差异，唯一的区别是后者比前者多了一行「SCRIPT_FILENAME」的定义。
	fastcgi_pass 127.0.0.1:9000指定将此规则匹配的文件交由这里来处理。
	fastcgi_param   SCRIPT_FILENAME                 $document_root/epg.php;这条命令是重写了fastcgi_params配置文件中的对应参数值
	fastcgi_param SCRIPT_NAME         epg.php;这个也一样

	    }

以下配置使用多个IP和主机名和多个端口来配置另一个虚拟主机
	
	    # another virtual host using mix of IP-, name-, and port-based configuration
	    #
	    #server {
	    #    listen       8000;//监听端口号8000
	    #    listen       somename:8080;//监听地址和端口号somename:8080
	    #    server_name  somename  alias  another.alias;//服务器名和别名somename  alias  another.alias
	
	    #    location / {
	    #        root   html;//定义文档根目录
	    #        index  index.html index.htm;//定义默认的访问文件
	    #    }
	    #}
	
配置HTTPS服务器，这与上面的http有些不同
	
	    # HTTPS server
	    #
	    #server {
	    #    listen       443 ssl;//监听443 ssl
	    #    server_name  localhost;//主机名 localhost
	
	    #    ssl_certificate      cert.pem;
	    #    ssl_certificate_key  cert.key;

以上两项配置的是nginx的ssl证书
	
	    #    ssl_session_cache    shared:SSL:1m;
	    #    ssl_session_timeout  5m;

以上两项配置ssl下session的缓存类型、大小和默认失效时间
	
	    #    ssl_ciphers  HIGH:!aNULL:!MD5;
	    #    ssl_prefer_server_ciphers  on;

以上两项设置ssl的加密方法和开启ssl服务器密码
	
	    #    location / {
	    #        root   html;//网站文档的根目录
	    #        index  index.html index.htm;//默认访问文件
	    #    }
	    #}
	
	}
