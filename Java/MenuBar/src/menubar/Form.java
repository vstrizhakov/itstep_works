/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package menubar;

import java.awt.Dimension;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.*;

/**
 *
 * @author PC
 */
public class Form extends JFrame {
    private JMenuBar menuBar;
    
    public Form()
    {
        this.setSize(new Dimension(600, 1200));
        
        this.menuBar = new JMenuBar();
        JMenu menuFile = new JMenu("File");
        menuFile.setMnemonic(KeyEvent.VK_F);
        menuBar.add(menuFile);
        
        JMenuItem menuItemOpen = new JMenuItem("Open");
        menuFile.add(menuItemOpen);
        
        JMenuItem menuItemSave = new JMenuItem("Save");
        menuFile.add(menuItemSave);
        
        JMenu menuEdit = new JMenu("Edit");
        menuEdit.setMnemonic(KeyEvent.VK_E);
        menuBar.add(menuEdit);
        this.setJMenuBar(this.menuBar);
        
        ActionListener AL = new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent ae)
            {
                if (ae.getSource() == menuItemOpen)
                {
                    System.out.println("Выбран пункт меню Save");
                }
                else if (ae.getSource() == menuItemSave)
                {
                    System.out.println("Выбран пункт меню Open");
                }
            }
        };
        
        menuItemOpen.addActionListener(AL);
        menuItemSave.addActionListener(AL);
        
        this.addWindowListener(new WindowAdapter()
        {
           @Override
           public void windowClosing(WindowEvent we)
           {
               System.exit(0);
           }
        });
    }
}
