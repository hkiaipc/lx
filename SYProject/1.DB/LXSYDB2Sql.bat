@rem
@rem �������ݿ�ű�
@rem
@echo ====================
@echo ���� ����ɣ԰ ���ݿ�ű�
@echo ====================
@echo Press any key to continue, Ctrl+C to break...
@pause > nul

"C:\Program Files\Microsoft SQL Server\MSSQL\Upgrade\scptxfr.exe" /s "(local)" /d LXSYDB /P sa /f .\LXSYDB.sql /q /r /A /E
