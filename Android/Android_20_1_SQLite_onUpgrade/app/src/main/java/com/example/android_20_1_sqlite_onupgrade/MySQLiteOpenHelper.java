package com.example.android_20_1_sqlite_onupgrade;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class MySQLiteOpenHelper extends SQLiteOpenHelper
{
    private final static String TAG = "====MySQLite";
    public final static String dbName="MyDbThree";
    public final static int dbVersion = 1;
//    public final static int dbVersion = 2;

    /**
     * Название таблиц и столбцов
     */
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
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        Log.d(TAG, "onUpgrade: "+db.getPath()+"; oldVersion: "+oldVersion+", newVersion: "+newVersion);
        if(oldVersion == 1 && newVersion == 2)
        {
            /**
             * Создание таблици категория
             */
            db.execSQL("CREATE TABLE Categories (" +
                    "_id integer not null primary key autoincrement," +
                    "name text)");
            ContentValues row = new ContentValues();
            row.put("name", "Кондитерские изделия");
            db.insert("Categories", null,row);

            row = new ContentValues();
            row.put("name", "Молочные изделия");
            db.insert("Categories", null,row);

            row = new ContentValues();
            row.put("name", "Напитки");
            db.insert("Categories", null,row);
            /**
             * Модификация таблицы Products
             */
            db.execSQL("ALTER TABLE Products ADD COLUMN id_category integer");

            row = new ContentValues();
            row.put("id_category", 1);
            db.update(MySQLiteOpenHelper.tdlNameProducts, row, null,null);//всем продуктам категория 1 (так как условия = null)
        }
    }
    @Override
    public void onCreate (SQLiteDatabase db)
    {
        Log.d(TAG, "onCreate: "+db.getPath());
        //---Создание таблицы
        db.execSQL("CREATE TABLE Products("+
                "_id integer not null primary key autoincrement, "+
                "name text, "+
                "price real, "+
                "weight integer)");

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

        row = new ContentValues();
        row.put(colProductName, "Loin");
        row.put(colProductsPrice, 17.5);
        row.put(colProductsWeight, 60);
        db.insert(MySQLiteOpenHelper.tdlNameProducts, null, row);

    }
    @Override
    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion)//откат версии
    {
        Log.d(TAG, "onUpgrade: "+db.getPath()+"; oldVersion: "+oldVersion+", newVersion: "+newVersion);
        if(oldVersion == 2 && newVersion == 1)
        {
            /**
             * Переносим данные из одной таблицы в другую и удаляем старую таблицу
             */
            db.execSQL("ALTER TABLE Products RENAME TO OldProducts");
            db.execSQL("CREATE TABLE Products(" +
                    "_id integer not null primary key autoincrement, " +
                    "name text, " +
                    "price real, " +
                    "weight integer)");
            Cursor C = db.query("OldProducts", null, null,null,null,null,null);
            if(C.moveToFirst())
            {
                int indexID = C.getColumnIndex(MySQLiteOpenHelper.colId);
                int indexName = C.getColumnIndex(MySQLiteOpenHelper.colProductName);
                int indexPrice = C.getColumnIndex(MySQLiteOpenHelper.colProductsPrice);
                int indexWeight = C.getColumnIndex(MySQLiteOpenHelper.colProductsWeight);

                do
                {
                    ContentValues row = new ContentValues();
                    row.put(MySQLiteOpenHelper.colId, C.getInt(indexID));
                    row.put(MySQLiteOpenHelper.colProductName, C.getString(indexName));
                    row.put(MySQLiteOpenHelper.colProductsPrice, C.getDouble(indexPrice));
                    row.put(MySQLiteOpenHelper.colProductsWeight, C.getInt(indexWeight));

                    db.insert(MySQLiteOpenHelper.tdlNameProducts, null, row);
                }
                while (C.moveToNext());
            }
            /**
             * Удаляем категории
             */
            db.execSQL("DROP TABLE Categories");
            /**
             * Удаляем старую таблицу
             */
            db.execSQL("DROP TABLE OldProducts");
        }
    }
}
