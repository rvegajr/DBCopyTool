# DBCopyTool
SQL Server Database Copy Tool (originally from Codeplex)

Project Description
Simple tool to copy databases from one SQL Server to another.

Copies a sql server database from one server to another by backing it up, copying the backup file to the destination server and restoring the database.

Please rate and comment! 

01_copytool.JPG
http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63006
![alt text](http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63006)

You need
at least one sql server :-)
rights to access the backup directories and data directories of the sql server(s) over the network

Usage:
Start the tool :-)
go to the servers tab and configure your servers (servers are stored in config.xml)

02_settings.JPG
http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63007
![alt text](http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63007)

03_addserver.JPG
http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63008
![alt text](http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63008)
go to the copy database tab
copy your database(s)

...or use it as commandline tool. Just start it with the four parameters: from_server to_server from_database to_database (the servers must exist in the config file)

Example:
dbcopytool.exe 192.168.1.1 192.168.1.2 MyDb MyDbCopy

db_copy_tool_cmd.JPG
http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63297
![alt text](http://download-codeplex.sec.s-msft.com/Download?ProjectName=dbcopytool&DownloadId=63297)
report bugs and ideas :-)

Further description (german) and some description of the code can be found here: http://www.sql-asp-blog.de/category/SQL-Server-Database-Copy-Tool.aspx
Last edited Sep 13, 2009 at 2:33 PM by Jetro223, version 20