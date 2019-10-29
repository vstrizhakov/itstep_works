package com.example.android_17_1_creatingsecondactivityinapplication;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class ActivityTwo extends AppCompatActivity
{
    private EditText edtOne;
    private EditText edtTwo;
    private TextView tvResult;
    public  final static String KEY_CALC_RESULT = "key_calc_result";
    //Ключ для извлечения первого числа, передвваемого в активность
    public  final static String KEY_CALC_ONE = "key_calc_one";
    //Ключ для извлечения второго числа, передвваемого в активность
    public  final static String KEY_CALC_TWO = "key_calc_two";
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calc_fragment);

        this.edtOne = this.findViewById(R.id.edtOne);
        this.edtTwo = this.findViewById(R.id.edtTwo);
        this.tvResult = this.findViewById(R.id.edtRes);

        Intent intent = this.getIntent();
        String strOne = intent.getStringExtra(ActivityTwo.KEY_CALC_ONE);
        if(strOne != null)
            this.edtOne.setText(strOne);
        String strTwo = intent.getStringExtra(ActivityTwo.KEY_CALC_TWO);
        if(strOne != null)
            this.edtTwo.setText(strTwo);
    }
    public void btnCalckClick(View view)
    {
        try
        {
            double one = Double.parseDouble(this.edtOne.getText().toString());
            double two = Double.parseDouble(this.edtTwo.getText().toString());
            double result = 0;
            switch (view.getId())
            {
                case R.id.btnPlus:
                    result = one+two;
                    break;
                case R.id.btnMinus:
                    result = one-two;
                    break;
                case R.id.btnMultiply:
                    result = one*two;
                    break;
                case R.id.btnDivide:
                    result = (two!=0)?one/two:0;
                    break;
            }
            //-----Формируем данные для возврата в другую активность----
            Intent resIntent = new Intent();
            resIntent.putExtra(ActivityTwo.KEY_CALC_RESULT, String.valueOf(result));
            this.setResult(ActivityTwo.RESULT_OK, resIntent);
            this.finish();//закрываем активность
            //-----
        }
        catch (Exception e)
        {
            Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }
}
