# React + Asp.NET Core Entity Framework + MySql.

# Using technologies

## MySQL server

**https://dev.mysql.com/downloads/installer/**

### Windows – Start and Stop MySQL Server

1.  Open 'Run' Window by using Win key + R.
2.  Type 'services.msc'
3.  Now search for MySQL service based on the version that is installed.
4.  Click on 'stop', 'start' or 'restart' the service option.

### Move the MySQL 8.0 Database

1.  Stop the MySQL 8.0 Service.
2.  Edit the my.ini file in c:\Program Data\MySQL\MySQL Server 8.0.
3.  Edit datadir=C:/Program Data/Mysql/Mysql Server 8.0\Data to Datadir=D:/Mysql Database\Data.

    *Also you can change datadir with MySQL Workbench*
    
5.  Save the file and close.

    **If using Notepad to edit the file, a BOM (Byte Order Mark) will be added to the encoding which will cause MySQL to not read the file correctly. To correct this, ensure you save the file in an ANSI format. If using Notepad ++ saving the file in standard UTF-8 (without BOM)  will work correctly.**
    
5.  Create the directory and set permissions.

    **Something like D:\MyProjects\GameShopStudentTeamProject\Data.**
    
6.  Create all directories needed before \Data.
7.  Give Full Control to the NETWORK SERVICE user.
8.  Copy the Data Directory folder from the Program Data folder.
9.  Paste the Data Directory folder into your newly created directory.
10. Restart the MySQL 8.0 service.

## Database manage tool: MySQL Workbench or PopSQL (optional).

## Other matherials:

   Add MySql.Data:
   
![MySql_NetCore](https://github.com/KonstantinKorobko/GameShopStudentTeamProject/assets/122153674/f1ed9955-5c32-43b3-b162-b6433dc60ce7)

