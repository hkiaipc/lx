@rem
@rem 生成数据库脚本
@rem
@echo ====================
@echo 生成 滦下桑园 数据库脚本
@echo ====================
@echo Press any key to continue, Ctrl+C to break...
@pause > nul

"C:\Program Files\Microsoft SQL Server\MSSQL\Upgrade\scptxfr.exe" /s "(local)" /d LXSYDB /P sa /f .\LXSYDB.sql /q /r /A /E
