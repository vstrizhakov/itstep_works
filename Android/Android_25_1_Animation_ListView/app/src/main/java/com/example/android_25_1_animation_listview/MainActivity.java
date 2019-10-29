package com.example.android_25_1_animation_listview;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.animation.AnimatorSet;
import android.animation.ValueAnimator;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.AccelerateDecelerateInterpolator;
import android.view.animation.Animation;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import java.lang.reflect.TypeVariable;
import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
    private ListView lvMovies;
    private View viewClick;
    private int pos;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Toolbar toolbar = this.findViewById(R.id.toolbar);
        this.setSupportActionBar(toolbar);
        toolbar.setSubtitle("ListView Animation");

        this.lvMovies = this.findViewById(R.id.lvMovies);

        String[] genres = {"Action", "Fantastic", "Drama", "Melodrama", "Comedy", "Adventure", "Cartoon", "Thriller", "LoveStory"};

        ArrayList<MyMovie> movies = new ArrayList<>();
        for(int i=0; i<50; i++)
        {
            movies.add(new MyMovie(this.makeMovieTitle(), genres[(int)(Math.random()*genres.length)], 2000+(int)(Math.random()*19)));
        }
        ArrayAdapter<MyMovie> myMovieArrayAdapter = new ArrayAdapter<MyMovie>(this, R.layout.list_item_value_animation, R.id.tvTitle, movies)
        {
          @Override
          public View getView(int position, View convertView, ViewGroup parrent)
          {
              View view = super.getView(position, convertView, parrent);
              MyMovie F = this.getItem(position);

              TextView tvTitle = view.findViewById(R.id.tvTitle);
              TextView tvGenre = view.findViewById(R.id.tvGenre);
              TextView tvYear = view.findViewById(R.id.tvYear);

              tvTitle.setText(F.title);
              tvGenre.setText(F.genre);
              tvYear.setText(String.valueOf(F.year));

              //---Спрятать панель операций если нужно
              final LinearLayout llButtonHolder = view.findViewById(R.id.llButtonHolder);
              final LinearLayout llItemHolder = view.findViewById(R.id.llItemHolder);
              final TextView tvDelete = view.findViewById(R.id.tvDelete);
              final TextView tvEdit = view.findViewById(R.id.tvEdit);

              if(llButtonHolder.getWidth() != 0)
              {
                  //----Ширина панели операций становится = 0
                  FrameLayout.LayoutParams LP = new FrameLayout.LayoutParams(0, FrameLayout.LayoutParams.MATCH_PARENT);
                  LP.gravity = Gravity.RIGHT;
                  llButtonHolder.setLayoutParams(LP);

                  //--Размер шрифта = 0 для виджетов ivDelete tvEdit
                  tvDelete.setTextSize(TypedValue.COMPLEX_UNIT_SP, 0);
                  tvEdit.setTextSize(TypedValue.COMPLEX_UNIT_SP, 0);

                  //--Позиция по горизонтали для панели элемента = 0
                  llItemHolder.setX(0);
              }

              return view;
          }
        };
         this.lvMovies.setAdapter(myMovieArrayAdapter);
         this.lvMovies.setOnItemClickListener(new AdapterView.OnItemClickListener()
         {
             @Override
             public void onItemClick(AdapterView<?> adapterView, View view, int i, long l)
             {
                 MainActivity.this.toggleValueAnimation(view);
             }
         });
    }

    private void toggleValueAnimation(View view)
    {
        final LinearLayout llButtonHolder = view.findViewById(R.id.llButtonHolder);
        final LinearLayout llItemHolder = view.findViewById(R.id.llItemHolder);
        final TextView tvDelete = view.findViewById(R.id.tvDelete);
        final TextView tvEdit = view.findViewById(R.id.tvEdit);

        AnimatorSet asRise;
        if(llButtonHolder.getWidth() == 0)
            //Панель операций необходимо показать
            asRise = (AnimatorSet) AnimatorInflater.loadAnimator(this, R.animator.value_animation_item_rise);
        else
            //Панель операций необходимо спрятать
            asRise = (AnimatorSet) AnimatorInflater.loadAnimator(this, R.animator.value_animation_item_fall);
        asRise.setInterpolator(new AccelerateDecelerateInterpolator()); // Интерполятор
       //Получение списка анимаций
        ArrayList<Animator> arrL = asRise.getChildAnimations();

        //--Ширина панели
        ValueAnimator vaRise = (ValueAnimator) arrL.get(0);
        vaRise.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
        {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator)
            {
                int curWidth = (int)valueAnimator.getAnimatedValue();
                FrameLayout.LayoutParams LP = new FrameLayout.LayoutParams(curWidth, FrameLayout.LayoutParams.MATCH_PARENT);
                LP.gravity = Gravity.RIGHT;
                llButtonHolder.setLayoutParams(LP);
            }
        });
        //--Обработка событий изменения размеров шрифта кнопок "Delete" "Edit"
        ValueAnimator vaRiseTextSize = (ValueAnimator)arrL.get(1);
        vaRiseTextSize.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
        {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator)
            {
                float curTextSize = (float) valueAnimator.getAnimatedValue();
                tvDelete.setTextSize(TypedValue.COMPLEX_UNIT_SP, curTextSize);
                tvEdit.setTextSize(TypedValue.COMPLEX_UNIT_SP, curTextSize);
            }
        });
        ValueAnimator vaRiseShift =(ValueAnimator) arrL.get(2);
        vaRiseShift.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
        {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator)
            {
                int curX = (int) valueAnimator.getAnimatedValue();
                llItemHolder.setX(curX);
            }
        });
        vaRise.start();
        vaRiseShift.start();
        vaRiseTextSize.start();
    }

    private String makeMovieTitle()
    {
        String[] first = {"Winter", "House", "Summer", "Road", "Human", "Wind", "Solider"};
        String[] second = {"Blues", "Alarm", "Song", "Sea", "River", "Boat", "Desert"};
        String[] third = {"Three", "Cloud", "Sun", "Day", "Year", "Story", "Love"};
        String[] z = {" and ", " or ", " at ", " under ", " before ", " after "};

        String str = first[(int)(Math.random()*first.length)]+" "+second[(int)(Math.random()*second.length)]+z[(int)(Math.random()*z.length)]+
                third[(int)(Math.random()*third.length)];
        return str;
    }
    public void txtClick(View view)
    {
        View v = (View) view.getParent().getParent(); // переходим в родительский контейнер
        this.toggleValueAnimation(v);
    }
}
