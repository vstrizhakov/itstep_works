package com.vstrizhakov.game;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

public class MainActivity extends AppCompatActivity
{
    private BarleyBreakGame barleyBreakGame;
    private TicTacToeGame ticTacToeGame;
    private int _current = -1;
    
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        barleyBreakGame = new BarleyBreakGame(this);
        ticTacToeGame = new TicTacToeGame(this);
    }
    
    @Override
    public void onSaveInstanceState(Bundle outState)
    {
        super.onSaveInstanceState(outState);
        ticTacToeGame.save(outState);
        barleyBreakGame.save(outState);
        outState.putInt("CurrentGame", _current);
    }
    
    @Override
    public void onRestoreInstanceState(Bundle savedInstanceState)
    {
        super.onRestoreInstanceState(savedInstanceState);
        ticTacToeGame.restore(savedInstanceState);
        barleyBreakGame.restore(savedInstanceState);
        int current = savedInstanceState.getInt("CurrentGame", -1);
        switchToGame(current);
    }
    
    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.games_menu, menu);
        return true;
    }
    
    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        switchToGame(item.getItemId());
        return true;
    }
    
    private void switchToGame(int id)
    {
        switch (id)
        {
            case R.id.barleybreak:
            {
                if (_current != R.id.barleybreak)
                {
                    setContentView(barleyBreakGame.getGridLayout());
                    _current = R.id.barleybreak;
                }
                break;
            }
            case R.id.tictactoe:
            {
                if (_current != R.id.tictactoe)
                {
                    setContentView(ticTacToeGame.getGridLayout());
                    _current = R.id.tictactoe;
                }
                break;
            }
        }
    }
}
