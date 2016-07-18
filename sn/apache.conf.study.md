#
# This is the main Apache HTTP server configuration file.  It contains the
# configuration directives that give the server its instructions.
# See <URL:http://httpd.apache.org/docs/2.4/> for detailed information.
# In particular, see 
# <URL:http://httpd.apache.org/docs/2.4/mod/directives.html>
# for a discussion of each configuration directive.

----------

这是apache的http服务的主要配置文件。它包含了这个服务器的建立的指令。访问http://httpd.apache.org/docs/2.4/以查看更多的细节。特别的，访问http://httpd.apache.org/docs/2.4/mod/directives.html查看关于每一条配置指令的讨论。

----------

#
# Do NOT simply read the instructions in here without understanding
# what they do.  They're here only as hints or reminders.  If you are unsure
# consult the online docs. You have been warned. 

----------

不要在这里简单的读这些指南而不理解他们做什么。在这里他们仅仅是作为提醒和提示。如果你不确定这些指令请咨询网上文档。我们已经提醒你了。

----------
 
#
# Configuration and logfile names: If the filenames you specify for many
# of the server's control files begin with "/" (or "drive:/" for Win32), the
# server will use that explicit path.  If the filenames do *not* begin
# with "/", the value of ServerRoot is prepended -- so "logs/access_log"
# with ServerRoot set to "/usr/local/apache2" will be interpreted by the
# server as "/usr/local/apache2/logs/access_log", whereas "/logs/access_log" 
# will be interpreted as '/logs/access_log'.

----------

配置和日志文件的名字：如果你为许多服务器控制文件指明了特定的名字以/开头（或者在win32下以drive:/开头），那么服务器将会使用那个指明的名字。如果文件名字没有以/开头，服务器根目录之前加上了像这样：logs/access_log，而且服务器根目录设置为/usr/local/apache2，那么日志文件的存储地址即被解释为/usr/local/apache2/logs/access_log。然而如果是/logs/access_log，那么就将被解释为/logs/access_log，因为他的前边带有/.

----------

#
# NOTE: Where filenames are specified, you must use forward slashes
# instead of backslashes (e.g., "c:/apache" instead of "c:\apache").
# If a drive letter is omitted, the drive on which httpd.exe is located
# will be used by default.  It is recommended that you always supply
# an explicit drive letter in absolute paths to avoid confusion.

----------

注意：当文件名字被指定时，你必须使用前下划线而不是反斜线（例如c:/apache而不是c:\apache）。如果省略了一个文件夹驱动器名字的一个字母（应该就是c d e f ），那么httpd.exe所在的驱动器将被作为默认的驱动器使用。建议你总是以绝对路径名提供明确的驱动盘字母以避免混淆。

----------

#
# ServerRoot: The top of the directory tree under which the server's
# configuration, error, and log files are kept.
#
# Do not add a slash at the end of the directory path.  If you point
# ServerRoot at a non-local disk, be sure to specify a local disk on the
# Mutex directive, if file-based mutexes are used.  If you wish to share the
# same ServerRoot for multiple httpd daemons, you will need to change at
# least PidFile.

#
ServerRoot "D:/xampp/apache"
----------

服务器根目录：保存服务器配置、错误和日志文件的顶级目录。
不要在路径末尾加上斜线。如果你指定了根目录为一个非本地磁盘，那么如果使用了基于文件的互斥器时，要在互斥指令上指定一个本地磁盘。
如果你希望多个httpd进程共享一个根目录，你至少需要改变进程文件（PidFile）。

根目录：D:/xampp/apache
说明：其他的目录如果没有指定绝对路径，则是相对于此路径。
PidFile为第一个httpd进程的进程号文件的位置
----------

#
# Mutex: Allows you to set the mutex mechanism and mutex file directory
# for individual mutexes, or change the global defaults
#
# Uncomment and change the directory if mutexes are file-based and the default
# mutex file directory is not on a local disk or is not appropriate for some
# other reason.
#
# Mutex default:logs

----------

互斥器选项：允许你为每一个互斥器设置互斥机制和互斥文件指令或者改变全局默认值。如果互斥器是基于文件的而且默认互斥器文件目录不在本地磁盘上或者由于某种原因不合适，那么就不要取消和更改。
互斥默认为：日志

----------

#
# Listen: Allows you to bind Apache to specific IP addresses and/or
# ports, instead of the default. See also the <VirtualHost>
# directive.
#
# Change this to Listen on specific IP addresses as shown below to 
# prevent Apache from glomming onto all bound IP addresses.
#
#Listen 12.34.56.78:80
Listen 80

----------

监听端口号：这一个选项允许你将apache绑定到指定的IP地址和/或者端口而不是采用默认值。也可以参考查看<VirtualHost>指令。
改变这个选项为像下面显示的那样指定监听特定的ip地址，从而阻止了apache扫描所有绑定的IP地址。

----------

#
# Dynamic Shared Object (DSO) Support
#
# To be able to use the functionality of a module which was built as a DSO you
# have to place corresponding `LoadModule' lines at this location so the
# directives contained in it are actually available _before_ they are used.
# Statically compiled modules (those listed by `httpd -l') do not need
# to be loaded here.
#
# Example:
# LoadModule foo_module modules/mod_foo.so

----------

动态共享对象支持：
为了使用一个被作为DSO而建立的模块的功能你不得不写下相应的LoadModule行在这里，以便于在你能够使用这些模块中的指令。静态编译模块（在命令httpd -l下列出的)不需要再这里加载。
示例：LoadModule foo_module modules/mod_foo.so

----------

#
LoadModule access_compat_module modules/mod_access_compat.so
LoadModule actions_module modules/mod_actions.so
LoadModule alias_module modules/mod_alias.so
LoadModule allowmethods_module modules/mod_allowmethods.so
LoadModule asis_module modules/mod_asis.so
LoadModule auth_basic_module modules/mod_auth_basic.so
#LoadModule auth_digest_module modules/mod_auth_digest.so
#LoadModule auth_form_module modules/mod_auth_form.so
#LoadModule authn_anon_module modules/mod_authn_anon.so
LoadModule authn_core_module modules/mod_authn_core.so
#LoadModule authn_dbd_module modules/mod_authn_dbd.so
#LoadModule authn_dbm_module modules/mod_authn_dbm.so
LoadModule authn_file_module modules/mod_authn_file.so
#LoadModule authn_socache_module modules/mod_authn_socache.so
#LoadModule authnz_fcgi_module modules/mod_authnz_fcgi.so
#LoadModule authnz_ldap_module modules/mod_authnz_ldap.so
LoadModule authz_core_module modules/mod_authz_core.so
#LoadModule authz_dbd_module modules/mod_authz_dbd.so
#LoadModule authz_dbm_module modules/mod_authz_dbm.so
LoadModule authz_groupfile_module modules/mod_authz_groupfile.so
LoadModule authz_host_module modules/mod_authz_host.so
#LoadModule authz_owner_module modules/mod_authz_owner.so
LoadModule authz_user_module modules/mod_authz_user.so
LoadModule autoindex_module modules/mod_autoindex.so
#LoadModule buffer_module modules/mod_buffer.so
#LoadModule cache_module modules/mod_cache.so
#LoadModule cache_disk_module modules/mod_cache_disk.so
#LoadModule cache_socache_module modules/mod_cache_socache.so
#LoadModule cern_meta_module modules/mod_cern_meta.so
LoadModule cgi_module modules/mod_cgi.so
#LoadModule charset_lite_module modules/mod_charset_lite.so
#LoadModule data_module modules/mod_data.so
#LoadModule dav_module modules/mod_dav.so
#LoadModule dav_fs_module modules/mod_dav_fs.so
LoadModule dav_lock_module modules/mod_dav_lock.so
#LoadModule dbd_module modules/mod_dbd.so
#LoadModule deflate_module modules/mod_deflate.so
LoadModule dir_module modules/mod_dir.so
#LoadModule dumpio_module modules/mod_dumpio.so
LoadModule env_module modules/mod_env.so
#LoadModule expires_module modules/mod_expires.so
#LoadModule ext_filter_module modules/mod_ext_filter.so
#LoadModule file_cache_module modules/mod_file_cache.so
#LoadModule filter_module modules/mod_filter.so
#LoadModule http2_module modules/mod_http2.so
LoadModule headers_module modules/mod_headers.so
#LoadModule heartbeat_module modules/mod_heartbeat.so
#LoadModule heartmonitor_module modules/mod_heartmonitor.so
#LoadModule ident_module modules/mod_ident.so
#LoadModule imagemap_module modules/mod_imagemap.so
LoadModule include_module modules/mod_include.so
LoadModule info_module modules/mod_info.so
LoadModule isapi_module modules/mod_isapi.so
#LoadModule lbmethod_bybusyness_module modules/mod_lbmethod_bybusyness.so
#LoadModule lbmethod_byrequests_module modules/mod_lbmethod_byrequests.so
#LoadModule lbmethod_bytraffic_module modules/mod_lbmethod_bytraffic.so
#LoadModule lbmethod_heartbeat_module modules/mod_lbmethod_heartbeat.so
#LoadModule ldap_module modules/mod_ldap.so
#LoadModule logio_module modules/mod_logio.so
LoadModule log_config_module modules/mod_log_config.so
#LoadModule log_debug_module modules/mod_log_debug.so
#LoadModule log_forensic_module modules/mod_log_forensic.so
#LoadModule lua_module modules/mod_lua.so
LoadModule cache_disk_module modules/mod_cache_disk.so
#LoadModule macro_module modules/mod_macro.so
LoadModule mime_module modules/mod_mime.so
#LoadModule mime_magic_module modules/mod_mime_magic.so
LoadModule negotiation_module modules/mod_negotiation.so
LoadModule proxy_module modules/mod_proxy.so
LoadModule proxy_ajp_module modules/mod_proxy_ajp.so
#LoadModule proxy_balancer_module modules/mod_proxy_balancer.so
#LoadModule proxy_connect_module modules/mod_proxy_connect.so
#LoadModule proxy_express_module modules/mod_proxy_express.so
#LoadModule proxy_fcgi_module modules/mod_proxy_fcgi.so
#LoadModule proxy_ftp_module modules/mod_proxy_ftp.so
#LoadModule proxy_html_module modules/mod_proxy_html.so
#LoadModule proxy_http_module modules/mod_proxy_http.so
#LoadModule proxy_scgi_module modules/mod_proxy_scgi.so
#LoadModule proxy_wstunnel_module modules/mod_proxy_wstunnel.so
#LoadModule ratelimit_module modules/mod_ratelimit.so
#LoadModule reflector_module modules/mod_reflector.so
#LoadModule remoteip_module modules/mod_remoteip.so
#LoadModule request_module modules/mod_request.so
#LoadModule reqtimeout_module modules/mod_reqtimeout.so
LoadModule rewrite_module modules/mod_rewrite.so
#LoadModule sed_module modules/mod_sed.so
#LoadModule session_module modules/mod_session.so
#LoadModule session_cookie_module modules/mod_session_cookie.so
#LoadModule session_crypto_module modules/mod_session_crypto.so
#LoadModule session_dbd_module modules/mod_session_dbd.so
LoadModule setenvif_module modules/mod_setenvif.so
#LoadModule slotmem_plain_module modules/mod_slotmem_plain.so
#LoadModule slotmem_shm_module modules/mod_slotmem_shm.so
#LoadModule socache_dbm_module modules/mod_socache_dbm.so
#LoadModule socache_memcache_module modules/mod_socache_memcache.so
LoadModule socache_shmcb_module modules/mod_socache_shmcb.so
#LoadModule speling_module modules/mod_speling.so
LoadModule ssl_module modules/mod_ssl.so
LoadModule status_module modules/mod_status.so
#LoadModule substitute_module modules/mod_substitute.so
#LoadModule unique_id_module modules/mod_unique_id.so
#LoadModule userdir_module modules/mod_userdir.so
#LoadModule usertrack_module modules/mod_usertrack.so
LoadModule version_module modules/mod_version.so
#LoadModule vhost_alias_module modules/mod_vhost_alias.so
#LoadModule watchdog_module modules/mod_watchdog.so
#LoadModule xml2enc_module modules/mod_xml2enc.so

<IfModule unixd_module>
#
# If you wish httpd to run as a different user or group, you must run
# httpd as root initially and it will switch.  
#
# User/Group: The name (or #number) of the user/group to run httpd as.
# It is usually good practice to create a dedicated user and group for
# running httpd, as with most system services.
#
User daemon
Group daemon

----------

如果模块unixd_module存在，那么

如果你希望httpd作为一个不同的用户或者组来运行，你必须在最初作为root运行httpd,这样他就会改变。
用户/用户组：作为运行httpd的用户/用户组
正如大多数系统服务那样，为httpd服务创建一个用户/用户组是一个不错的实践。


用户进程
用户组进程

----------

</IfModule>

# 'Main' server configuration
#
# The directives in this section set up the values used by the 'main'
# server, which responds to any requests that aren't handled by a
# <VirtualHost> definition.  These values also provide defaults for
# any <VirtualHost> containers you may define later in the file.
#
# All of these directives may appear inside <VirtualHost> containers,
# in which case these default settings will be overridden for the
# virtual host being defined.
#

#
# ServerAdmin: Your address, where problems with the server should be
# e-mailed.  This address appears on some server-generated pages, such
# as error documents.  e.g. admin@your-domain.com
#
ServerAdmin postmaster@localhost

----------

如果模块已经加载了
主要服务器配置
在这一部分的指令建立了被main服务器使用的配置值，以作为解决不能够被<VirtualHost>定义所解决的请求的响应。这个值也为本文件后面的任意一个<VirtualHost>配置部分提供了默认值。
所有这些指令也许会出现在<VirtualHost>配置命令里，在那里这些默认的配置可能会被虚拟host定义重写。
ServerAdmin：你的邮件地址，使得关于本服务器的错误能够内email到。这个邮件地址将会出现在服务器产生的网页上，例如错误页面。作为例子的地址如admin@your-domain.com

ServerAdmin postmaster@localhost
说明：此即为管理员的邮件地址
----------

#
# ServerName gives the name and port that the server uses to identify itself.
# This can often be determined automatically, but we recommend you specify
# it explicitly to prevent problems during startup.
#
# If your host doesn't have a registered DNS name, enter its IP address here.
#
ServerName localhost:80

----------

ServerName指定了服务器用来辨别自己的名字和端口。这个可以经常被指定。但是我们建议你明确的指定它以避免在启动期间的一些错误。
如果你的主机没有一个注册的DNS名字那么久将IP地址写在这里。
ServerName localhost:80
说明：主站点名称，网页的主机名
----------

#
# Deny access to the entirety of your server's filesystem. You must
# explicitly permit access to web content directories in other 
# <Directory> blocks below.
#
<Directory />
    AllowOverride none
    Require all denied
</Directory>

----------

这条指令禁止外部连接你的服务器的所有文件系统。你必须在下面的其他<Directory>块中明确的指定外部可以连接到你的那些内容目录。
这里的配置为：
<Directory />             /代表根目录
    AllowOverride none    不允许重写
    Require all denied    所有的请求都被禁止
</Directory>
说明：这是根目录上的目录访问控制设置，即是在整体上先对目录访问进行控制，需要开通那个访问可以在下面设置
----------

#
# Note that from this point forward you must specifically allow
# particular features to be enabled - so if something's not working as
# you might expect, make sure that you have specifically enabled it
# below.
#

----------

注意：从前面的配置开始，你必须指定明确指定允许能够连接特定的功能。因此在某些不像你预期的那样工作时，确保你已经在下面指定了解决办法。

----------

#
# DocumentRoot: The directory out of which you will serve your
# documents. By default, all requests are taken from this directory, but
# symbolic links and aliases may be used to point to other locations.
#

DocumentRoot "E:/svn/trunk/MoliServer30/api/public"
<Directory "E:/svn/trunk/MoliServer30/api/public">

----------

文档目录：在此文件目录里你将提供你的网页文档。默认的，所有的请求都从这个目录里拿到。但是符号链接和别名也许可以被用来指定到其他的地址。
这里的配置为
DocumentRoot "E:/svn/trunk/MoliServer30/api/public"
<Directory "E:/svn/trunk/MoliServer30/api/public">
说明：指的是网站访问的网页的存放位置
----------

    #
    # Possible values for the Options directive are "None", "All",
    # or any combination of:
    #   Indexes Includes FollowSymLinks SymLinksifOwnerMatch ExecCGI MultiViews
    #
    # Note that "MultiViews" must be named *explicitly* --- "Options All"
    # doesn't give it to you.
    #
    # The Options directive is both complicated and important.  Please see
    # http://httpd.apache.org/docs/2.4/mod/core.html#options
    # for more information.

----------

可以作为这条指令的可能的值为："None", "All"或者任何以下的结合：包括FollowSymLinks SymLinksifOwnerMatch ExecCGI MultiViews索引。
注意：MultiViews必须被明确的定义为Options All从而不将它给你。这里的配置为Options Indexes FollowSymLinks Includes ExecCGI。Options指令既复杂又重要，请查看http://httpd.apache.org/docs/2.4/mod/core.html#options以获得更多信息
说明：Options：配置在特定目录使用哪些特性，常用的值和基本含义如下：
ExecCGI: 在该目录下允许执行CGI脚本。
FollowSymLinks: 在该目录下允许文件系统使用符号连接。
Indexes: 当用户访问该目录时，如果用户找不到DirectoryIndex指定的主页文件(例如index.html),则返回该目录下的文件列表给用户。
SymLinksIfOwnerMatch: 当使用符号连接时，只有当符号连接的文件拥有者与实际文件的拥有者相同时才可以访问。

----------

    #
    Options Indexes FollowSymLinks Includes ExecCGI

    #
    # AllowOverride controls what directives may be placed in .htaccess files.
    # It can be "All", "None", or any combination of the keywords:
    #   AllowOverride FileInfo AuthConfig Limit
    #
    AllowOverride All

    #
    # Controls who can get stuff from this server.
    #
    Require all granted

----------

AllowOverride指令控制着那些指令可以被写入.htaccess文件。可能值为："All", "None"或者任何关键词的组合：AllowOverride FileInfo AuthConfig Limit
这里的配置为：AllowOverride All

此命令控制着谁能够从此服务器获得东西，这里的配置为Require all granted
说明：AllowOverride：允许存在于.htaccess文件中的指令类型(.htaccess文件名是可以改变的，其文件名由AccessFileName指令决定)：
None: 当AllowOverride被设置为None时。不搜索该目录下的.htaccess文件（可以减小服务器开销）。
All: 在.htaccess文件中可以使用所有的指令。
----------

</Directory>
<IfModule alias_module>
  Alias /api "E:/svn/trunk/MoliServer30/api/public"
</IfModule>

----------

如果加载了alias_module模块，那么别名为/api "E:/svn/trunk/MoliServer30/api/public"

----------

#
# DirectoryIndex: sets the file that Apache will serve if a directory
# is requested.
#
<IfModule dir_module>
    DirectoryIndex index.php index.pl index.cgi index.asp index.shtml index.html index.htm \
                   default.php default.pl default.cgi default.asp default.shtml default.html default.htm \
                   home.php home.pl home.cgi home.asp home.shtml home.html home.htm
</IfModule>

----------

DirectoryIndex：设置如果请求了一个目录，apache提供的文件
如果dir_module模块被加载了，那么 DirectoryIndex包括：index.php index.pl index.cgi index.asp index.shtml index.html index.htm \
                   default.php default.pl default.cgi default.asp default.shtml default.html default.htm \
                   home.php home.pl home.cgi home.asp home.shtml home.html home.htm

----------

#
# The following lines prevent .htaccess and .htpasswd files from being 
# viewed by Web clients. 
#
<Files ".ht*">
    Require all denied
</Files>

----------

下面的这条命令可以阻止网络客户端访问.htaccess 和 .htpasswd 文件

----------

#
# ErrorLog: The location of the error log file.
# If you do not specify an ErrorLog directive within a <VirtualHost>
# container, error messages relating to that virtual host will be
# logged here.  If you *do* define an error logfile for a <VirtualHost>
# container, that host's errors will be logged there and not here.
#
ErrorLog "logs/error.log"

----------

错误日志：错误日志的存放地址。如果你没有再<VirtualHost>块中指出特定的错误日志地址，关于virtual host的错误信息将会被记录在这里。如果你确实为<VirtualHost>块定义了一个错误记录文件，那么那台虚拟主机的错误日子将会被记载在那里而不是这里。
这里的配置为：ErrorLog "logs/error.log"
说明：错误日志的保存位置

----------

#
# LogLevel: Control the number of messages logged to the error_log.
# Possible values include: debug, info, notice, warn, error, crit,
# alert, emerg.
#
LogLevel warn

----------

LogLevel:控制被记录到错误日志的错误信息级别。可能的值有：debug, info, notice, warn, error, crit,alert, emerg.这里的配置为：LogLevel warn
说明：被记录的错误的级别

----------

<IfModule log_config_module>
    #
    # The following directives define some format nicknames for use with
    # a CustomLog directive (see below).
    #
    LogFormat "%h %l %u %t \"%r\" %>s %b \"%{Referer}i\" \"%{User-Agent}i\"" combined
    LogFormat "%h %l %u %t \"%r\" %>s %b" common

    <IfModule logio_module>
      # You need to enable mod_logio.c to use %I and %O
      LogFormat "%h %l %u %t \"%r\" %>s %b \"%{Referer}i\" \"%{User-Agent}i\" %I %O" combinedio
    </IfModule>

    #
    # The location and format of the access logfile (Common Logfile Format).
    # If you do not define any access logfiles within a <VirtualHost>
    # container, they will be logged here.  Contrariwise, if you *do*
    # define per-<VirtualHost> access logfiles, transactions will be
    # logged therein and *not* in this file.
    #
    #CustomLog "logs/access.log" common

    #
    # If you prefer a logfile with access, agent, and referer information
    # (Combined Logfile Format) you can use the following directive.
    #
    CustomLog "logs/access.log" combined
</IfModule>

----------

如果加载了log_config_module模块，下面的指令定义了一些能够在客户日志中使用的格式化的别名（查看一下内容）：
这里的配置为：LogFormat "%h %l %u %t \"%r\" %>s %b \"%{Referer}i\" \"%{User-Agent}i\"" combined
    LogFormat "%h %l %u %t \"%r\" %>s %b" common
如果同时加载了logio_module模块，你需要开启mod_logio.c以使用%I 和 %O。此处的配置为LogFormat "%h %l %u %t \"%r\" %>s %b \"%{Referer}i\" \"%{User-Agent}i\" %I %O" combinedio。
关于连接的日志文件的地址和格式。如果你没有在<VirtualHost>块中定义任何的关于连接的日志文件，那么他们将会被记录在这里。反之，如果你确实为<VirtualHost>块定义了一个错误记录文件，那么那台虚拟主机的错误日子将会被记载在那里而不是这里。
CustomLog "logs/access.log" common，如果你偏好一个记录access, agent, and referer的日志文件（整合文件格式），你可以使用下面这条指令。CustomLog "logs/access.log" combined
说明：
格式中的各个参数如下：
%h –客户端的ip地址或主机名
%l –The 这是由客户端 identd 判断的RFC 1413身份，输出中的符号 "-" 表示此处信息无效。
%u –由HTTP认证系统得到的访问该网页的客户名。有认证时才有效，输出中的符号 "-" 表示此处信息无效。
%t –服务器完成对请求的处理时的时间。
"%r" –引号中是客户发出的包含了许多有用信息的请求内容。
%>s –这个是服务器返回给客户端的状态码。
%b –最后这项是返回给客户端的不包括响应头的字节数。
"%{Referer}i" –此项指明了该请求是从被哪个网页提交过来的。
"%{User-Agent}i" –此项是客户浏览器提供的浏览器识别信息。
下面是一段访问日志的实例：
192.168.10.22 – bearzhang [10/Oct/2005:16:53:06 +0800] "GET /download/ HTTP/1.1" 200 1228
192.168.10.22 – - [10/Oct/2005:16:53:06 +0800] "GET /icons/blank.gif HTTP/1.1" 304 -
192.168.10.22 – - [10/Oct/2005:16:53:06 +0800] "GET /icons/back.gif HTTP/1.1" 304 -

----------

<IfModule alias_module>
    #
    # Redirect: Allows you to tell clients about documents that used to 
    # exist in your server's namespace, but do not anymore. The client 
    # will make a new request for the document at its new location.
    # Example:
    # Redirect permanent /foo http://www.example.com/bar

    #
    # Alias: Maps web paths into filesystem paths and is used to
    # access content that does not live under the DocumentRoot.
    # Example:
    # Alias /webpath /full/filesystem/path
    #
    # If you include a trailing / on /webpath then the server will
    # require it to be present in the URL.  You will also likely
    # need to provide a <Directory> section to allow access to
    # the filesystem path.

    #
    # ScriptAlias: This controls which directories contain server scripts. 
    # ScriptAliases are essentially the same as Aliases, except that
    # documents in the target directory are treated as applications and
    # run by the server when requested rather than as documents sent to the
    # client.  The same rules about trailing "/" apply to ScriptAlias
    # directives as to Alias.
    #
    ScriptAlias /cgi-bin/ "D:/xampp/cgi-bin/"

</IfModule>

----------

如果加载了alias_module模块，
Redirect:允许你告知浏览器通常存放在这里的访问稳定不在放在这里了而放在了别处。客户端将会建立一个到新的地址的新的请求以。示例：Redirect permanent /foo http://www.example.com/bar，这个还是永久重定向。
Alias:指定网络路径到文件系统路径，并且此文件路径通常不在网站文档目录下。示例：Alias /webpath /full/filesystem/path
如果你在/webpath后面加上了斜线/，那么服务器也要求在url地址中包含这个斜线。你可能还要提供一个<Directory>部分来指定允许连接到此文件系统目录。
ScriptAlias:这个选项控制哪些目录包含服务器脚本。ScriptAliases本质上与Aliases选项相同。除了目录里的文档被客户端访问时被当做应用来运行而不是被当做文档发送到客户端。关于尾随的/的规则与上面的相同。这里的配置为：ScriptAlias /cgi-bin/ "D:/xampp/cgi-bin/"

----------

<IfModule cgid_module>
    #
    # ScriptSock: On threaded servers, designate the path to the UNIX
    # socket used to communicate with the CGI daemon of mod_cgid.
    #
    #Scriptsock cgisock
</IfModule>

----------

如果加载了cgid_module模块，
ScriptSock:在线程服务器上，为了与mod_cgid的CGI程序进行交流而指定的路径
示例配置：Scriptsock cgisock

----------

#
# "D:/xampp/cgi-bin" should be changed to whatever your ScriptAliased
# CGI directory exists, if you have that configured.
#
<Directory "D:/xampp/cgi-bin">
    AllowOverride All
    Options None
    Require all granted
</Directory>

----------

D:/xampp/cgi-bin应该被改为ScriptAliased CGI目录存在的地方，如果你有那个配置项的话

----------

<IfModule mime_module>
    #
    # TypesConfig points to the file containing the list of mappings from
    # filename extension to MIME-type.
    #
    TypesConfig conf/mime.types

    #
    # AddType allows you to add to or override the MIME configuration
    # file specified in TypesConfig for specific file types.
    #
    #AddType application/x-gzip .tgz
    #
    # AddEncoding allows you to have certain browsers uncompress
    # information on the fly. Note: Not all browsers support this.
    #
    #AddEncoding x-compress .Z
    #AddEncoding x-gzip .gz .tgz
    #
    # If the AddEncoding directives above are commented-out, then you
    # probably should define those extensions to indicate media types:
    #
    AddType application/x-compress .Z
    AddType application/x-gzip .gz .tgz

    #
    # AddHandler allows you to map certain file extensions to "handlers":
    # actions unrelated to filetype. These can be either built into the server
    # or added with the Action directive (see below)
    #
    # To use CGI scripts outside of ScriptAliased directories:
    # (You will also need to add "ExecCGI" to the "Options" directive.)
    #
    AddHandler cgi-script .cgi .pl .asp

    # For type maps (negotiated resources):
    #AddHandler type-map var

    #
    # Filters allow you to process content before it is sent to the client.
    #
    # To parse .shtml files for server-side includes (SSI):
    # (You will also need to add "Includes" to the "Options" directive.)
    #
    AddType text/html .shtml
    AddOutputFilter INCLUDES .shtml
</IfModule>

----------

如果加载了mime_module模块，
TypesConfig指定了文件扩展名到MIME-type的包含在映射列表中的文件的映射关系，这里的配置为TypesConfig conf/mime.types
AddType允许你为在TypesConfig中特定的文件类型增加和重写MIME配置文件，配置实例：AddType application/x-gzip .tgz。
AddEncoding允许你传输某些特定浏览器的解压缩信息。注意：并不是所有的浏览器都支持这一点。示例配置：AddEncoding x-compress .Z，AddEncoding x-gzip .gz .tgz
如果上面的AddEncoding指令被注释掉了，那么你可能应该定义哪些扩展名以指明媒体类型。示例配置： AddType application/x-compress .Z
，AddType application/x-gzip .gz .tgz
AddHandler允许你映射特定扩展名的文件的到指定的handlers：操作与文件类型无关。这些能够要么被内置于服务器或者下面的Action指令。
为了使用ScriptAliased指定的路径之外的CGI脚本，（你还需要增加ExecCGI到选项指令），这里的配置为：AddHandler cgi-script .cgi .pl .asp
为了类型映射（谈判资源），示例配置：AddHandler type-map var
Filters允许你在将内容发送到浏览器之前process content它。
为了在服务器端解析.shtml文件（你还要将Includes增加到Options指令），这里的配置为：AddType text/html .shtml，AddOutputFilter INCLUDES .shtml

----------

#
# The mod_mime_magic module allows the server to use various hints from the
# contents of the file itself to determine its type.  The MIMEMagicFile
# directive tells the module where the hint definitions are located.
#
<IfModule mime_magic_module>
    #
    # The mod_mime_magic module allows the server to use various hints from the
    # contents of the file itself to determine its type.  The MIMEMagicFile
    # directive tells the module where the hint definitions are located.
    #
    MIMEMagicFile "conf/magic"
</IfModule>

mod_mime_magic此模块允许服务器使用来自文件内容的各种提示来决定文件的类型。MIMEMagicFile指令告诉此模块这些提示定义在哪里
这里的配置为MIMEMagicFile "conf/magic"。

#
# Customizable error responses come in three flavors:
# 1) plain text 2) local redirects 3) external redirects
#
# Some examples:
#ErrorDocument 500 "The server made a boo boo."
#ErrorDocument 404 /missing.html
#ErrorDocument 404 "/cgi-bin/missing_handler.pl"
#ErrorDocument 402 http://www.example.com/subscription_info.html
#

#
# MaxRanges: Maximum number of Ranges in a request before
# returning the entire resource, or one of the special
# values 'default', 'none' or 'unlimited'.
# Default setting is to accept 200 Ranges.
#MaxRanges unlimited

#
# EnableMMAP and EnableSendfile: On systems that support it, 
# memory-mapping or the sendfile syscall may be used to deliver
# files.  This usually improves server performance, but must
# be turned off when serving from networked-mounted 
# filesystems or if support for these functions is otherwise
# broken on your system.
# Defaults: EnableMMAP On, EnableSendfile Off
#
#EnableMMAP off
#EnableSendfile off

支持3种可抵定制的错误响应
1.纯文本2.本地重定向3.外部重定向
一些实例：
#ErrorDocument 500 "The server made a boo boo."
#ErrorDocument 404 /missing.html
#ErrorDocument 404 "/cgi-bin/missing_handler.pl"
#ErrorDocument 402 http://www.example.com/subscription_info.html
MaxRanges:在返回整个资源之前一个请求的最大范围数，是一些值中的其中一个：default', 'none' or 'unlimited'.默认的设置为接受200个，实例配置：MaxRanges unlimited
EnableMMAP and EnableSendfile:在支持它的系统上，内存映射或者sendfile系统调用可能用来分发文件。这通常能够提升服务的性能，但是必须在提供网络安装文件系统或者如果支持这些功能会损坏你的系统时关闭这条指令。默认的值为：EnableMMAP On, EnableSendfile Off。示例配置：EnableMMAP off，EnableSendfile off

# Supplemental configuration
#
# The configuration files in the conf/extra/ directory can be 
# included to add extra features or to modify the default configuration of 
# the server, or you may simply copy their contents here and change as 
# necessary.

补充配置
在conf/extra/文件目录中的配置文件可以被包含进来以增加额外的特性或者改变服务器的默认配置，或者你可以简单的拷贝他们的内容然后按需要在哪里改变他们。以下的设置就是将其他配置文件包含进来。

# Server-pool management (MPM specific)
Include conf/extra/httpd-mpm.conf

# Multi-language error messages
Include conf/extra/httpd-multilang-errordoc.conf

# Fancy directory listings
Include conf/extra/httpd-autoindex.conf

# Language settings
Include conf/extra/httpd-languages.conf

# User home directories
Include conf/extra/httpd-userdir.conf

# Real-time info on requests and configuration
Include conf/extra/httpd-info.conf

# Virtual hosts   虚拟主机配置
#Include conf/extra/httpd-vhosts.conf

# Local access to the Apache HTTP Server Manual   本地连接到apache 的http服务器手册
#Include conf/extra/httpd-manual.conf

# Distributed authoring and versioning (WebDAV)   
#Attention! WEB_DAV is a security risk without a new userspecific configuration for a secure authentifcation 
#Include conf/extra/httpd-dav.conf

# Various default settings    各种默认配置
#Include conf/extra/httpd-default.conf
# Implements a proxy/gateway for Apache.
Include "conf/extra/httpd-proxy.conf"
# Various default settings
Include "conf/extra/httpd-default.conf"
# XAMPP settings
Include "conf/extra/httpd-xampp.conf"

# Configure mod_proxy_html to understand HTML4/XHTML1
<IfModule proxy_html_module>
Include conf/extra/proxy-html.conf
</IfModule>

加载mod_proxy_html配置和以便能够处理HTML4/XHTML1

# Secure (SSL/TLS) connections
Include conf/extra/httpd-ssl.conf
#
# Note: The following must must be present to support
#       starting without SSL on platforms with no /dev/random equivalent
#       but a statically compiled-in mod_ssl.
#
<IfModule ssl_module>
SSLRandomSeed startup builtin
SSLRandomSeed connect builtin
</IfModule>
安全 ssl或者tls连接
Include conf/extra/httpd-ssl.conf
注意：没有ssl连接，在没有/dev/random配置单静态的编译进了mod_ssl的平台上启动是必须不被支持的。
<IfModule ssl_module>
SSLRandomSeed startup builtin
SSLRandomSeed connect builtin
</IfModule>

#
# uncomment out the below to deal with user agents that deliberately
# violate open standards by misusing DNT (DNT *must* be a specific
# end-user choice)
#
#<IfModule setenvif_module>
#BrowserMatch "MSIE 10.0;" bad_DNT
#</IfModule>
#<IfModule headers_module>
#RequestHeader unset DNT env=bad_DNT
#</IfModule>

注释掉下面的以便于解决故意或者违反开放标准的滥用DNT的用户浏览器（DNT必须作为特定用户的最终选择）
如果加载了setenvif_module模块，
BrowserMatch "MSIE 10.0;" bad_DNT
</IfModule>
如果加载了headers_module模块，
RequestHeader unset DNT env=bad_DNT


# XAMPP: We disable operating system specific optimizations for a listening
# socket by the http protocol here. IE 64 bit make problems without this.

AcceptFilter http none
AcceptFilter https none
# AJP13 Proxy
<IfModule mod_proxy.c>
<IfModule mod_proxy_ajp.c>
Include "conf/extra/httpd-ajp.conf"
</IfModule>
</IfModule>

xampp:我们禁用了操作系统通过http协议来特定的优化监听socket，IE 64位没有此项的话会有问题
AcceptFilter http none
AcceptFilter https none

AJP13代理
加载模块，则加载配置