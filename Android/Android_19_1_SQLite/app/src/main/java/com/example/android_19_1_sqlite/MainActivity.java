package com.example.android_19_1_sqlite;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.media.MediaRouter;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.MultiAutoCompleteTextView;
import android.widget.SimpleCursorAdapter;
import android.widget.Toast;

import java.io.File;

public class MainActivity extends AppCompatActivity
{
    private MySQLiteOpenHelper dbHelper;
    private SimpleCursorAdapter adapter;
    /**
     * Для подсветки выбранного элемента списка
     */
    private int nrmColor = Color.rgb(0xFF, 0xFF, 0xFF);
    private int slctColor = Color.rgb(0xB0, 0xFF, 0xC0);
    private int curItem = -1;
    private View curView = null;
    SQLiteDatabase db;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);



        this.dbHelper = new MySQLiteOpenHelper(this);

        this.db = this.dbHelper.getWritableDatabase();

        Cursor C = db.query(MySQLiteOpenHelper.tdlNameProducts, null,null,null,null,null,MySQLiteOpenHelper.colProductName);
        ListView LV = this.findViewById(R.id.lvMain);

        this.adapter = new SimpleCursorAdapter(this, R.layout.product_item, C,
                new String[]{
                            MySQLiteOpenHelper.colProductName,
                            MySQLiteOpenHelper.colProductsPrice,
                            MySQLiteOpenHelper.colProductsWeight},
                new int[]{
                            R.id.tvName,
                            R.id.tvPrice,
                            R.id.tvWeight },0)
        {
            @Override
            public View getView(int position, View convertView, ViewGroup parent)
            {
                View view = super.getView(position, convertView, parent);
                if(position==MainActivity.this.curItem)
                {
                    view.setBackgroundColor(MainActivity.this.slctColor);
                    MainActivity.this.curView = view;
                }
                else
                    view.setBackgroundColor(MainActivity.this.nrmColor);
                return view;
            }
        };

        LV.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long id)
            {
                if (MainActivity.this.curItem != -1)
                {
                    MainActivity.this.curView.setBackgroundColor(MainActivity.this.nrmColor);
                }
                MainActivity.this.curView = view;
                MainActivity.this.curItem = position;
                MainActivity.this.curView.setBackgroundColor(MainActivity.this.slctColor);
            }
        });

        LV.setAdapter(this.adapter);

//Удаление базы данных
//        if(Build.VERSION.SDK_INT >= 16)
//        {
//            db.deleteDatabase(new File(db.getPath()));
//        }
//        else
//        {
//            File file = new File(db.getPath());
//            file.delete();
//        }


    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.menu_main, menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem menuItem)
    {
        switch (menuItem.getItemId())
        {
            case R.id.action_add:
                {
                ContentValues row = new ContentValues();
                row.put(MySQLiteOpenHelper.colProductName, "Twix" + (int) (Math.random() * 1000));
                row.put(MySQLiteOpenHelper.colProductsPrice, (int) (Math.random() * 1000) / 10f);
                row.put(MySQLiteOpenHelper.colProductsWeight, (int) (Math.random() * 1000));
                long rowID = MainActivity.this.db.insert(MySQLiteOpenHelper.tdlNameProducts, null, row);
                String msg = (rowID != -1) ? "Добавлено успешно" : "Ошибка добавления!";
                Toast.makeText(MainActivity.this, msg, Toast.LENGTH_SHORT).show();

                /**
                 * Обновление курсора
                 */
                if (rowID != 1)
                    this.adapter.swapCursor(db.query(MySQLiteOpenHelper.tdlNameProducts, null, null, null, null, null, MySQLiteOpenHelper.colProductName)).close();
                }
                break;
            case R.id.action_del:
                {
                if (this.curItem == -1)
                {
                    Toast.makeText(MainActivity.this, "Продукт не выбран", Toast.LENGTH_SHORT).show();
                    break;
                }
                Cursor C = this.adapter.getCursor();
                C.moveToPosition(this.curItem);
                int indexId = C.getColumnIndex(MySQLiteOpenHelper.colId);
                int rowAffected = db.delete(MySQLiteOpenHelper.tdlNameProducts, "_id=?", new String[]{String.valueOf(C.getInt(indexId))});

                Toast.makeText(MainActivity.this, "Удалено строк : " + rowAffected, Toast.LENGTH_SHORT).show();
                this.curItem = -1;
                /**
                 * Обновление курсора
                 */
                this.adapter.swapCursor(db.query(MySQLiteOpenHelper.tdlNameProducts, null, null, null, null, null, MySQLiteOpenHelper.colProductName)).close();
                }
                break;
            case R.id.action_edt:
                if(this.curItem == -1)
                {
                    Toast.makeText(MainActivity.this, "Продукт не выбран", Toast.LENGTH_SHORT).show();
                    break;
                }
                Cursor C = this.adapter.getCursor();
                C.moveToPosition(this.curItem);

                int indexID = C.getColumnIndex(MySQLiteOpenHelper.colId);
                int indexName = C.getColumnIndex(MySQLiteOpenHelper.colProductName);
                int indexPrice = C.getColumnIndex(MySQLiteOpenHelper.colProductsPrice);
                int indexWeight = C.getColumnIndex(MySQLiteOpenHelper.colProductsWeight);

                String strID = C.getString(indexID);
                String strName = C.getString(indexName);
                String strPrice = C.getString(indexPrice);
                String strWeight = C.getString(indexWeight);

                strName+="!";
                strPrice+="1";
                strWeight+="2";

                ContentValues row = new ContentValues();
                row.put(MySQLiteOpenHelper.colProductName, strName);
                row.put(MySQLiteOpenHelper.colProductsPrice, strPrice);
                row.put(MySQLiteOpenHelper.colProductsWeight, strWeight);

                int cnt = db.update(MySQLiteOpenHelper.tdlNameProducts, row, "_id=?", new String[]{strID});
                Toast.makeText(MainActivity.this, "Обновлено строк: "+cnt, Toast.LENGTH_SHORT).show();

                if(cnt>0)
                {
                    this.adapter.swapCursor(db.query(MySQLiteOpenHelper.tdlNameProducts,
                            null, null,null,null, null,
                            MySQLiteOpenHelper.colProductName+" desc")).close(); //--desc - по убыванию
                }
                break;
        }
        return true;
    }
    @Override
    public void onDestroy()
    {
        super.onDestroy();
        this.adapter.getCursor().close();
    }
}
