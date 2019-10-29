/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_13_2_listmodel;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.util.ArrayList;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;

/**
 *
 * @author 09220
 */
public class MyFrame extends JFrame
{

    private JPanel mainPanel;
    private MyListModel model;
    private JList list;
    private JButton btnAdd, btnEdit, btnDel;

    public MyFrame()
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

        this.mainPanel = new JPanel(new BorderLayout());
        this.setContentPane(this.mainPanel);
        //--

        ArrayList<MyPoint> listP = new ArrayList<>();

        for (int i = 0; i < 50; i++)
        {
            MyPoint P = new MyPoint(i, i);
            listP.add(P);
        }
        this.model = new MyListModel(listP);
        this.list = new JList();
       
        this.list.setModel(this.model);

        JScrollPane scrollPane = new JScrollPane(this.list);
        this.mainPanel.add(scrollPane, BorderLayout.CENTER);

        JPanel southPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 3, 3));
        this.mainPanel.add(southPanel, BorderLayout.SOUTH);

        this.btnAdd = new JButton("Add");
        southPanel.add(this.btnAdd);

        this.btnEdit = new JButton("Edit");
        southPanel.add(this.btnEdit);

        this.btnDel = new JButton("Del");
        southPanel.add(this.btnDel);

        //обработчик для кнопок
        ActionListener actionL = new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                if (e.getSource() == MyFrame.this.btnAdd)
                {
                    MyPoint P = new MyPoint((int) (Math.random() * 100), (int) (Math.random() * 100));
                    MyFrame.this.model.add(P);
                } 
                else if (e.getSource() == MyFrame.this.btnEdit)
                {
                   int index = MyFrame.this.list.getSelectedIndex();
                    if (index != -1)
                    {
                        MyPoint P = MyFrame.this.model.getElementAt(index);
                        P.setX(P.getX()+(int) (Math.random() * 100));
                        P.setY(P.getY()+(int) (Math.random() * 100));
                        MyFrame.this.model.set(P, index); // перезаписываем данные
                    }
                    else
                        JOptionPane.showMessageDialog(MyFrame.this, "Не выбран элемент списка", "Ошибка",JOptionPane.ERROR_MESSAGE);
                } 
                else if (e.getSource() == MyFrame.this.btnDel)
                {
                    int index = MyFrame.this.list.getSelectedIndex();
                    if (index != -1)
                        MyFrame.this.model.removeAt(index);
                    else
                        JOptionPane.showMessageDialog(MyFrame.this, "Не выбран элемент списка", "Ошибка",JOptionPane.ERROR_MESSAGE);
                }
            }
        };

        this.btnAdd.addActionListener(actionL);
        this.btnDel.addActionListener(actionL);
        this.btnEdit.addActionListener(actionL);
    }
}
