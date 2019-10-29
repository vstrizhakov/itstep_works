package com.example.android_18_1_sqlite;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class MySQLiteOpenHelper extends SQLiteOpenHelper
{
    private final static String TAG = "===";
    private  final static String dbName = "MyDbOne";
    private  final static int bdVersion = 1;

    public MySQLiteOpenHelper(Context context)
    {
        super(context, MySQLiteOpenHelper.dbName, null, MySQLiteOpenHelper.bdVersion);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
        Log.d(TAG, "onCreate: "+db.getPath());
        //----------Создание таблицы
        String query = "CREATE TABLE Products("+
                "id integer not null primary key autoincrement, "+
                "name text, "+
                "price real, "+
                "weight integer)";

        db.execSQL(query);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        Log.d(TAG, "onUpgrade: "+db.getPath()+"; olVersion: "+oldVersion+"; newVersion: "+newVersion);
    }
    @Override
    public void onOpen(SQLiteDatabase db)
    {
        Log.d(TAG, "onOpen: "+db.getPath());
    }
    @Override
    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        Log.d(TAG, "onDowngrade: "+db.getPath()+"; olVersion: "+oldVersion+"; newVersion: "+newVersion);
    }
}
