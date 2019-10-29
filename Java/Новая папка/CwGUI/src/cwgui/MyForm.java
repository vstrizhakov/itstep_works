/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package cwgui;

import java.awt.Button;
import java.awt.Frame;
import java.awt.Label;
import java.awt.TextField;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.JButton;

/**
 *
 * @author Programmer
 */
public class MyForm extends Frame {

    public MyForm() {
        this.setTitle("Первое GUI приложение");
        this.setSize(500, 300);
        this.setLayout(null);

        this.addWindowListener(
                new WindowAdapter() {
            @Override
            public void windiwClosing(WindowEvent we) {
                System.exit(0);
            }
        });
        JButton B = new JButton();
        B.setLabel("Click me");
        B.setLocation(50, 40);
        B.setSize(120, 30);
        this.add(B);

        B.addActionListener(
                new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent ae) {
                System.out.println("Click");
            }
        });
        Label L = new Label();
        L.setText("Фамилия");
        L.setLocation(20, 80);
        L.setSize(60, 30);
        this.add(L);

        TextField T = new TextField();
        T.setLocation(100, 80);
        T.setSize(120, 30);
        T.setText("Gates");
        this.add(T);
    }
}
