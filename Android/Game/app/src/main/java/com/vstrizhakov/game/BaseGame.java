package com.vstrizhakov.game;

import android.os.Bundle;
import android.widget.GridLayout;

public interface BaseGame
{
	GridLayout getGridLayout();
	void save(Bundle state);
	void restore(Bundle state);
}
