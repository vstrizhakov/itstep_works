/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cwborderlayout;

import java.awt.BorderLayout;
import java.awt.Dimension;
import static java.awt.Event.LEFT;
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
 * @author Programmer
 */
public class MyFrame extends JFrame{
    // Панель которая будет назначена фрейму как главный контейнер
private JPanel mainPanel;
private JLabel L;
private JTextField T;
public MyFrame()
{
    // главная панель
    this.mainPanel = new JPanel();
    this.mainPanel.setLayout(new FlowLayout(LEFT,3,3));
    this.setLayout(new BorderLayout());
    this.setContentPane(this.mainPanel);
    
    // Общие настройки окна
    this.setTitle("First SWING Application");
    this.setSize(400,500);
    this.addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent we) {
                System.exit(0);
            }
        });
     L = new JLabel();
    L.setText("Фамилия");
    this.mainPanel.add(L);
    
     T  = new JTextField();
    T.setPreferredSize(new Dimension(120,30));
    this.mainPanel.add(T);
    
    JButton B = new JButton();
    B.setText("Click");
    this.mainPanel.add(B);
    
    B.addActionListener(
    new ActionListener() {
        @Override
        public void actionPerformed(ActionEvent e) {
            JOptionPane.showMessageDialog(MyFrame.this, "Введено : "+MyFrame.this.T.getText());
        }
    }
    );
}


}
