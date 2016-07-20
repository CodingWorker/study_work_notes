fastcgi_param  SCRIPT_FILENAME    $document_root$fastcgi_script_name;//请求的脚本文件所在路径/目录
fastcgi_param  QUERY_STRING       $query_string;//请求的参数
fastcgi_param  REQUEST_METHOD     $request_method;//请求的方法（GET或者POST)
fastcgi_param  CONTENT_TYPE       $content_type;//请求头中的content-type字段
fastcgi_param  CONTENT_LENGTH     $content_length;//请求头中content-length字段


fastcgi_param fastcgi_param为fastcgi参数，该文件就是为fastcgi参数设置值

fastcgi_param  SCRIPT_NAME        $fastcgi_script_name;//脚本名称
fastcgi_param  REQUEST_URI        $request_uri;//请求的地址（不带参数）
fastcgi_param  DOCUMENT_URI       $document_uri;与
fastcgi_param  DOCUMENT_ROOT      $document_root;//网站的根目录，在ningx的server配置中root指定的值
fastcgi_param  SERVER_PROTOCOL    $server_protocol;//请求使用的协议，通常是HTTP/1.0或者HTTP/1.1
fastcgi_param  REQUEST_SCHEME     $scheme;
fastcgi_param  HTTPS              $https if_not_empty;

fastcgi_param  GATEWAY_INTERFACE  CGI/1.1;//该CGI版本
fastcgi_param  SERVER_SOFTWARE    nginx/$nginx_version;//nginx的版本号，可以修改和隐藏

fastcgi_param  REMOTE_ADDR        $remote_addr;//客户端IP
fastcgi_param  REMOTE_PORT        $remote_port;//客户端端口
fastcgi_param  SERVER_ADDR        $server_addr;//服务器IP
fastcgi_param  SERVER_PORT        $server_port;//服务器端口
fastcgi_param  SERVER_NAME        $server_name;//服务器名，域名为在nginx中server配置中指定的server_name

# PHP only, required if PHP was built with --enable-force-cgi-redirect
fastcgi_param  REDIRECT_STATUS    200;    重定向状态码200

该文件的配置都可以在PHP中通过服务器环境变量打印出来，
如：echo $_SERVER['REMOTE_ADDR'];