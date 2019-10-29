/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_13_1_joptionpane;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

/**
 *
 * @author 09220
 */
public class MyFrame extends JFrame
{
    private JPanel mainPanel;
    
    public MyFrame ()
    {
        this.addWindowListener(new WindowAdapter() 
        {
            @Override
            public void windowClosing(WindowEvent we)
            {
                System.exit(0);
            }
        });
        this.setTitle("JOption Pane");
        this.setSize(500, 300);
        this.setLayout(new BorderLayout());
        
        this.mainPanel = new JPanel(new FlowLayout(FlowLayout.LEADING, 3, 3));
        this.setContentPane(this.mainPanel);
        //--
        JButton B = new JButton("Click");
        this.mainPanel.add(B);
        
        B.addActionListener(new ActionListener()
        {

            @Override
            public void actionPerformed(ActionEvent e)
            {
                MyFrame.this.testMethod();
            }
        });
    }
    private void testMethod()
    {
        JPanel P = new JPanel(new FlowLayout(FlowLayout.LEFT, 3, 3));
        JLabel L = new JLabel("Фамилия");
        P.add(L);
        
        JTextField T = new JTextField();
        T.setPreferredSize(new Dimension(120, 26));
        P.add(T);
        
        int result = JOptionPane.showConfirmDialog(this, P, "Введите данные", JOptionPane.OK_CANCEL_OPTION);
        System.out.println("Нажата кнопка : "+result);
        if(result==JOptionPane.OK_OPTION)
            System.out.println("OK : "+T.getText());
        else
            if(result == JOptionPane.CANCEL_OPTION)
                System.out.println("CANSEL");
    }
}
