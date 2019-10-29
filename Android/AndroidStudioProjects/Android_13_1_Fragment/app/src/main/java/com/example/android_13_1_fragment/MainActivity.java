package com.example.android_13_1_fragment;

import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity
{

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //---Добавление фрагмента программно
        FragmentManager fragmentManager = this.getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();

        CalcFragment fragment = new CalcFragment();
        fragmentTransaction.add(R.id.flFragmentContainer, fragment);
        fragmentTransaction.commit();// подтверждаем транзакцию
    }
}
