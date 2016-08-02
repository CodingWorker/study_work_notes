	# Redis configuration file example
	
	# Note on units: when memory size is needed, it is possible to specify
	# it in the usual form of 1k 5GB 4M and so forth:
	#
	# 1k => 1000 bytes
	# 1kb => 1024 bytes
	# 1m => 1000000 bytes
	# 1mb => 1024*1024 bytes
	# 1g => 1000000000 bytes
	# 1gb => 1024*1024*1024 bytes
	#
	# units are case insensitive so 1GB 1Gb 1gB are all the same.

>redis配置文件示例

>注意单位：当需要指定内存大小时，可能需要以通常的方式特别指定，如1k 5GB 4M等等；

>单位换算

	# 1k => 1000 bytes
	# 1kb => 1024 bytes
	# 1m => 1000000 bytes
	# 1mb => 1024*1024 bytes
	# 1g => 1000000000 bytes
	# 1gb => 1024*1024*1024 bytes

-------------
	
	################################## INCLUDES ###################################
	
	# Include one or more other config files here.  This is useful if you
	# have a standard template that goes to all Redis servers but also need
	# to customize a few per-server settings.  Include files can include
	# other files, so use this wisely.
	#
	# Notice option "include" won't be rewritten by command "CONFIG REWRITE"
	# from admin or Redis Sentinel. Since Redis always uses the last processed
	# line as value of a configuration directive, you'd better put includes
	# at the beginning of this file to avoid overwriting config change at runtime.
	#
	# If instead you are interested in using includes to override configuration
	# options, it is better to use include as the last line.
	#
	# include .\path\to\local.conf
	# include c:\path\to\other.conf

>包含配置文件

>此处可以包含一个或者更多的其他的配置文件，如果你对所有的redis服务器有一个同一的标准配置，有希望对于某些个性化的配置时这会非常得有用。包含文件能够引入其他文件，因此应该善于使用这一配置项。
>注意：在这里的配置不会被admin或者Redis Sentinelde的CONFIG REWRITE命令重写。因为redis总是使用最后一行作为配置质量值，因此最好将包含文件写在此配置文件的开头以免在运行阶段被重写。
>相反，如果你热衷于使用此包含项来重写redis的配置项，最好将此包含文件作为此配置为济南的最后一行。
	
	################################ GENERAL  #####################################
	
	# On Windows, daemonize and pidfile are not supported.
	# However, you can run redis as a Windows service, and specify a logfile.
	# The logfile will contain the pid. 
	
	# Accept connections on the specified port, default is 6379.
	# If port 0 is specified Redis will not listen on a TCP socket.
	port 6379
	
	# TCP listen() backlog.
	#
	# In high requests-per-second environments you need an high backlog in order
	# to avoid slow clients connections issues. Note that the Linux kernel
	# will silently truncate it to the value of /proc/sys/net/core/somaxconn so
	# make sure to raise both the value of somaxconn and tcp_max_syn_backlog
	# in order to get the desired effect.
	tcp-backlog 511
	
	# By default Redis listens for connections from all the network interfaces
	# available on the server. It is possible to listen to just one or multiple
	# interfaces using the "bind" configuration directive, followed by one or
	# more IP addresses.
	#
	# Examples:
	#
	# bind 192.168.1.100 10.0.0.1
	# bind 127.0.0.1

>通用配置项
>
>在windows平台上，守护进程和进程id文件是不被支持的。
>然而，你可以运行redis作为windows的一个服务，然后指定一个文件来存储pid

>在指定的端口上接受连接，默认的端口号为6379
>如果指定此配置项为0那么redis将不会监听TCP socket
>这里的配置为 port 6379

>TCP listen() backlog
>在每秒高请求环境下你需要一个大的backlog以避免出现拖慢客户端连接的问题。注意：Linux kernel将会默认的设置此值为/proc/sys/net/core/somaxconn。所以，确认一下somaxconn and tcp_max_syn_backlog这两个值以获得设计redis时应有的效果。
>这里的配置为tcp-backlog 511

>默认的，redis监听服务器可以获得的所有所有网络接口的所有连接。使用bind后跟一个或多个ip地址的配置指令可以指定redis只监听一个或几个接口。
>配置示例：
># bind 192.168.1.100 10.0.0.1
># bind 127.0.0.1

	
	# Specify the path for the Unix socket that will be used to listen for
	# incoming connections. There is no default, so Redis will not listen
	# on a unix socket when not specified.
	#
	# unixsocket /tmp/redis.sock
	# unixsocketperm 700
	
	# Close the connection after a client is idle for N seconds (0 to disable)
	timeout 0

>为Unix socket指定路径，用来监听外来的连接。这一配置项没有默认值，因此如果不特别指定的话，redis不会监听unix socket。
>配置示例：
>unixsocket /tmp/redis.sock

>配置一个客户端多长时间不操作关闭连接（设置为0则不会关闭）
>这里的配置为：timeout 0

	# TCP keepalive.
	#
	# If non-zero, use SO_KEEPALIVE to send TCP ACKs to clients in absence
	# of communication. This is useful for two reasons:
	#
	# 1) Detect dead peers.
	# 2) Take the connection alive from the point of view of network
	#    equipment in the middle.
	#
	# On Linux, the specified value (in seconds) is the period used to send ACKs.
	# Note that to close the connection the double of the time is needed.
	# On other kernels the period depends on the kernel configuration.
	#
	# A reasonable value for this option is 60 seconds.
	tcp-keepalive 0

>TCP持久连接
>如果此配置项不为0，缺少连接时使用SO_KEEPALIVE 发送TCP ACKs到客户端，之所以这样是有原因的：
>检测dead的网路节点
>从中间网络设备的观点保持连接

>在linux上，此配置项的值（单位为秒）是被用来发送ACKs的周期。注意：如果要关闭连接则需要双倍此配置项的时间。
>在其他kernels上，这个周期依赖于kernel的配置。
>此配置想的一个合理的值为60秒
>这里的配置为  tcp-keepalive 0，指定为0应该是不保持持久连接
	
	# Specify the server verbosity level.
	# This can be one of:
	# debug (a lot of information, useful for development/testing)
	# verbose (many rarely useful info, but not a mess like the debug level)
	# notice (moderately verbose, what you want in production probably)
	# warning (only very important / critical messages are logged)
	loglevel notice
	
	# Specify the log file name. Also 'stdout' can be used to force
	# Redis to log on the standard output. 
	logfile ""
	
	# To enable logging to the Windows EventLog, just set 'syslog-enabled' to 
	# yes, and optionally update the other syslog parameters to suit your needs.
	# If Redis is installed and launched as a Windows Service, this will 
	# automatically be enabled.
	# syslog-enabled no
	
	# Specify the source name of the events in the Windows Application log.
	# syslog-ident redis
	
	# Set the number of databases. The default database is DB 0, you can select
	# a different one on a per-connection basis using SELECT <dbid> where
	# dbid is a number between 0 and 'databases'-1
	databases 16

>指定服务器的日志记录级别
>这一配置项的值可以为以下中的一个：
>debug（大量信息，对开发和测试非常有用）
>verbose（许多有用的信息，但不会像debug level下的信息那样混乱）
>notice（中级的verbose，是在生产环境下你可能需要的）
>warning（这会记录非常重要/关键的信息）
>这里的配置为  loglevel notice

>指定日志的文件名，也可以设置为stdout以强制redis将日志信息写在显示在标准输出上
>这里的配置为   logfile ""

>为了能够将日志写入windows的事件日志，只需要设置syslog-enabled的值为yes，也可以更新其他的配置项来满足你的需求。如果redis被作为windows的一个服务启动，那么这些项将自动被启用
>配置示例：syslog-enabled no

>在windows应用日志中指定事件的源的名字
>配置示例：syslog-ident redis

>设置数据库的数量，默认的数据库为0号数据库，通过使用命令 select 数据库的号，在每一次连接的基础上你可以选择一个其他的数据库，数据库号是一个介于0和此处配置值减1的数字
>这里的配置为   databases 16

	
	################################ SNAPSHOTTING  ################################
	#
	# Save the DB on disk:
	#
	#   save <seconds> <changes>
	#
	#   Will save the DB if both the given number of seconds and the given
	#   number of write operations against the DB occurred.
	#
	#   In the example below the behaviour will be to save:
	#   after 900 sec (15 min) if at least 1 key changed
	#   after 300 sec (5 min) if at least 10 keys changed
	#   after 60 sec if at least 10000 keys changed
	#
	#   Note: you can disable saving completely by commenting out all "save" lines.
	#
	#   It is also possible to remove all the previously configured save
	#   points by adding a save directive with a single empty string argument
	#   like in the following example:
	#
	#   save ""
	
	save 900 1
	save 300 10
	save 60 10000

>快照
>将数据保存在磁盘上
>命令语法： save 秒数 写操作数量
>如果对数据的操作触发了这这两个配置值：设置的秒数和写操作的数量，那么就会保存数据库

>下面的命令的说明（可以多个命令叠加）：
>save 900 1 表示900秒（15分钟）后，如果至少一个key改变了（更新值或者增加了key）就会触发一次保存数据
>save 300 10  表示300秒（5分钟）后，如果至少有10个key改变了，就会触发一次保存数据
>save 60 10000  表示60秒后，如果至少10000个key改变了就会触发一次保存数据

>注意：你可以通过注释掉save命令行来完全禁用保存数据
>你可向下面示例的那样在save指令后跟一个空的字符串来移除该条命令之前设置的save配置，如果save ""，则此命令之前的对save的设置都会被移除
>这里的配置为： save 900 1  save 300 10   save 60 10000
	
	# By default Redis will stop accepting writes if RDB snapshots are enabled
	# (at least one save point) and the latest background save failed.
	# This will make the user aware (in a hard way) that data is not persisting
	# on disk properly, otherwise chances are that no one will notice and some
	# disaster will happen.
	#
	# If the background saving process will start working again Redis will
	# automatically allow writes again.
	#
	# However if you have setup your proper monitoring of the Redis server
	# and persistence, you may want to disable this feature so that Redis will
	# continue to work as usual even if there are problems with disk,
	# permissions, and so forth.
	stop-writes-on-bgsave-error yes

>默认的，如果启用了RDB快照，redis将会停止接受写入。而且最新的后台保存进程会失败。这将会使得用户觉得数据没有在磁盘中持久化，没有人注意到其他的变化，而且一些灾难性的事件将要发生。

>如果后台保存进程再次开始工作，那么redis将自动的再次允许写操作。

>然而，如果你合适的监控器来监控redis服务器的持久化操作，你也许想要关闭此特性以便于redis能够像往常一样继续执行写操作，及时磁盘、权限等存在某些错误或者问题。
>这里的配置为stop-writes-on-bgsave-error yes，即在RDB将数据写入磁盘时关闭了写的功能
	
	# Compress string objects using LZF when dump .rdb databases?
	# For default that's set to 'yes' as it's almost always a win.
	# If you want to save some CPU in the saving child set it to 'no' but
	# the dataset will likely be bigger if you have compressible values or keys.
	rdbcompression yes

>该指令控制在存储rdb数据时是否使用LZF压缩来压缩字符串
>默认的这一个配置项设置为yes,因为这样总是没有错误的。如果你想在复制数据时节省一些CPU使用率，将它设置为no。但是如果你可以压缩的key或者value而不压缩，那么数据就可能很大。

	
	# Since version 5 of RDB a CRC64 checksum is placed at the end of the file.
	# This makes the format more resistant to corruption but there is a performance
	# hit to pay (around 10%) when saving and loading RDB files, so you can disable it
	# for maximum performances.
	#
	# RDB files created with checksum disabled have a checksum of zero that will
	# tell the loading code to skip the check.
	rdbchecksum yes

>由于第5版的RDB的一个CRC64校验值被放在了文件的末尾。这使样式更加的抗崩溃。但是在保存和加载RDB文件时，这是以降低一些性能的（大约10%）为代价的。因此为了追求最高的性能表现你可以禁用它。
>禁用了校验值的RDB文件在创建时创建了一个值为0的校验值。这个值将会告诉加载的程序跳过此校验。
>这里的配置为 rdbchecksum yes
	
	# The filename where to dump the DB
	dbfilename dump.rdb

>这条指令指示数据吧保存的文件名（下面的配置指令指明文件的路径）
>这里的配置为 dbfilename dump.rdb
	
	# The working directory.
	#
	# The DB will be written inside this directory, with the filename specified
	# above using the 'dbfilename' configuration directive.
	# 
	# The Append Only File will also be created inside this directory.
	# 
	# Note that you must specify a directory here, not a file name.
	dir ./

>工作目录
>数据将会被写入工作目录，以在上面的配置指令里指明的文件名。附加的文件也可以在这个文件目录里创建
>注意：在这里你必须指明一个文件目录而不是文件名。
>这里的配置为  dir ./
	
	################################# REPLICATION #################################
	
	# Master-Slave replication. Use slaveof to make a Redis instance a copy of
	# another Redis server. A few things to understand ASAP about Redis replication.
	#
	# 1) Redis replication is asynchronous, but you can configure a master to
	#    stop accepting writes if it appears to be not connected with at least
	#    a given number of slaves.
	# 2) Redis slaves are able to perform a partial resynchronization with the
	#    master if the replication link is lost for a relatively small amount of
	#    time. You may want to configure the replication backlog size (see the next
	#    sections of this file) with a sensible value depending on your needs.
	# 3) Replication is automatic and does not need user intervention. After a
	#    network partition slaves automatically try to reconnect to masters
	#    and resynchronize with them.
	#
	# slaveof <masterip> <masterport>

>主从配置
>主从复制。使用slaveof指令指明一个redis服务器立即复制另一个redis的数据。关于redis的主从复制需要尽可能快的了解的知识。
>redis的主从复制是异步的，如果当他每有与任何一台配置的从服务器连接的话，但是你可一个配置你的主服务器停止接受写入的功能。
>如果同步连接断了一个相对很小的时间，redis从服务器能够实现部分同步主服务器的数据。你也学要根据你的需要想配置这个复制日志（更多详细信息下面会讲到）的一个合理的大小。
>复制是自动的而且不需要创建。在从服务器自动的试图连接主服务器并且联通之后，就会开始同步数据。
>配置语法为   slaveof <masterip> <masterport>
	
	# If the master is password protected (using the "requirepass" configuration
	# directive below) it is possible to tell the slave to authenticate before
	# starting the replication synchronization process, otherwise the master will
	# refuse the slave request.
	#
	# masterauth <master-password>

>如果主服务器是密码保护的（使用下面的requirepass配置指令来设置），他可能在开始复制的同步过程之前需要从服务器的验证。否则主服务器会拒绝从服务器的请求。
>配置的语法为   masterauth <master-password>
	
	# When a slave loses its connection with the master, or when the replication
	# is still in progress, the slave can act in two different ways:
	#
	# 1) if slave-serve-stale-data is set to 'yes' (the default) the slave will
	#    still reply to client requests, possibly with out of date data, or the
	#    data set may just be empty if this is the first synchronization.
	#
	# 2) if slave-serve-stale-data is set to 'no' the slave will reply with
	#    an error "SYNC with master in progress" to all the kind of commands
	#    but to INFO and SLAVEOF.
	#
	slave-serve-stale-data yes


>当从服务器与主服务器失去了连接或者当同步工作正在进行，从服务器可以进行两种不同的操作：
>1)如果slave-serve-stale-data指令被设置为yes（这也是默认值），那么从服务器将会仍然响应客户端请求的数据，可能这时使用的是过期的数据（也可能不是，因为有些数据并没有过期）。或者，如果这是第一次同步，那么被请求的数据在从服务器可能是个空值（在从服务器上还不存在接受请求就会返回空值）
>2）如果指令slave-serve-stale-data被设置为no，那么从服务器会对任何除了info和slaveof命令外的请求响应一个SYNC with master in progress（正在于主服务器同步数据）的错误。
>这里的配置为  slave-serve-stale-data yes。即在同步的同时从服务器也会继续接受数据请求，只是这时返回的可能是过期的数据。
	
	# You can configure a slave instance to accept writes or not. Writing against
	# a slave instance may be useful to store some ephemeral data (because data
	# written on a slave will be easily deleted after resync with the master) but
	# may also cause problems if clients are writing to it because of a
	# misconfiguration.
	#
	# Since Redis 2.6 by default slaves are read-only.
	#
	# Note: read only slaves are not designed to be exposed to untrusted clients
	# on the internet. It's just a protection layer against misuse of the instance.
	# Still a read only slave exports by default all the administrative commands
	# such as CONFIG, DEBUG, and so forth. To a limited extent you can improve
	# security of read only slaves using 'rename-command' to shadow all the
	# administrative / dangerous commands.
	slave-read-only yes

你可以配置从服务器是否接受写入的命令（即从服务器是否只接受读命令，而不执行写的操作）。对一个从服务器禁止写的功能可能在存储一些非常短暂的数据时会非常得有用（因为这类数据很容易在重新连接主服务器上同步数据时被删除，因为数据过期时间很短，因此这次写入了数据，而在此同步数据时可能已经过期，从而又得删除数据）。但是由于某些错误的配置，如果客户端向其写入数据时可能会导致一些问题。
自从Redis 2.6以来，这一配配置项默认为只读read-only。
注意：设置为只读的redis服务器在网络上不会暴露给不可信的客户端。它只是防止乱用从服务器的一个保护层。尽管一个只读的从服务器默认输出所有的主服务器命令，例如 CONFIG, DEBUG等等。但是，为了限制，你也可以通过rename-command命令来屏蔽掉所有主服务器的危险的命令以提高只读从服务器的安全性。
这里的配置为   slave-read-only yes

	# Replication SYNC strategy: disk or socket.
	#
	# -------------------------------------------------------
	# WARNING: DISKLESS REPLICATIONSLAGEOF IS EXPERIMENTAL CURRENTLY
	# -------------------------------------------------------
	#
	# New slaves and reconnecting slaves that are not able to continue the replication
	# process just receiving differences, need to do what is called a "full
	# synchronization". An RDB file is transmitted from the master to the slaves.
	# The transmission can happen in two different ways:
	#
	# 1) Disk-backed: The Redis master creates a new process that writes the RDB
	#                 file on disk. Later the file is transferred by the parent
	#                 process to the slaves incrementally.
	# 2) Diskless: The Redis master creates a new process that directly writes the
	#              RDB file to slave sockets, without touching the disk at all.
	#
	# With disk-backed replication, while the RDB file is generated, more slaves
	# can be queued and served with the RDB file as soon as the current child producing
	# the RDB file finishes its work. With diskless replication instead once
	# the transfer starts, new slaves arriving will be queued and a new transfer
	# will start when the current one terminates.
	#
	# When diskless replication is used, the master waits a configurable amount of
	# time (in seconds) before starting the transfer in the hope that multiple slaves
	# will arrive and the transfer can be parallelized.
	#
	# With slow disks and fast (large bandwidth) networks, diskless replication
	# works better.
	repl-diskless-sync no

同步复制的策略：磁盘还是socket
警告：目前，无磁盘复制还处于试验阶段。
采用全同步：新的从服务器和再次连接的从服务器不会继续进行复制，它仅仅接受改变的的数据和需要去复制的。在同步数据时，一个RDB文件会被从主服务器传递到从服务器。这个传输能够以两种不同的方式进行：
1）Disk-backed基于磁盘的：在这个模式下，主服务器redis会创建一个新的进程来在磁盘上写入RDB文件。之后，父进程会逐渐的将此文件传输到从服务器端。
2）Diskless非磁盘形式：在这种模式下，主服务器redis会创建一个新的进程来直接将RDB文件写入到从服务器的sockets，而根本不会涉及磁盘。
在基于磁盘的形式下，当RDB文件已经被生成后，大多数的从服务器可以进入队列，并且在子进程完成它生成RDB文件的工作后立即开始请求RDB文件。在无磁盘同步模式下则想法，一旦新的传输开始，新连接的redis从服务器会被编入队列，在当前的传输终止的时候会开始新的传输。
当使用无磁盘形式的时候，在开始传输工作之前主服务器会等到一个配置的时间（单位为秒），以期望多数的服务器到达，并且传输能够并行化。
在磁盘写入较慢而网络状况较好（高带宽）的情况下，无磁盘同步模式工作的更好。
这里的配置为  repl-diskless-sync no

	# When diskless replication is enabled, it is possible to configure the delay
	# the server waits in order to spawn the child that trnasfers the RDB via socket
	# to the slaves.
	#
	# This is important since once the transfer starts, it is not possible to serve
	# new slaves arriving, that will be queued for the next RDB transfer, so the server
	# waits a delay in order to let more slaves arrive.
	#
	# The delay is specified in seconds, and by default is 5 seconds. To disable
	# it entirely just set it to 0 seconds and the transfer will start ASAP.
	repl-diskless-sync-delay 5

当开启了无磁盘模式后，可能需要配置主服务器的延时时间以产生大量的子进程来通过连接从服务器的socket传输RDB文件。
这是重要的，因为一旦传输开始主服务器就不会为新加入的服务器服务。从服务器会被编入下一次RDB文件传输的队列。因此为了让更多的从服务器到达主服务器会等到一段时间。
这个被指定的延时时间是以秒为单位的，而且默认是5秒。为了完全禁用它，只需要将它设置为0，从而传输将会尽快开始
这里的配置为 repl-diskless-sync-delay 5，即生成完RDB文件后延时5秒项从服务器传输数据
	
	# Slaves send PINGs to server in a predefined interval. It's possible to change
	# this interval with the repl_ping_slave_period option. The default value is 10
	# seconds.
	#
	# repl-ping-slave-period 10
	
	# The following option sets the replication timeout for:
	#
	# 1) Bulk transfer I/O during SYNC, from the point of view of slave.
	# 2) Master timeout from the point of view of slaves (data, pings).
	# 3) Slave timeout from the point of view of masters (REPLCONF ACK pings).
	#
	# It is important to make sure that this value is greater than the value
	# specified for repl-ping-slave-period otherwise a timeout will be detected
	# every time there is low traffic between the master and the slave.
	#
	# repl-timeout 60

在预定义的时间间隔，从服务器会向主服务器发送ping命令。可以通过配置repl_ping_slave_period选项来改变这个时间间隔。默认的时间间隔是10秒。
示例配置为 repl-ping-slave-period 10
下面的选项设置从服务器尝试连接主服务器的timeout,之所以配置这个选项是因为：
1）在从服务器的角度，在同步阶段形成大的I/O(而不是一有点久复制点）
2）在从服务器的角度（数据角度和ping命令），管理timeout
3）从主服务器的角度设置从服务器的连接timeout（应答ACK给ping命令）
重要的是，确保这个时间比repl-ping-slave-period这个指令配置的时间长，否则在主服务器和从服务器之间的网速不好时，每一次都会到达timeout命令。

	# Disable TCP_NODELAY on the slave socket after SYNC?
	#
	# If you select "yes" Redis will use a smaller number of TCP packets and
	# less bandwidth to send data to slaves. But this can add a delay for
	# the data to appear on the slave side, up to 40 milliseconds with
	# Linux kernels using a default configuration.
	#
	# If you select "no" the delay for data to appear on the slave side will
	# be reduced but more bandwidth will be used for replication.
	#
	# By default we optimize for low latency, but in very high traffic conditions
	# or when the master and slaves are many hops away, turning this to "yes" may
	# be a good idea.
	repl-disable-tcp-nodelay no

这个选项配置在数据同步完成后是否停止tcp连接。
如果你配置此项为yes，那么redis会使用一个小量的tcp包，并且占用很少的带宽来发送到从服务器。但是在从服务器端可以为这个发送的时间设置一个延时显现（即不是立即显示此数据，而是经过一段时间）使用默认的配置的话,在linux平台上会高达40微秒。
如果你在从服务器端为此选项设置为no,那么将不会有延时，但是为了连接需要更多的带宽。
默认的，我们倾向于低延时。但是在非常大的传输环境中，或者主服务器和从服务器经常出故障，那么将此项设置为yes会是一个好得主意。
这里的配置为  repl-disable-tcp-nodelay no
	
	# Set the replication backlog size. The backlog is a buffer that accumulates
	# slave data when slaves are disconnected for some time, so that when a slave
	# wants to reconnect again, often a full resync is not needed, but a partial
	# resync is enough, just passing the portion of data the slave missed while
	# disconnected.
	#
	# The bigger the replication backlog, the longer the time the slave can be
	# disconnected and later be able to perform a partial resynchronization.
	#
	# The backlog is only allocated once there is at least a slave connected.
	#
	# repl-backlog-size 1mb

这个选项设置同步backlog的大小。backlog是一个一段时间内当从服务器失去连接时，用来收集从服务器数据的缓存。因此，当一个从服务器想再次连接时，一个全同步就不是必须的了，部分同步就已经足够了。只需要将从服务器失去连接时丢失的数据发送到从服务器即可。
这个backlog文件越大，那么从服务器就可以失去连接更多的时间。再次联通后，就可以开始部分同步。
backlog只在至少一台从服务器连接时才收据数据。
这里的配置示例为  repl-backlog-size 1mb  
	
	# After a master has no longer connected slaves for some time, the backlog
	# will be freed. The following option configures the amount of seconds that
	# need to elapse, starting from the time the last slave disconnected, for
	# the backlog buffer to be freed.
	#
	# A value of 0 means to never release the backlog.
	#
	# repl-backlog-ttl 3600

当主服务器与所有的从服务器在一段时间内不连接时，backlog就会被删除。下面的选项是用来配置这个失去连接的时间（单位为秒）。为删除backlog的等待时间，从最后一台从服务器失去连接时开始计时。
示例配置为   repl-backlog-ttl 3600

	
	# The slave priority is an integer number published by Redis in the INFO output.
	# It is used by Redis Sentinel in order to select a slave to promote into a
	# master if the master is no longer working correctly.
	#
	# A slave with a low priority number is considered better for promotion, so
	# for instance if there are three slaves with priority 10, 100, 25 Sentinel will
	# pick the one with priority 10, that is the lowest.
	#
	# However a special priority of 0 marks the slave as not able to perform the
	# role of master, so a slave with priority of 0 will never be selected by
	# Redis Sentinel for promotion.
	#
	# By default the priority is 100.
	slave-priority 100

从服务器的优先级是一个整型数，会在info命令打印出来。他是在一个主服务器不正常工作时，Redis Sentinel（redis哨兵）为了选择一个从服务器作为主服务器的参考。
有一个低优先级的数字设置更被可能转换为主服务器。因此，假如有三台从服务器优先级分比为 10, 100, 和25，那么Sentinel将会选择优先级数字设置为10的那个从服务器，因为它的数字最低。
然而，特别被指定为0的服务器不会被选择作为主服务器，因此Redis Sentinel不会选择一个优先级数字为10的从服务器。
默认的设置是 100
这里的配置是  slave-priority 100

	# It is possible for a master to stop accepting writes if there are less than
	# N slaves connected, having a lag less or equal than M seconds.
	#
	# The N slaves need to be in "online" state.
	#
	# The lag in seconds, that must be <= the specified value, is calculated from
	# the last ping received from the slave, that is usually sent every second.
	#
	# This option does not GUARANTEE that N replicas will accept the write, but
	# will limit the window of exposure for lost writes in case not enough slaves
	# are available, to the specified number of seconds.
	#
	# For example to require at least 3 slaves with a lag <= 10 seconds use:
	#
	# min-slaves-to-write 3
	# min-slaves-max-lag 10
	#
	# Setting one or the other to 0 disables the feature.
	#
	# By default min-slaves-to-write is set to 0 (feature disabled) and
	# min-slaves-max-lag is set to 10.

如果低于N数量的从服务器连接时，主服务器可能会停止接受写入数据（就set新的数据）。或者至少有一个M秒的延时后停止接受写入数据。
这N个从服务器必须是在线状态。
延时的秒数，必须小于等于指定的值，是从接收到了最后一个从服务器的ping命令（一般每一秒发送一次，因为多台服务器都是没10秒发送，这造成了主服务接受ping命令是每个1秒甚至更少）后开始计时的。
这一选项并不会保证N个从服务器接受写命令。但是，会限制丢失写命令的暴露窗口处，以免不数量的从服务器达到指定的秒数。
例如，至少需要连接3个从服务器，延时小于等于10秒，这样设置：
min-slaves-to-write 3
min-slaves-max-lag 10

设置为1另一个设置为0会禁用此特性
默认的min-slaves-to-write会设置为0,（即禁用了此特性），min-slaves-max-lag设置为10秒
	
	################################## SECURITY ###################################
	
	# Require clients to issue AUTH <PASSWORD> before processing any other
	# commands.  This might be useful in environments in which you do not trust
	# others with access to the host running redis-server.
	#
	# This should stay commented out for backward compatibility and because most
	# people do not need auth (e.g. they run their own servers).
	# 
	# Warning: since Redis is pretty fast an outside user can try up to
	# 150k passwords per second against a good box. This means that you should
	# use a very strong password otherwise it will be very easy to break.
	#
	# requirepass foobared
	
	# Command renaming.
	#
	# It is possible to change the name of dangerous commands in a shared
	# environment. For instance the CONFIG command may be renamed into something
	# hard to guess so that it will still be available for internal-use tools
	# but not available for general clients.
	#
	# Example:
	#
	# rename-command CONFIG b840fc02d524045429941cc15f59e41cb7be6c52
	#
	# It is also possible to completely kill a command by renaming it into
	# an empty string:
	#
	# rename-command CONFIG ""
	#
	# Please note that changing the name of commands that are logged into the
	# AOF file or transmitted to slaves may cause problems.

安全
在客户端执行任何其他的命令之前需要提供认证的密码。在你不相信其他连接到主机（正在运行redis服务器）的客户端的环境下这是非常有用的。
为了向后兼容这个选项应该被注释，因为大多数人不需要认证（例如：他们自己运行自己的服务器）
警告：由于redis非常的快，以至于一个外部用户使用一台好的机器可以在一秒钟内执行150次的密码尝试。这意味着你需要一个非常复杂的密码否则密码将会很容易被攻破。
示例配置为：requirepass foobared，这里foobared是密码

命令重命名
在一个共享环境中可能需要改变危险的命令的名字。例如：CONFIG选项可以重命名一些命令使之非常的复杂不容易被猜到。以便于在仅能在内部适应被不能被一般的客户端使用。
例如：示例配置：rename-command CONFIG b840fc02d524045429941cc15f59e41cb7be6c52。也可以通过将命令重命名为空字符串来完全杀掉一个命令（即使得一个命令失效）。如：
rename-command CONFIG ""
请注意：改变了命令的名字会被日志记录进AOF文件中，将它发送给从服务器也许会导致产生一些问题。

	################################### LIMITS ####################################
	
	# Set the max number of connected clients at the same time. By default
	# this limit is set to 10000 clients, however if the Redis server is not
	# able to configure the process file limit to allow for the specified limit
	# the max number of allowed clients is set to the current file limit
	# minus 32 (as Redis reserves a few file descriptors for internal uses).
	#
	# Once the limit is reached Redis will close all the new connections sending
	# an error 'max number of clients reached'.
	#
	# maxclients 10000

限制
设置在同一时间内可以连通的最大客户端数量。默认值为10000个客户端。然而，如果redis服务器不能够配置进程限制文件以允许连接的客户端最大数量，那么这个最大允许连接客户端数量被设置为当前限制文件指定的数量减去32.（因为redis为一些内部的文件解释器提供了服务，这些也算作连接）
一旦数量达到指定的限制值，那么redis服务器会关闭所有的新的连接并发送一个错误信息‘max number of clients reached‘
示例配置为：maxclients 10000
	
	# If Redis is to be used as an in-memory-only cache without any kind of
	# persistence, then the fork() mechanism used by the background AOF/RDB
	# persistence is unnecessary. As an optimization, all persistence can be
	# turned off in the Windows version of Redis. This will redirect heap
	# allocations to the system heap allocator, and disable commands that would
	# otherwise cause fork() operations: BGSAVE and BGREWRITEAOF.
	# This flag may not be combined with any of the other flags that configure
	# AOF and RDB operations.
	# persistence-available [(yes)|no]

如果redis仅仅被用来作为内存的缓存而不做任何的数据持久化，那么在AOF/RDB持久化背景下的fork()机制就不是必须的。作为一个优化，在redis的windows版本里所有持久化操作都能够被关闭。这个将会重定位堆分配到系统的堆分配器。并且还会禁用会导致fork()的操作：如BGSAVE and BGREWRITEAOF.
这个选项不会与配置AOF and RDB操作的选项结合。
示例配置为：persistence-available [(yes)|no]
	
	# Don't use more memory than the specified amount of bytes.
	# When the memory limit is reached Redis will try to remove keys
	# according to the eviction policy selected (see maxmemory-policy).
	#
	# If Redis can't remove keys according to the policy, or if the policy is
	# set to 'noeviction', Redis will start to reply with errors to commands
	# that would use more memory, like SET, LPUSH, and so on, and will continue
	# to reply to read-only commands like GET.
	#
	# This option is usually useful when using Redis as an LRU cache, or to set
	# a hard memory limit for an instance (using the 'noeviction' policy).
	#
	# WARNING: If you have slaves attached to an instance with maxmemory on,
	# the size of the output buffers needed to feed the slaves are subtracted
	# from the used memory count, so that network problems / resyncs will
	# not trigger a loop where keys are evicted, and in turn the output
	# buffer of slaves is full with DELs of keys evicted triggering the deletion
	# of more keys, and so forth until the database is completely emptied.
	#
	# In short... if you have slaves attached it is suggested that you set a lower
	# limit for maxmemory so that there is some free RAM on the system for slave
	# output buffers (but this is not needed if the policy is 'noeviction').
	#
	# WARNING: not setting maxmemory will cause Redis to terminate with an
	# out-of-memory exception if the heap limit is reached.
	#
	# maxmemory <bytes>

不要比指定的数量使用更多的内存。当内存使用达到了内存限制时，redis会选择的内存回收策略来移除某些key，来限制内存的使用。
如果redis根据选定的内存收集错误移除key，或者那个选项被配置为noeviction，那么redis将会开始响应错误信息给会使用较多内存的操作，如set lpush等等。并且会继续响应get命令。
当将redis作为本地缓存或者强制给它设置一个内存限制的情况下，这个选项非常有用。
警告：如果给主服务器设置了内存使用限制并且主服务器连接了从服务器，为了满足从服务器的输出缓冲的大小被从使用的内存数量中减去。因此在某些key被移除时网络问题或者再同步不会触发循环。相反，从服务器的缓冲充满的是被删除的key，触发删除更多的key等等，知道整个数据库被删除为空。
简而言之，如果你有从服务器连接主服务器，建议为内存限制设置一个较低的值。以便于留有一些系统内存供从服务器输出缓冲使用。（但是当内存管理选项设置为noeviction时，则这样设置并不是必须的）
警告：如果不设置内存限制，当连接达到高峰时，达到内存限制时，将会使redis因为内存超出异常而结束。
示例配置为：maxmemory <bytes>

	# MAXMEMORY POLICY: how Redis will select what to remove when maxmemory
	# is reached. You can select among five behaviors:
	# 
	# volatile-lru -> remove the key with an expire set using an LRU algorithm
	# allkeys-lru -> remove any key according to the LRU algorithm
	# volatile-random -> remove a random key with an expire set
	# allkeys-random -> remove a random key, any key
	# volatile-ttl -> remove the key with the nearest expire time (minor TTL)
	# noeviction -> don't expire at all, just return an error on write operations
	# 
	# Note: with any of the above policies, Redis will return an error on write
	#       operations, when there are no suitable keys for eviction.
	#
	#       At the date of writing these commands are: set setnx setex append
	#       incr decr rpush lpush rpushx lpushx linsert lset rpoplpush sadd
	#       sinter sinterstore sunion sunionstore sdiff sdiffstore zadd zincrby
	#       zunionstore zinterstore hset hsetnx hmset hincrby incrby decrby
	#       getset mset msetnx exec sort
	#
	# The default is:
	#
	# maxmemory-policy volatile-lru

内存管理政策：指的是当达到最大内存使用限制时，redis将会选择移除哪些keys
volatile-lru:使用LRU算法删除带有过期时间的keys
allkeys-lru:使用LRU算法删除任何一个key
volatile-random：随机删除设置了过期时间的key
allkeys-random:随机删除任何一个key
volatile-ttl:删除最接近过期时间的key
noeviction:根本不过期任何的key,当写入新的key时返回错误，不能写入
注意：以上任何一个内存管理政策，当没有合适的key被移除时，在写入操作时redis都会返回一个错误信息
写这些命令的日期：set setnx setex append
incr decr rpush lpush rpushx lpushx linsert lset rpoplpush sadd
sinter sinterstore sunion sunionstore sdiff sdiffstore zadd zincrby
zunionstore zinterstore hset hsetnx hmset hincrby incrby decrby
getset mset msetnx exec sort
默认的设置为：
maxmemory-policy volatile-lru
	
	# LRU and minimal TTL algorithms are not precise algorithms but approximated
	# algorithms (in order to save memory), so you can select as well the sample
	# size to check. For instance for default Redis will check three keys and
	# pick the one that was used less recently, you can change the sample size
	# using the following configuration directive.
	#
	# maxmemory-samples 3

LRU和最小TTL算法不是精确地算法，但是是近似精确地算法（为了节省内存）。因此你也可以选择一个样本去检查这个问题。例如：默认的redis会选择3个keys并且移除一个近期最少使用的key。使用下面的配置项你可以改变这个样本的数量
示例配置为：maxmemory-samples 3
	
	############################## APPEND ONLY MODE ###############################
	
	# By default Redis asynchronously dumps the dataset on disk. This mode is
	# good enough in many applications, but an issue with the Redis process or
	# a power outage may result into a few minutes of writes lost (depending on
	# the configured save points).
	#
	# The Append Only File is an alternative persistence mode that provides
	# much better durability. For instance using the default data fsync policy
	# (see later in the config file) Redis can lose just one second of writes in a
	# dramatic event like a server power outage, or a single write if something
	# wrong with the Redis process itself happens, but the operating system is
	# still running correctly.
	#
	# AOF and RDB persistence can be enabled at the same time without problems.
	# If the AOF is enabled on startup Redis will load the AOF, that is the file
	# with the better durability guarantees.
	#
	# Please check http://redis.io/topics/persistence for more information.
	
	appendonly no

追加模式
默认的redis异步同步数据，将数据同步到磁盘。在很多应用中这个模式很好。但是redis的进程或者停电问题也许会导致几分钟的写入数据丢失（这依赖于save points配置项）
只追加文件是一个可选择的持久化模式，这一模式提供了更好地持久期。例如：使用默认的同步策略（详细信息参考配置文件接下来的内容），在极端情况下像停电或者在一个单独的吸入操作时redis进程出现了一些错误而操作系统正常工作的情况下，redis能够仅仅丢失一秒的数据。
AOF and RDB持久化策略可以再没有问题的的时候同时被开启。如果AOF在redis启动时开启，那么redis将会加载AOF文件，这个文件能够更好地保证持久化。
请参考：http://redis.io/topics/persistence for more information.
这里的配置为：appendonly no
	
	# The name of the append only file (default: "appendonly.aof")
	appendfilename "appendonly.aof"

追加文件的名字（默认是appendonly.aof）
这里的配置为：appendfilename "appendonly.aof"
	
	# The fsync() call tells the Operating System to actually write data on disk
	# instead of waiting for more data in the output buffer. Some OS will really flush
	# data on disk, some other OS will just try to do it ASAP.
	#
	# Redis supports three different modes:
	#
	# no: don't fsync, just let the OS flush the data when it wants. Faster.
	# always: fsync after every write to the append only log . Slow, Safest.
	# everysec: fsync only one time every second. Compromise.
	#
	# The default is "everysec", as that's usually the right compromise between
	# speed and data safety. It's up to you to understand if you can relax this to
	# "no" that will let the operating system flush the output buffer when
	# it wants, for better performances (but if you can live with the idea of
	# some data loss consider the default persistence mode that's snapshotting),
	# or on the contrary, use "always" that's very slow but a bit safer than
	# everysec.
	#
	# More details please check the following article:
	# http://antirez.com/post/redis-persistence-demystified.html
	#
	# If unsure, use "everysec".
	
	# appendfsync always
	appendfsync everysec
	# appendfsync no

fsync()函数告诉操作系统在磁盘中写入数据而不是等待输出缓冲中有更多的数据。一些操作系统会真的清空磁盘上的数据，而其他的操作系统则立即尝试写入。
redis支持三种不同的模式：
no:不进行fsync，仅仅让操作系统清空数据当他需要那样做时。更快
always:在每一次在追加日志中写入后fsync，慢但是非常的安全。
everysec:每一秒仅仅fsync一次。效率介于前两者之间
默认的是everysec，因为在速度和数据安全性之间那通常是正确的折中。这依赖于你的理解，如果你对no模式放心，为了更好地性能（考虑到默认的持久化模式为快照，你可以忍受一些数据的丢失），那么将会在需要时操作系统会清空输出缓冲。或者相反，使用always模式将会非常的慢但是比everysec要更加的安全。
查看更多的细节，参考：http://antirez.com/post/redis-persistence-demystified.html
如果你不确定的话，使用everysec模式
示例配置为：appendfsync always       appendfsync no
这里的配置为：appendfsync everysec
	
	# When the AOF fsync policy is set to always or everysec, and a background
	# saving process (a background save or AOF log background rewriting) is
	# performing a lot of I/O against the disk, in some Linux configurations
	# Redis may block too long on the fsync() call. Note that there is no fix for
	# this currently, as even performing fsync in a different thread will block
	# our synchronous write(2) call.
	#
	# In order to mitigate this problem it's possible to use the following option
	# that will prevent fsync() from being called in the main process while a
	# BGSAVE or BGREWRITEAOF is in progress.
	#
	# This means that while another child is saving, the durability of Redis is
	# the same as "appendfsync none". In practical terms, this means that it is
	# possible to lose up to 30 seconds of log in the worst scenario (with the
	# default Linux settings).
	# 
	# If you have latency problems turn this to "yes". Otherwise leave it as
	# "no" that is the safest pick from the point of view of durability.
	no-appendfsync-on-rewrite no

当AOF fsync政策被设置为always或者everysec时，后台运行的保存进程（后台进行的保存或者AOF log重写）在磁盘上运行了一个很大的I/O操作。咋一些linux配置中，redis也许会在fsync() call上阻断很长的时间。注意：目前对于这个问题没有解决办法，甚至在不同的线程下执行fsync也会阻断同步的写操作。
为了减轻这个问题，可能需要使用下面的选项：在BGSAVE or BGREWRITEAOF正在运行时，那将会阻止fsync()被调用。
这意味着，但一个子进程正在保存数据时，redis的持久化与appendfsync none相同。在实际周期，这意味着（在linux默认配置下）会丢失高达30秒的日志。
如果你有潜在的问题，将这个选项设置为yes，否则将它设置为no，从持久化角度来看设置为no是最安全的
这里的配置为：no-appendfsync-on-rewrite no
	
	# Automatic rewrite of the append only file.
	# Redis is able to automatically rewrite the log file implicitly calling
	# BGREWRITEAOF when the AOF log size grows by the specified percentage.
	# 
	# This is how it works: Redis remembers the size of the AOF file after the
	# latest rewrite (if no rewrite has happened since the restart, the size of
	# the AOF at startup is used).
	#
	# This base size is compared to the current size. If the current size is
	# bigger than the specified percentage, the rewrite is triggered. Also
	# you need to specify a minimal size for the AOF file to be rewritten, this
	# is useful to avoid rewriting the AOF file even if the percentage increase
	# is reached but it is still pretty small.
	#
	# Specify a percentage of zero in order to disable the automatic AOF
	# rewrite feature.

	auto-aof-rewrite-percentage 100
	auto-aof-rewrite-min-size 64mb

append only file的自动重写配置
当AOF日志的大小以指定的百分比增长时，redis能够隐含的调用函数BGREWRITEAOF来重写日志文件。
它是这样的工作的：当最后一次重写之后，redis记录了AOF文件的大小（如果从重启以来没有重写发生，那么就是用开始时AOF文件的大小）
基本的大小是用来与当前的大小比较的。如果当前的大小比指定的百分比大那么重写操作就会被触发。而且，你需要指定一个AOF文件被重写的最小大小。这有利于避免即使AOF文件以指定的百分比增长了，但是文件仍然很小时重写AOF文件。
指定这个百分比为0以便于禁用AOF重写的特性
这里的配置为auto-aof-rewrite-percentage 100，值得是AOF文件每增长100时就会重写AOF文件，auto-aof-rewrite-min-size 64mb指的是这个特性只有在AOF文件的大小超过64M时才会有效。
	
	# An AOF file may be found to be truncated at the end during the Redis
	# startup process, when the AOF data gets loaded back into memory.
	# This may happen when the system where Redis is running
	# crashes, especially when an ext4 filesystem is mounted without the
	# data=ordered option (however this can't happen when Redis itself
	# crashes or aborts but the operating system still works correctly).
	#
	# Redis can either exit with an error when this happens, or load as much
	# data as possible (the default now) and start if the AOF file is found
	# to be truncated at the end. The following option controls this behavior.
	#
	# If aof-load-truncated is set to yes, a truncated AOF file is loaded and
	# the Redis server starts emitting a log to inform the user of the event.
	# Otherwise if the option is set to no, the server aborts with an error
	# and refuses to start. When the option is set to no, the user requires
	# to fix the AOF file using the "redis-check-aof" utility before to restart
	# the server.
	#
	# Note that if the AOF file will be found to be corrupted in the middle
	# the server will still exit with an error. This option only applies when
	# Redis will try to read more data from the AOF file but not enough bytes
	# will be found.
	aof-load-truncated yes

当AOF数据被记载进了内存，当redis开启的时候会发现AOF文件内容被删除了。当redis正在运行的系统崩溃时会发生此现象。尤其是当一个ext4 文件系统已经加载了但是没有进行data=ordered操作（然而当redis崩溃的时候或者宕机但是操作系统正常工作的时候，这种现象不会发生-即AOF文件内容被删除的情况）
如果AOF文件在最后被发现内容被删除了，那么redis或者产生一个错误后退出，或者尽可能的加载更多的数据（当前默认情况下是如此）然后开启。下面的选项是控制此行为的。
如果aof-load-truncated被设置为yes，被删除的AOF文件会被加载，并且redis服务器会开启并忽略这个记录（这个记录会通知用户这个事件）。否则，如果这个选项被配置为no，redis服务器会宕机并产生错误并且会拒绝重启。当这个选项被设置为no的时候，用户需要在服务器重启之前通过redis-check-aof选项修改正AOF文件。
注意：如果在redis服务器运行中间AOF文件的内容被删除了，那么服务器就会立即退出并产生一个错误。只有在redis希望读到更多的文件但是没有足够多的数据被发现时，这个选项才会被应用。
这里的配置为 aof-load-truncated yes
	
	################################ LUA SCRIPTING  ###############################
	
	# Max execution time of a Lua script in milliseconds.
	#
	# If the maximum execution time is reached Redis will log that a script is
	# still in execution after the maximum allowed time and will start to
	# reply to queries with an error.
	#
	# When a long running script exceeds the maximum execution time only the
	# SCRIPT KILL and SHUTDOWN NOSAVE commands are available. The first can be
	# used to stop a script that did not yet called write commands. The second
	# is the only way to shut down the server in the case a write command was
	# already issued by the script but the user doesn't want to wait for the natural
	# termination of the script.
	#
	# Set it to 0 or a negative value for unlimited execution without warnings.
	lua-time-limit 5000

lua脚本
lua脚本的最大执行时间（以微妙为单位）
如果已经达到了最大执行时间，redis将会记录它-一个脚本在达到最大允许执行时间后仍然在执行并且会对请求返回一个错误。
当一个长时间运行的脚本超过了它的最大执行时间，只有SCRIPT KILL和SHUTDOWN NOSAVE两个命令可以使用。第一个命令常常会停止一个脚本（该脚本不包含写命令）。一旦一个写命令已经被脚本发出并但是用户不想等待自然地停止脚本，第二个命令是唯一可以关闭服务器的方法。
如果将这个下选项设置为0或者一个负值，将不会限制脚本的运行时间并且没有任何警告。
这里的配置为 lua-time-limit 5000
	
	################################ REDIS CLUSTER  ###############################
	#
	# ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	# WARNING EXPERIMENTAL: Redis Cluster is considered to be stable code, however
	# in order to mark it as "mature" we need to wait for a non trivial percentage
	# of users to deploy it in production.
	# ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	#
	# Normal Redis instances can't be part of a Redis Cluster; only nodes that are
	# started as cluster nodes can. In order to start a Redis instance as a
	# cluster node enable the cluster support uncommenting the following:
	#
	# cluster-enabled yes
	
	# Every cluster node has a cluster configuration file. This file is not
	# intended to be edited by hand. It is created and updated by Redis nodes.
	# Every Redis Cluster node requires a different cluster configuration file.
	# Make sure that instances running in the same system do not have
	# overlapping cluster configuration file names.
	#
	# cluster-config-file nodes-6379.conf

redis集群
实验性的警告：redis被看做稳定的code,

	
	# Cluster node timeout is the amount of milliseconds a node must be unreachable
	# for it to be considered in failure state.
	# Most other internal time limits are multiple of the node timeout.
	#
	# cluster-node-timeout 15000
	
	# A slave of a failing master will avoid to start a failover if its data
	# looks too old.
	#
	# There is no simple way for a slave to actually have a exact measure of
	# its "data age", so the following two checks are performed:
	#
	# 1) If there are multiple slaves able to failover, they exchange messages
	#    in order to try to give an advantage to the slave with the best
	#    replication offset (more data from the master processed).
	#    Slaves will try to get their rank by offset, and apply to the start
	#    of the failover a delay proportional to their rank.
	#
	# 2) Every single slave computes the time of the last interaction with
	#    its master. This can be the last ping or command received (if the master
	#    is still in the "connected" state), or the time that elapsed since the
	#    disconnection with the master (if the replication link is currently down).
	#    If the last interaction is too old, the slave will not try to failover
	#    at all.
	#
	# The point "2" can be tuned by user. Specifically a slave will not perform
	# the failover if, since the last interaction with the master, the time
	# elapsed is greater than:
	#
	#   (node-timeout * slave-validity-factor) + repl-ping-slave-period
	#
	# So for example if node-timeout is 30 seconds, and the slave-validity-factor
	# is 10, and assuming a default repl-ping-slave-period of 10 seconds, the
	# slave will not try to failover if it was not able to talk with the master
	# for longer than 310 seconds.
	#
	# A large slave-validity-factor may allow slaves with too old data to failover
	# a master, while a too small value may prevent the cluster from being able to
	# elect a slave at all.
	#
	# For maximum availability, it is possible to set the slave-validity-factor
	# to a value of 0, which means, that slaves will always try to failover the
	# master regardless of the last time they interacted with the master.
	# (However they'll always try to apply a delay proportional to their
	# offset rank).
	#
	# Zero is the only value able to guarantee that when all the partitions heal
	# the cluster will always be able to continue.
	#
	# cluster-slave-validity-factor 10
	
	# Cluster slaves are able to migrate to orphaned masters, that are masters
	# that are left without working slaves. This improves the cluster ability
	# to resist to failures as otherwise an orphaned master can't be failed over
	# in case of failure if it has no working slaves.
	#
	# Slaves migrate to orphaned masters only if there are still at least a
	# given number of other working slaves for their old master. This number
	# is the "migration barrier". A migration barrier of 1 means that a slave
	# will migrate only if there is at least 1 other working slave for its master
	# and so forth. It usually reflects the number of slaves you want for every
	# master in your cluster.
	#
	# Default is 1 (slaves migrate only if their masters remain with at least
	# one slave). To disable migration just set it to a very large value.
	# A value of 0 can be set but is useful only for debugging and dangerous
	# in production.
	#
	# cluster-migration-barrier 1
	
	# By default Redis Cluster nodes stop accepting queries if they detect there
	# is at least an hash slot uncovered (no available node is serving it).
	# This way if the cluster is partially down (for example a range of hash slots
	# are no longer covered) all the cluster becomes, eventually, unavailable.
	# It automatically returns available as soon as all the slots are covered again.
	#
	# However sometimes you want the subset of the cluster which is working,
	# to continue to accept queries for the part of the key space that is still
	# covered. In order to do so, just set the cluster-require-full-coverage
	# option to no.
	#
	# cluster-require-full-coverage yes
	
	# In order to setup your cluster make sure to read the documentation
	# available at http://redis.io web site.
	
	################################## SLOW LOG ###################################
	
	# The Redis Slow Log is a system to log queries that exceeded a specified
	# execution time. The execution time does not include the I/O operations
	# like talking with the client, sending the reply and so forth,
	# but just the time needed to actually execute the command (this is the only
	# stage of command execution where the thread is blocked and can not serve
	# other requests in the meantime).
	# 
	# You can configure the slow log with two parameters: one tells Redis
	# what is the execution time, in microseconds, to exceed in order for the
	# command to get logged, and the other parameter is the length of the
	# slow log. When a new command is logged the oldest one is removed from the
	# queue of logged commands.
	
	# The following time is expressed in microseconds, so 1000000 is equivalent
	# to one second. Note that a negative number disables the slow log, while
	# a value of zero forces the logging of every command.
	slowlog-log-slower-than 10000
	
	# There is no limit to this length. Just be aware that it will consume memory.
	# You can reclaim memory used by the slow log with SLOWLOG RESET.
	slowlog-max-len 128
	
	################################ LATENCY MONITOR ##############################
	
	# The Redis latency monitoring subsystem samples different operations
	# at runtime in order to collect data related to possible sources of
	# latency of a Redis instance.
	#
	# Via the LATENCY command this information is available to the user that can
	# print graphs and obtain reports.
	#
	# The system only logs operations that were performed in a time equal or
	# greater than the amount of milliseconds specified via the
	# latency-monitor-threshold configuration directive. When its value is set
	# to zero, the latency monitor is turned off.
	#
	# By default latency monitoring is disabled since it is mostly not needed
	# if you don't have latency issues, and collecting data has a performance
	# impact, that while very small, can be measured under big load. Latency
	# monitoring can easily be enalbed at runtime using the command
	# "CONFIG SET latency-monitor-threshold <milliseconds>" if needed.
	latency-monitor-threshold 0
	
	############################# Event notification ##############################
	
	# Redis can notify Pub/Sub clients about events happening in the key space.
	# This feature is documented at http://redis.io/topics/notifications
	#
	# For instance if keyspace events notification is enabled, and a client
	# performs a DEL operation on key "foo" stored in the Database 0, two
	# messages will be published via Pub/Sub:
	#
	# PUBLISH __keyspace@0__:foo del
	# PUBLISH __keyevent@0__:del foo
	#
	# It is possible to select the events that Redis will notify among a set
	# of classes. Every class is identified by a single character:
	#
	#  K     Keyspace events, published with __keyspace@<db>__ prefix.
	#  E     Keyevent events, published with __keyevent@<db>__ prefix.
	#  g     Generic commands (non-type specific) like DEL, EXPIRE, RENAME, ...
	#  $     String commands
	#  l     List commands
	#  s     Set commands
	#  h     Hash commands
	#  z     Sorted set commands
	#  x     Expired events (events generated every time a key expires)
	#  e     Evicted events (events generated when a key is evicted for maxmemory)
	#  A     Alias for g$lshzxe, so that the "AKE" string means all the events.
	#
	#  The "notify-keyspace-events" takes as argument a string that is composed
	#  of zero or multiple characters. The empty string means that notifications
	#  are disabled.
	#
	#  Example: to enable list and generic events, from the point of view of the
	#           event name, use:
	#
	#  notify-keyspace-events Elg
	#
	#  Example 2: to get the stream of the expired keys subscribing to channel
	#             name __keyevent@0__:expired use:
	#
	#  notify-keyspace-events Ex
	#
	#  By default all notifications are disabled because most users don't need
	#  this feature and the feature has some overhead. Note that if you don't
	#  specify at least one of K or E, no events will be delivered.
	notify-keyspace-events ""
	
	############################### ADVANCED CONFIG ###############################
	
	# Hashes are encoded using a memory efficient data structure when they have a
	# small number of entries, and the biggest entry does not exceed a given
	# threshold. These thresholds can be configured using the following directives.
	hash-max-ziplist-entries 512
	hash-max-ziplist-value 64
	
	# Similarly to hashes, small lists are also encoded in a special way in order
	# to save a lot of space. The special representation is only used when
	# you are under the following limits:
	list-max-ziplist-entries 512
	list-max-ziplist-value 64
	
	# Sets have a special encoding in just one case: when a set is composed
	# of just strings that happen to be integers in radix 10 in the range
	# of 64 bit signed integers.
	# The following configuration setting sets the limit in the size of the
	# set in order to use this special memory saving encoding.
	set-max-intset-entries 512
	
	# Similarly to hashes and lists, sorted sets are also specially encoded in
	# order to save a lot of space. This encoding is only used when the length and
	# elements of a sorted set are below the following limits:
	zset-max-ziplist-entries 128
	zset-max-ziplist-value 64
	
	# HyperLogLog sparse representation bytes limit. The limit includes the
	# 16 bytes header. When an HyperLogLog using the sparse representation crosses
	# this limit, it is converted into the dense representation.
	#
	# A value greater than 16000 is totally useless, since at that point the
	# dense representation is more memory efficient.
	#
	# The suggested value is ~ 3000 in order to have the benefits of
	# the space efficient encoding without slowing down too much PFADD,
	# which is O(N) with the sparse encoding. The value can be raised to
	# ~ 10000 when CPU is not a concern, but space is, and the data set is
	# composed of many HyperLogLogs with cardinality in the 0 - 15000 range.
	hll-sparse-max-bytes 3000
	
	# Active rehashing uses 1 millisecond every 100 milliseconds of CPU time in
	# order to help rehashing the main Redis hash table (the one mapping top-level
	# keys to values). The hash table implementation Redis uses (see dict.c)
	# performs a lazy rehashing: the more operation you run into a hash table
	# that is rehashing, the more rehashing "steps" are performed, so if the
	# server is idle the rehashing is never complete and some more memory is used
	# by the hash table.
	# 
	# The default is to use this millisecond 10 times every second in order to
	# actively rehash the main dictionaries, freeing memory when possible.
	#
	# If unsure:
	# use "activerehashing no" if you have hard latency requirements and it is
	# not a good thing in your environment that Redis can reply from time to time
	# to queries with 2 milliseconds delay.
	#
	# use "activerehashing yes" if you don't have such hard requirements but
	# want to free memory asap when possible.
	activerehashing yes
	
	# The client output buffer limits can be used to force disconnection of clients
	# that are not reading data from the server fast enough for some reason (a
	# common reason is that a Pub/Sub client can't consume messages as fast as the
	# publisher can produce them).
	#
	# The limit can be set differently for the three different classes of clients:
	#
	# normal -> normal clients including MONITOR clients
	# slave  -> slave clients
	# pubsub -> clients subscribed to at least one pubsub channel or pattern
	#
	# The syntax of every client-output-buffer-limit directive is the following:
	#
	# client-output-buffer-limit <class> <hard limit> <soft limit> <soft seconds>
	#
	# A client is immediately disconnected once the hard limit is reached, or if
	# the soft limit is reached and remains reached for the specified number of
	# seconds (continuously).
	# So for instance if the hard limit is 32 megabytes and the soft limit is
	# 16 megabytes / 10 seconds, the client will get disconnected immediately
	# if the size of the output buffers reach 32 megabytes, but will also get
	# disconnected if the client reaches 16 megabytes and continuously overcomes
	# the limit for 10 seconds.
	#
	# By default normal clients are not limited because they don't receive data
	# without asking (in a push way), but just after a request, so only
	# asynchronous clients may create a scenario where data is requested faster
	# than it can read.
	#
	# Instead there is a default limit for pubsub and slave clients, since
	# subscribers and slaves receive data in a push fashion.
	#
	# Both the hard or the soft limit can be disabled by setting them to zero.
	client-output-buffer-limit normal 0 0 0
	client-output-buffer-limit slave 256mb 64mb 60
	client-output-buffer-limit pubsub 32mb 8mb 60
	
	# Redis calls an internal function to perform many background tasks, like
	# closing connections of clients in timeot, purging expired keys that are
	# never requested, and so forth.
	#
	# Not all tasks are perforemd with the same frequency, but Redis checks for
	# tasks to perform according to the specified "hz" value.
	#
	# By default "hz" is set to 10. Raising the value will use more CPU when
	# Redis is idle, but at the same time will make Redis more responsive when
	# there are many keys expiring at the same time, and timeouts may be
	# handled with more precision.
	#
	# The range is between 1 and 500, however a value over 100 is usually not
	# a good idea. Most users should use the default of 10 and raise this up to
	# 100 only in environments where very low latency is required.
	hz 10
	
	# When a child rewrites the AOF file, if the following option is enabled
	# the file will be fsync-ed every 32 MB of data generated. This is useful
	# in order to commit the file to the disk more incrementally and avoid
	# big latency spikes.
	aof-rewrite-incremental-fsync yes
	
	################################## INCLUDES ###################################
	
	# Include one or more other config files here.  This is useful if you
	# have a standard template that goes to all Redis server but also need
	# to customize a few per-server settings.  Include files can include
	# other files, so use this wisely.
	#
	# include /path/to/local.conf
	# include /path/to/other.conf
