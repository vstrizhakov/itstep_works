package com.example.android_8_4_castomwidgettolistview;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity
{
    private ListView lvFilms;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        this.lvFilms = this.findViewById(R.id.lvFilms);

        ArrayList<Film> films = new ArrayList<>();
        for (int i = 0; i < 50; i++)
        {
            films.add(new Film("Фильм " + (i + 1), "Жанр " + (i + 1), 2000 + i % 15));
        }

        ArrayAdapter<Film> adapter = new ArrayAdapter<Film>(this, R.layout.film_item, R.id.tvTitle, films)
        {
            @Override
            public View getView(int position, View convertView, ViewGroup parent)
            {
                View view = super.getView(position, convertView, parent);
                Film F = this.getItem(position);

                TextView tvTitle = view.findViewById(R.id.tvTitle);
                TextView tvGanre = view.findViewById(R.id.tvGenre);
                TextView tvYear = view.findViewById(R.id.tvYear);

                tvTitle.setText(F.title);
                tvGanre.setText(F.genre);
                tvYear.setText(String.valueOf(F.year));

                return view;
            }
        };

        this.lvFilms.setAdapter(adapter);

    }

    }
