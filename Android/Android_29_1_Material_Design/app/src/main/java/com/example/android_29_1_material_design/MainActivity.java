package com.example.android_29_1_material_design;

import android.animation.AnimatorInflater;
import android.animation.ObjectAnimator;
import android.graphics.Color;
import android.support.annotation.NonNull;
import android.support.design.widget.NavigationView;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;


public class MainActivity extends AppCompatActivity
{
    private DrawerLayout drawerLayout;
    private NavigationView navigationView;
    /**
     * Текущий видимый контейнер
     */
    private View curView;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        drawerLayout = this.findViewById(R.id.drawerMain);
        navigationView = this.findViewById(R.id.naviView);
        curView = this.findViewById(R.id.llFitnes);

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
                int id = -1;
                String str = "Unknown";
                switch (menuItem.getItemId())
                {
                    case R.id.navigation_item_casino:
                        str = "casino";
                        id = R.id.llCasino;
                        break;
                    case R.id.navigation_item_fintess_center:
                        id = R.id.llFitnes;
                        str = "fintess center";
                        break;
                    case R.id.navigation_item_pool:
                        id = R.id.llPool;
                        str = "pool";
                        break;
                }
                if(id == -1)
                    return false;
                Toast.makeText(MainActivity.this, str, Toast.LENGTH_SHORT).show();
                //----Прячем DrawerLayout
                menuItem.setChecked(true);
                MainActivity.this.drawerLayout.closeDrawers();
                //------------
                //---Запуск анимации на исчезновение текущего видимого контейнера
                ObjectAnimator animator = (ObjectAnimator) AnimatorInflater.loadAnimator(MainActivity.this, R.animator.hide_animator);
                animator.setTarget(MainActivity.this.curView);
                animator.start();

                MainActivity.this.curView = MainActivity.this.findViewById(id);
                //-----Запуск аниммации на появление следующего контейнера
                ObjectAnimator animator1 = (ObjectAnimator)AnimatorInflater.loadAnimator(MainActivity.this, R.animator.show_animator);
                animator1.setTarget(MainActivity.this.curView);
                animator1.start();

                return true;
            }
        });

    }
//    @Override
//    public boolean onCreateOptionsMenu(Menu menu)
//    {
//        MenuInflater inflater = getMenuInflater(); // Предназначен для создания меню из xml файла
//        inflater.inflate(R.menu.drawer_menu, menu); // создаем меню из xml файла
//        return true;                               // Признак успешного создания
//    }
//    @Override
//    public  boolean onOptionsItemSelected(MenuItem item)
//    {
//        String str = "Unknown";
//        switch (item.getItemId())
//        {
//            case R.id.navigation_item_casino:
//                str = "casino";
//                break;
//            case R.id.navigation_item_fintess_center:
//                str = "fintess center";
//                break;
//            case R.id.navigation_item_pool:
//                str = "pool";
//                break;
//        }
//        Toast.makeText(this, str, Toast.LENGTH_SHORT).show();
//        return true;
//    }
}
