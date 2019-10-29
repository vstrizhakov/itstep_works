/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package colorfullbackground;

/**
 *
 * @author PC
 */
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Form extends Frame
{
	public Form()
	{
            setLayout(new FlowLayout());
            setSize(1200, 600);
            setBackground(Color.black);
            setForeground(Color.white);
            
		Checkbox red = new Checkbox();
		Checkbox green = new Checkbox();
		Checkbox blue = new Checkbox();

		red.setLabel("Red");
		green.setLabel("Green");
		blue.setLabel("Blue");
                
                add(red);
                add(green);
                add(blue);

		ItemListener checkboxListener = new ItemListener()
		{
			@Override
			public void itemStateChanged(ItemEvent e)
			{
				int r = red.getState() ? 255 : 0;
				int g = green.getState() ? 255 : 0;
				int b = blue.getState() ? 255 : 0;
				Color backgroundColor = new Color(r, g, b);
				Color foregroundColor = new Color(255 - r, 255 - g, 255 - b);
				Form.this.setBackground(backgroundColor);
				red.setForeground(foregroundColor);
				green.setForeground(foregroundColor);
				blue.setForeground(foregroundColor);
			}
		};
                
                red.addItemListener(checkboxListener);
                green.addItemListener(checkboxListener);
                blue.addItemListener(checkboxListener);
;
		
		this.addWindowListener(new WindowAdapter()
		{
			@Override
			public void windowClosing(WindowEvent we)
			{
				System.exit(0);
			}
		});

		this.addMouseMotionListener(new MouseMotionListener()
		{
			@Override
			public void mouseMoved(MouseEvent me)
			{
				Form.this.setTitle("X: " + me.getX() + ", Y: " + me.getY());
			}
                        
                        @Override
                        public void mouseDragged(MouseEvent me)
                        {
                            
                        }
		});
	}
}
