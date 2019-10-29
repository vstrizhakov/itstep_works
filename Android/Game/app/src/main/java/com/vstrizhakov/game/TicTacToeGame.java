package com.vstrizhakov.game;

import android.accessibilityservice.AccessibilityService;
import android.content.Context;
import android.os.Bundle;
import android.text.Layout;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.GridLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Random;

public class TicTacToeGame implements BaseGame, View.OnClickListener
{
	private GridLayout _gridLayout;
	private ArrayList<TicTacToeButton> _area;
	private Context _context;
	private Button _resetButton;
	private boolean _isRunning = true;
	
	private final static int SIZE = 3;
	
	public TicTacToeGame(Context context)
	{
		_context = context;
		_gridLayout = new GridLayout(context);
		_area = new ArrayList<>();
		
		_resetButton = new Button(context);
		_resetButton.setText("Начать заново");
		_resetButton.setOnClickListener(new View.OnClickListener()
		{
			@Override
			public void onClick(View v)
			{
				TicTacToeGame.this.resetArea();
			}
		});
		GridLayout.LayoutParams lp = new GridLayout.LayoutParams();
		lp.rowSpec = GridLayout.spec(0);
		lp.columnSpec = GridLayout.spec(0, 3);
		lp.setGravity(Gravity.FILL);
		_resetButton.setLayoutParams(lp);
		_gridLayout.addView(_resetButton);
		
		_gridLayout.setColumnCount(SIZE);
		_gridLayout.setRowCount(SIZE + 2);
		for (int i = 0; i < SIZE; i++)
		{
			for (int j = 0; j < SIZE; j++)
			{
				TicTacToeButton btn = new TicTacToeButton(context, new Point(j, i), 1);
				btn.setOnClickListener(this);
				_gridLayout.addView(btn);
				_area.add(btn);
			}
		}
	}
	
	public GridLayout getGridLayout()
	{
		return _gridLayout;
	}
	
	private String getPlayerString(int player)
	{
		if (player != TicTacToeButton.STATE_COMPUTER
			&& player != TicTacToeButton.STATE_PLAYER)
		{
			return "Unknown";
		}
		String str = "";
		switch (player)
		{
			case TicTacToeButton.STATE_PLAYER:
				str = "Игрок";
				break;
			case TicTacToeButton.STATE_COMPUTER:
				str = "Компьютер";
				break;
		}
		return str;
	}
	
	@Override
	public void onClick(View view)
	{
		if (!_isRunning) return;
		TicTacToeButton clickedButton = (TicTacToeButton)view;
		if (clickedButton.getState() == TicTacToeButton.STATE_NONE)
		{
			clickedButton.setState(TicTacToeButton.STATE_PLAYER);
			boolean result = checkWinner();
			boolean isAreaFilled = checkIsAreaFilled();
			String player = getPlayerString(TicTacToeButton.STATE_PLAYER);
			if (!result && !isAreaFilled)
			{
				placeByComputer();
				result = checkWinner();
				isAreaFilled = checkIsAreaFilled();
				player = getPlayerString(TicTacToeButton.STATE_COMPUTER);
			}
			if (result || isAreaFilled)
			{
				_isRunning = false;
				String message = (result) ? "Победил " + player : "Ничья";
				Toast.makeText(_context, message, Toast.LENGTH_LONG).show();
			}
		}
	}
	
	private void placeByComputer()
	{
		int count = 0;
		int empty = -1;
		int emptyY = -1;
		for (int counter = 0; counter < 2; counter++)
		{
			int state = (counter == 0) ? TicTacToeButton.STATE_COMPUTER : TicTacToeButton.STATE_PLAYER;
			for (int i = 0; i < SIZE; i++)
			{
				count = 0;
				empty = -1;
				for (int j = 0; j < SIZE; j++)
				{
					TicTacToeButton btn = getButtonByPoint(new Point(j, i));
					int currentState = btn.getState();
					if (currentState == TicTacToeButton.STATE_NONE)
					{
						empty = j;
					}
					else if (currentState == state)
					{
						count++;
					}
				}
				if (empty != -1 && count == 2)
				{
					TicTacToeButton btn = getButtonByPoint(new Point(empty, i));
					btn.setState(TicTacToeButton.STATE_COMPUTER);
					return;
				}
				
				count = 0;
				empty = -1;
				for (int j = 0; j < SIZE; j++)
				{
					TicTacToeButton btn = getButtonByPoint(new Point(i, j));
					int currentState = btn.getState();
					if (currentState == TicTacToeButton.STATE_NONE)
					{
						empty = j;
					}
					else if (currentState == state)
					{
						count++;
					}
				}
				if (empty != -1 && count == 2)
				{
					TicTacToeButton btn = getButtonByPoint(new Point(i, empty));
					btn.setState(TicTacToeButton.STATE_COMPUTER);
					return;
				}
			}
			
			count = 0;
			empty = -1;
			for (int j = 0; j < SIZE; j++)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(j, j));
				int currentState = btn.getState();
				if (currentState == TicTacToeButton.STATE_NONE)
				{
					empty = j;
				}
				else if (currentState == state)
				{
					count++;
				}
			}
			if (empty != -1 && count == 2)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(empty, empty));
				btn.setState(TicTacToeButton.STATE_COMPUTER);
				return;
			}
			
			count = 0;
			empty = -1;
			emptyY = -1;
			for (int j = 0, i = SIZE - 1; j < SIZE; j++, i--)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(j, i));
				int currentState = btn.getState();
				if (currentState == TicTacToeButton.STATE_NONE)
				{
					empty = i;
					emptyY = j;
				}
				else if (currentState == state)
				{
					count++;
				}
			}
			if (empty != -1 && emptyY != -1 && count == 2)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(emptyY, empty));
				btn.setState(TicTacToeButton.STATE_COMPUTER);
				return;
			}
		}
		
		Random rand = new Random();
		while (true)
		{
			empty = rand.nextInt(3);
			emptyY = rand.nextInt(3);
			TicTacToeButton btn = getButtonByPoint(new Point(emptyY, empty));
			if (btn.getState() == TicTacToeButton.STATE_NONE)
			{
				Log.d("LAG", empty + " = " + emptyY + ", state = " + btn.getState());
				btn.setState(TicTacToeButton.STATE_COMPUTER);
				return;
			}
		}
	}
	
	public boolean checkIsAreaFilled()
	{
		for (int i = 0; i < SIZE; i++)
		{
			for (int j = 0; j < SIZE; j++)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(j, i));
				if (btn.getState() == TicTacToeButton.STATE_NONE)
				{
					return false;
				}
			}
		}
		return true;
	}
	
	public boolean checkWinner()
	{
		int prevState = TicTacToeButton.STATE_NONE;
		for (int i = 0; i < SIZE; i++)
		{
			for (int j = 0; j < SIZE; j++)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(j, i));
				int currentState = btn.getState();
				if ((j != 0 && currentState != prevState)
					|| (j == 0 && currentState == TicTacToeButton.STATE_NONE))
				{
					break;
				}
				prevState = currentState;
				if (j == SIZE - 1)
				{
					return true;
				}
			}
			prevState = TicTacToeButton.STATE_NONE;
			for (int j = 0; j < SIZE; j++)
			{
				TicTacToeButton btn = getButtonByPoint(new Point(i, j));
				int currentState = btn.getState();
				if ((j != 0 && currentState != prevState)
						|| (j == 0 && currentState == TicTacToeButton.STATE_NONE))
				{
					break;
				}
				prevState = currentState;
				if (j == SIZE - 1)
				{
					return true;
				}
			}
		}
		prevState = TicTacToeButton.STATE_NONE;
		for (int j = 0; j < SIZE; j++)
		{
			TicTacToeButton btn = getButtonByPoint(new Point(j, j));
			int currentState = btn.getState();
			if ((j != 0 && currentState != prevState)
					|| (j == 0 && currentState == TicTacToeButton.STATE_NONE))
			{
				break;
			}
			prevState = currentState;
			if (j == SIZE - 1)
			{
				return true;
			}
		}
		prevState = TicTacToeButton.STATE_NONE;
		for (int j = 0, i = SIZE - 1; j < SIZE; j++, i--)
		{
			TicTacToeButton btn = getButtonByPoint(new Point(i, j));
			int currentState = btn.getState();
			if ((j != 0 && currentState != prevState)
					|| (j == 0 && currentState == TicTacToeButton.STATE_NONE))
			{
				break;
			}
			prevState = currentState;
			if (j == SIZE - 1)
			{
				return true;
			}
		}
		return false;
	}
	
	private TicTacToeButton getButtonByPoint(Point point)
	{
		for (TicTacToeButton btn : _area)
		{
			if (btn.getPoint().equals(point))
			{
				return btn;
			}
		}
		return null;
	}
	
	private void resetArea()
	{
		_isRunning = true;
		for (TicTacToeButton btn : _area)
		{
			btn.setState(TicTacToeButton.STATE_NONE);
		}
	}
	
	@Override
	public void save(Bundle state)
	{
		String buttons = "";
		for (TicTacToeButton btn : _area)
		{
			String btnStr = btn.getPoint().serialize() + "-" + btn.getState();
			buttons += "&" + btnStr;
		}
		state.putString("ticTacToeArea", buttons);
	}
	
	@Override
	public void restore(Bundle state)
	{
		String[] buttons = state.getString("ticTacToeArea", "").split("&");
		for (String btnStr : buttons)
		{
			if (btnStr.isEmpty()) continue;
			String[] parts = btnStr.split("-");
			Point point = Point.deserialize(parts[0]);
			int gameState = Integer.valueOf(parts[1]);
			TicTacToeButton btn = getButtonByPoint(point);
			btn.setState(gameState);
		}
	}
}

class TicTacToeButton extends BarleyBreakButton
{
	public final static int STATE_NONE = 0;
	public final static int STATE_PLAYER = 1;
	public final static int STATE_COMPUTER = 2;
	
	private int _state;
	
	public TicTacToeButton(Context context, Point point, int verticalOffset)
	{
		super(context, point, verticalOffset);
		_state = STATE_NONE;
	}
	
	public int getState()
	{
		return _state;
	}
	
	public void setState(int state)
	{
		if (state < 0 || state > 2) return;
		switch (state)
		{
			case STATE_PLAYER:
			{
				setText("X");
				break;
			}
			case STATE_COMPUTER:
			{
				setText("O");
				break;
			}
			case STATE_NONE:
			{
				setText(" ");
				break;
			}
		}
		_state = state;
	}
}