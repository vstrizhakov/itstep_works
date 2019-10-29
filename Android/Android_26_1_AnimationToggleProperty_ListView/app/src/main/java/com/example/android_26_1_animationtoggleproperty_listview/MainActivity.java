package com.example.android_26_1_animationtoggleproperty_listview;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.animation.AnimatorSet;
import android.animation.ObjectAnimator;
import android.animation.ValueAnimator;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
    private ListView lvMovies;
    private FrameLayout frame_visibility;
    private FrameLayout flAddPanel;
    private ArrayAdapter<MyMovie> myMovieArrayAdapter;
    private int selectMyMovie;
//    private MyMovie selectMovie;
    private boolean editClick = false;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        this.flAddPanel = this.findViewById(R.id.flAddPanel);
        this.frame_visibility = this.findViewById(R.id.frame_visibility);
        Toolbar toolbar = this.findViewById(R.id.toolbar);
        this.setSupportActionBar(toolbar);
        toolbar.setSubtitle("ListView Tpggle property Animation");
        toolbar.setNavigationIcon(R.drawable.ic_reorder_black_24dp);
        toolbar.setNavigationOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                MainActivity.this.toggleValueAnimation_addPanel();
            }
        });

        this.lvMovies = this.findViewById(R.id.lvMovies);

        String[] genres = {"Action", "Fantastic", "Drama", "Melodrama", "Comedy", "Adventure", "Cartoon", "Thriller", "LoveStory"};

        ArrayList<MyMovie> movies = new ArrayList<>();
        for(int i=0; i<50; i++)
        {
            movies.add(new MyMovie(this.makeMovieTitle(), genres[(int)(Math.random()*genres.length)], 2000+(int)(Math.random()*19)));
        }
        myMovieArrayAdapter = new ArrayAdapter<MyMovie>(this, R.layout.list_item_value_animation, R.id.tvTitle, movies)
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
                MainActivity.this.togglePropertyAnimation(view);
                selectMyMovie = i;
            }
        });
    }
    private void togglePropertyAnimation(View view)
    {
        //---Анимация сдвига панели элементов
        final LinearLayout llItemHolder = view.findViewById(R.id.llItemHolder);
        ObjectAnimator objectAnimator = (ObjectAnimator) AnimatorInflater.loadAnimator(
                this, (llItemHolder.getX() == 0)?R.animator.property_animation_list_item_rise:R.animator.property_animation_list_item_fall);
        objectAnimator.setTarget(llItemHolder);

        //---Анимация изменения размера шрифта для виджета R.id.tvDelete / R.id.tvEdit
        final TextView tvDelete = view.findViewById(R.id.tvDelete);
        final TextView tvEdit = view.findViewById(R.id.tvEdit);

        ObjectAnimator objectAnimator1 = (ObjectAnimator) AnimatorInflater.loadAnimator(this,
                (llItemHolder.getX()==0)? R.animator.property_animation_text_size_rise:R.animator.property_animation_text_size_fall);
        objectAnimator1.setTarget(tvDelete);

        ObjectAnimator objectAnimator2 = (ObjectAnimator) AnimatorInflater.loadAnimator(this,
                (llItemHolder.getX()==0)? R.animator.property_animation_text_size_rise:R.animator.property_animation_text_size_fall);
        objectAnimator2.setTarget(tvEdit);

        //---Запуск анимации изменения ширины панели операций
        final LinearLayout llButtonHolder = view.findViewById(R.id.llButtonHolder);
        if(llItemHolder.getX() == 0)
            ObjectAnimator.ofFloat(new WidthEvaluator(llButtonHolder), "Width", 0f,300f).start();
        else
            ObjectAnimator.ofFloat(new WidthEvaluator(llButtonHolder), "Width", 300f,0f).start();

        objectAnimator.start();
        objectAnimator1.start();
        objectAnimator2.start();
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
        this.togglePropertyAnimation(v);
        editClick = false;
        switch (view.getId())
        {
            case R.id.tvDelete:
                this.myMovieArrayAdapter.remove(this.myMovieArrayAdapter.getItem(selectMyMovie));
                Toast.makeText(this, "Фильм удален", Toast.LENGTH_LONG).show();
                break;
            case R.id.tvEdit:
                editClick = true;
                EditText textName = ((EditText)this.findViewById(R.id.edName));
                EditText textGenre = ((EditText)this.findViewById(R.id.edGenre));
                EditText textYear = ((EditText)this.findViewById(R.id.edYear));

                MyMovie myMovie = this.myMovieArrayAdapter.getItem(selectMyMovie);
                textName.setText(myMovie.title);
                textGenre.setText(myMovie.genre);
                textYear.setText(String.valueOf(myMovie.year));
                toggleValueAnimation_addPanel();
                break;
        }
    }
    private void toggleValueAnimation_addPanel()
    {
        AnimatorSet animatorSet;

        if(flAddPanel.getHeight() == 0)
            animatorSet =(AnimatorSet) AnimatorInflater.loadAnimator(MainActivity.this, R.animator.value_anmation_addpanel_rise);
        else
            animatorSet =(AnimatorSet) AnimatorInflater.loadAnimator(MainActivity.this, R.animator.value_anmation_addpanel_fall);

        ArrayList<Animator> animators = animatorSet.getChildAnimations();

        ValueAnimator animatorHeight =(ValueAnimator) animators.get(0);
        animatorHeight.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
        {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator)
            {
                int height = (int)valueAnimator.getAnimatedValue();
                LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(FrameLayout.LayoutParams.MATCH_PARENT, height);
                params.gravity = Gravity.TOP;
                flAddPanel.setLayoutParams(params);
            }
        });

        ValueAnimator animatorVisibility = (ValueAnimator) animators.get(1);
        animatorVisibility.addUpdateListener(new ValueAnimator.AnimatorUpdateListener()
        {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator)
            {
                float value =(float) valueAnimator.getAnimatedValue();
                frame_visibility.setAlpha(value);
            }
        });


        animatorHeight.start();

        animatorVisibility.start();
    }
    public void onClick(View view)
    {

        EditText textName = ((EditText)this.findViewById(R.id.edName));
        EditText textGenre = ((EditText)this.findViewById(R.id.edGenre));
        EditText textYear = ((EditText)this.findViewById(R.id.edYear));
        switch (view.getId())
        {
            case R.id.dtn_cancel:
                toggleValueAnimation_addPanel();
                break;
            case R.id.dtn_add:


                String name = textName.getText().toString().trim();
                String genre = textGenre.getText().toString().trim();
                textName.setText(name);
                textGenre.setText(genre);
                int year = -1;
                if(!textYear.getText().toString().isEmpty())
                    year =  Integer.parseInt(textYear.getText().toString());

                MyMovie myMovie = new MyMovie(name,genre,year);

                if(myMovie.genre.isEmpty() || myMovie.title.isEmpty() || year == -1)
                    Toast.makeText(this, "Не все поля заполнены",Toast.LENGTH_LONG).show();

                else if(!this.editClick)
                {
                    toggleValueAnimation_addPanel();
                    myMovieArrayAdapter.add(myMovie);
                    Toast.makeText(this, "Добавлен новый вильм: "+myMovie.title, Toast.LENGTH_LONG).show();
                }
                else
                {
                    MyMovie edit_movie = this.myMovieArrayAdapter.getItem(this.selectMyMovie);
                    edit_movie.year = myMovie.year;
                    edit_movie.title = myMovie.title;
                    edit_movie.genre = myMovie.genre;
                    toggleValueAnimation_addPanel();
                    Toast.makeText(this, "Фильм отредактирован", Toast.LENGTH_LONG).show();
                }
                break;
        }
        textName.setText("");
        textGenre.setText("");
        textYear.setText("");
        editClick = false;
    }
}
