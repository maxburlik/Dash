// ConsoleProject.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <windows.h>
#include <sqltypes.h>
#include <sql.h>
#include <sqlext.h>

using namespace std;

void show_error(unsigned int handletype, const SQLHANDLE& handle){
    SQLWCHAR sqlstate[1024];
    SQLWCHAR message[1024];
    if (SQL_SUCCESS == SQLGetDiagRec(handletype, handle, 1, sqlstate, NULL, message, 1024, NULL))
        cout << "Message: " << message << "nSQLSTATE: " << sqlstate << endl;
}

int _tmain(int argc, _TCHAR* argv[])
{
    SQLHANDLE sqlenvhandle;
    SQLHANDLE sqlconnectionhandle;
    SQLHANDLE sqlstatementhandle;
    SQLRETURN retcode;

    if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &sqlenvhandle))
        goto FINISHED;

    if (SQL_SUCCESS != SQLSetEnvAttr(sqlenvhandle, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, 0))
        goto FINISHED;

    if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_DBC, sqlenvhandle, &sqlconnectionhandle))
        goto FINISHED;

    SQLCHAR retconstring[1024];
    switch (SQLDriverConnect(sqlconnectionhandle,
        NULL,
        (SQLCHAR*)"DRIVER={SQL Server};SERVER=localhost, 1433;DATABASE=MyDatabase;UID=sa;PWD=Admin-123;",
        SQL_NTS,
        retconstring,
        1024,
        NULL,
        SQL_DRIVER_NOPROMPT)){
    case SQL_SUCCESS_WITH_INFO:
        show_error(SQL_HANDLE_DBC, sqlconnectionhandle);
        break;
    case SQL_INVALID_HANDLE:
    case SQL_ERROR:
        show_error(SQL_HANDLE_DBC, sqlconnectionhandle);
        goto FINISHED;
    default:
        break;
    }

    if (SQL_SUCCESS != SQLAllocHandle(SQL_HANDLE_STMT, sqlconnectionhandle, &sqlstatementhandle))
        goto FINISHED;

    if (SQL_SUCCESS != SQLExecDirect(sqlstatementhandle, (SQLCHAR*)"select * from testtable", SQL_NTS)){
        show_error(SQL_HANDLE_STMT, sqlstatementhandle);
        goto FINISHED;
    }
    else{
        char name[64];
        char address[64];
        int id;
        while (SQLFetch(sqlstatementhandle) == SQL_SUCCESS){
            SQLGetData(sqlstatementhandle, 1, SQL_C_ULONG, &id, 0, NULL);
            SQLGetData(sqlstatementhandle, 2, SQL_C_CHAR, name, 64, NULL);
            SQLGetData(sqlstatementhandle, 3, SQL_C_CHAR, address, 64, NULL);
            cout << id << " " << name << " " << address << endl;
        }
    }

FINISHED:
    SQLFreeHandle(SQL_HANDLE_STMT, sqlstatementhandle);
    SQLDisconnect(sqlconnectionhandle);
    SQLFreeHandle(SQL_HANDLE_DBC, sqlconnectionhandle);
    SQLFreeHandle(SQL_HANDLE_ENV, sqlenvhandle);

	return 0;
}

