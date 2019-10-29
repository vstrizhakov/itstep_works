package com.example.android_8_2_listview_singlechoice;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity
{
    private String[] month = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август",
            "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        ListView lvMonth = this.findViewById(R.id.lvMonth);
        lvMonth.setChoiceMode(ListView.CHOICE_MODE_SINGLE);
        //android.R.layout.simple_list_item_1 -- стандартный макет
        ArrayAdapter<String> lvAdapter1 = new ArrayAdapter<>(this, android.R.layout.simple_list_item_single_choice, month);
        lvMonth.setAdapter(lvAdapter1);

        lvMonth.setOnItemClickListener(new AdapterView.OnItemClickListener()
        {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l)
            {
                Toast.makeText(MainActivity.this, String.valueOf(i)+" = "+adapterView.getAdapter().getItem(i), Toast.LENGTH_SHORT).show();
            }
        });
    }
    public void btnClick(View view)
    {
        ListView lvMonth = (ListView) this.findViewById(R.id.lvMonth);
        int index = lvMonth.getCheckedItemPosition();
        if(index != -1)
        {
            Toast.makeText(this, lvMonth.getAdapter().getItem(index).toString(), Toast.LENGTH_SHORT).show();
        }
        else
            Toast.makeText(this, "Ничего не выбрано", Toast.LENGTH_SHORT).show();
    }
}
