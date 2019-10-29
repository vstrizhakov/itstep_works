package com.example.android_31_4_md;

import android.animation.AnimatorInflater;
import android.animation.ObjectAnimator;
import android.graphics.Color;
import android.support.annotation.NonNull;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity
{
    private NavigationView navigationView;
    private DrawerLayout drawerLayout;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        navigationView = this.findViewById(R.id.naviView);
        drawerLayout = this.findViewById(R.id.draver_layout);

        CollapsingToolbarLayout toolbarLayout = this.findViewById(R.id.collapsingToolbar);
        toolbarLayout.setExpandedTitleColor(Color.WHITE);
        toolbarLayout.setCollapsedTitleTextColor(Color.WHITE);

        TextView tvOne =(TextView)this.findViewById(R.id.tvOne);
        String[] arr = {"Lemon", "Orenge", "Peach", "Banana", "Winter", "Summer", "Spring", "Autum",
                "Mondey", "Tuesday", "Wednesday", "Thursday", "Firday", "Saturday", "Sunday"};

        String content = "";
        for(int i=0; i<1000; i++)
            content += arr[(int)(Math.random()*arr.length)]+(i+1)+" ";
        tvOne.setText(content);

        Toolbar toolbar = this.findViewById(R.id.toolbar);
        this.setSupportActionBar(toolbar);
        toolbar.setSubtitle("Navigation menu");

        toolbar.setSubtitleTextColor(Color.WHITE);
        toolbar.setTitleTextColor(Color.WHITE);

        toolbar.setNavigationIcon(R.drawable.ic_menu_white_24dp);
        toolbar.setNavigationOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                //--открытие бокового меню по нажатию на кнопку на tool bar
                MainActivity.this.drawerLayout.openDrawer(MainActivity.this.navigationView);
            }
        });
        navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener()
        {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem menuItem)
            {
                String str = "Unknown";
                switch (menuItem.getItemId())
                {
                    case R.id.navigation_item_casino:
                        str = "casino";
                        break;
                    case R.id.navigation_item_fintess_center:
                        str = "fitness";
                        break;
                    case R.id.navigation_item_pool:
                        str = "pool";
                        break;
                }
                Toast.makeText(MainActivity.this, str, Toast.LENGTH_SHORT).show();
                //----Прячем DrawerLayout
                menuItem.setChecked(true);
                MainActivity.this.drawerLayout.closeDrawers();
                //------------

                return true;
            }
        });
    }
}
