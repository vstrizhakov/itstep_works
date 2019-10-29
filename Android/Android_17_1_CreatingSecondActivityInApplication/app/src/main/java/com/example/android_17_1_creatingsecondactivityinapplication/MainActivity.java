package com.example.android_17_1_creatingsecondactivityinapplication;

import android.app.Activity;
import android.app.ActivityManager;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity
{
    private static final int CALC_RESULT=787;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
    public void btnCalcActivityClick(View e)
    {
        Intent intent = new Intent(this, ActivityTwo.class); // Явный вызов //Контекст класс активности
        this.startActivity(intent);
    }
    public void  btnCalcActivityImplicitClick(View v)
    {
        //---Неявный вызов активности
        Intent intent = new Intent();
        intent.setAction(Intent.ACTION_SEND);
        intent.addCategory(Intent.CATEGORY_DEFAULT);
        intent.setType("text/plain");
        startActivity(intent);
    }
    public void btnCalcActivityResultClick(View v)
    {
        Intent intent = new Intent();
        intent.setAction("com.example.android_17_1_creatingsecondactivityinapplication.ActivityTwo");
        intent.addCategory(Intent.CATEGORY_DEFAULT);

        //---отправляем данные в активность ActivityTwo
        double one = ((int)(Math.random()*10000))/100.0f;
        double two = ((int)(Math.random()*10000))/100.0f;

        intent.putExtra(ActivityTwo.KEY_CALC_ONE, String.valueOf(one));
        intent.putExtra(ActivityTwo.KEY_CALC_TWO, String.valueOf(two));
        //------------------------------------------------------------------
        this.startActivityForResult(intent, MainActivity.CALC_RESULT);//START FOR RESULT
    }
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        if(requestCode == MainActivity.CALC_RESULT)
        {
            if(resultCode == Activity.RESULT_OK)
            {
                String result = data.getStringExtra(ActivityTwo.KEY_CALC_RESULT);

                ((TextView)this.findViewById(R.id.tvResult)).setText(result);
            }
        }
    }
}
