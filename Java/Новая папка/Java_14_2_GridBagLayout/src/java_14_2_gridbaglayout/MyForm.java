/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_14_2_gridbaglayout;

import java.awt.BorderLayout;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 *
 * @author 09220
 */
public class MyForm extends JFrame
{
    private JPanel mainPanel = new JPanel();
    public MyForm()
    {
        this.setTitle("Заголовок");
        this.setSize(500, 300);
        this.addWindowListener(new WindowAdapter()
        {
            @Override
            public void windowClosing(WindowEvent we)
            {
                System.exit(0);
            }
        });
        this.mainPanel.setLayout(new GridBagLayout());
        this.setLayout(new BorderLayout());
        this.setContentPane(this.mainPanel);
        
        GridBagConstraints GBC = new GridBagConstraints();
        GBC.weighty = 1;
        GBC.weightx = 1;
        GBC.fill = GridBagConstraints.BOTH; //растягиваем по всей ячейке
        //== 1 строка
        GBC.gridy=0;
        //--1 строка, 1 ячейка
        GBC.gridx = 0;
        JButton B11 = new JButton("11");
        this.mainPanel.add(B11,GBC);
        //--1 строка, 2 ячейка
        GBC.gridx = 1;
        JButton B12 = new JButton("12");
        this.mainPanel.add(B12,GBC);
        //--1 строка, 3 ячейка
        GBC.gridx = 2;
        JButton B13 = new JButton("13");
        this.mainPanel.add(B13,GBC);
        
        //== 2 строка
        GBC.gridy=1;
        //--2 строка, 1 ячейка
        GBC.gridx = 0;
        JButton B21 = new JButton("21");
        this.mainPanel.add(B21,GBC);
        //--2 строка, 2 ячейка
        GBC.gridx = 1;
        JButton B22 = new JButton("22");
        this.mainPanel.add(B22,GBC);
        //--2 строка, 3 ячейка
        GBC.gridx = 2;
        JButton B23 = new JButton("23");
        this.mainPanel.add(B23,GBC);
        
        //== 3 строка
        GBC.gridy=2;
        //--3 строка, 1 ячейка
        GBC.gridx = 0;
        JButton B31 = new JButton("31");
        this.mainPanel.add(B31,GBC);
        //--3 строка, 2 ячейка
        GBC.gridx = 1;
        GBC.gridwidth = 2; // шириной в 2 ячейки
     //   GBC.fill = GridBagConstraints.HORIZONTAL; // растягиваем по горизогтали
        JButton B32 = new JButton("32");
        this.mainPanel.add(B32,GBC);
            //возвращаем в первоначальное состояние
            GBC.gridwidth = 1;
           // GBC.fill = GridBagConstraints.NONE; 
            //
        
        //== 4 строка
        GBC.gridy=3;
        //--4 строка, 1 ячейка
        GBC.gridx = 0;
        JButton B41 = new JButton("41");
        this.mainPanel.add(B41,GBC);
        //--4 строка, 2 ячейка
        GBC.gridx = 1;
        JButton B42 = new JButton("42");
        GBC.gridheight = 2; //высотой в 2 ячейки
       // GBC.fill = GridBagConstraints.VERTICAL; // растягиваем
        this.mainPanel.add(B42,GBC);
        GBC.gridheight = 1;
       // GBC.fill = GridBagConstraints.NONE;
        //--4 строка, 3 ячейка
        GBC.gridx = 2;
        JButton B43 = new JButton("43");
        this.mainPanel.add(B43,GBC);
        
        //== 5 строка
        GBC.gridy=4;
        //--5 строка, 1 ячейка
        GBC.gridx = 0;
        JButton B51 = new JButton("51");
        this.mainPanel.add(B51,GBC);
        //--5 строка, 3 ячейка
        GBC.gridx = 2;
        JButton B53 = new JButton("53");
        this.mainPanel.add(B53,GBC);

        
    }
}
