package com.example.android_19_1_sqlite;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class MySQLiteOpenHelper extends SQLiteOpenHelper
{
    private final static String TAG = "====";
    public final static String dbName="MyDbTwo";
    private final static int dbVersion = 1;
    public final static String tdlNameProducts = "Products";
    public final static String colProductName = "name";
    public final static String colProductsPrice = "price";
    public final static String colProductsWeight = "weight";
    final static String colId = "_id";

    public MySQLiteOpenHelper(Context context)
    {
        super(context, MySQLiteOpenHelper.dbName, null, MySQLiteOpenHelper.dbVersion);
    }
    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1)
    {

    }
    @Override
    public void onCreate (SQLiteDatabase db)
    {
        Log.d(TAG, "onCreate: "+db.getPath());
        //---Создание таблицы
        String query = "CREATE TABLE Products("+
                "_id integer not null primary key autoincrement, "+
                "name text, "+
                "price real, "+
                "weight integer)";

        db.execSQL(query);

        //----Добавление продуктов
        ContentValues row = new ContentValues();
        row.put(colProductName, "Snicers");
        row.put(colProductsPrice, 12.5);
        row.put(colProductsWeight, 45);
        db.insert(MySQLiteOpenHelper.tdlNameProducts, null, row);

        row = new ContentValues();
        row.put(colProductName, "Mars");
        row.put(colProductsPrice, 14.0);
        row.put(colProductsWeight, 55);
        db.insert(MySQLiteOpenHelper.tdlNameProducts, null, row);

        row = new ContentValues();
        row.put(colProductName, "Bounty");
        row.put(colProductsPrice, 16.5);
        row.put(colProductsWeight, 50);
        db.insert(MySQLiteOpenHelper.tdlNameProducts, null, row);

    }
}
