/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_12_1_jlist;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.BoxLayout;
import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.ListSelectionModel;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;

/**
 *
 * @author 09220
 */
public class MyFrame extends JFrame
{

    private JPanel mainPanel;
    private JButton btnAdd;
    private JButton btnEdt;
    private JButton btnDel;
    private DefaultListModel<MyPoint> model;
    private JList listPoints;

    public MyFrame()
    {
        //---общие настройки окна
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
        //--главная панель
        this.mainPanel = new JPanel();
        this.mainPanel.setLayout(new BoxLayout(this.mainPanel, BoxLayout.X_AXIS));
        this.setLayout(new BorderLayout());
        this.setContentPane(this.mainPanel);
        //----

        String[] data =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };
        JList<String> list = new JList<>(data);
        //SINGLE_INTERVAL_SELECTION - 1интервал подряд
        //SINGLE_SELECTION - только 1 эл.
        list.setSelectionMode(ListSelectionModel.SINGLE_INTERVAL_SELECTION);
        list.setLayoutOrientation(JList.VERTICAL_WRAP); // расположение эл.
        list.setVisibleRowCount(-1); // сколько строк должно быть видно в list (-1 - автоматически)
        //скрол панель
        JScrollPane scrollPane = new JScrollPane(list);
        this.mainPanel.add(scrollPane);

        list.addListSelectionListener(new ListSelectionListener()
        {
            @Override
            public void valueChanged(ListSelectionEvent e)
            {
                if (e.getValueIsAdjusting()) //является ли это событие первым (что б 1 раз отрабатывало событие выбора)
                {
                    System.out.println("Первый выбранный индекс: " + e.getFirstIndex());
                    System.out.println("Последний выбранный индекс: " + e.getLastIndex());
                    System.out.println("===");
                }

            }
        });
        ///////////////////////////-- правая сторона
        JPanel rightPanel = new JPanel();
        this.mainPanel.add(rightPanel);
        rightPanel.setLayout(new BorderLayout());
        //--панель для южной области
        JPanel southPanel = new JPanel();
        southPanel.setLayout(new FlowLayout(FlowLayout.CENTER, 5, 5));

        rightPanel.add(southPanel, BorderLayout.SOUTH);
        //--обработчик события нажатия на кнопку
        ActionListener AL = new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                if (e.getSource() == MyFrame.this.btnAdd)
                {
                    System.out.println("Add");
                    MyPoint P = new MyPoint((int) (Math.random() * 100), (int) (Math.random() * 100));
                    MyFrame.this.model.addElement(P);
                } 
                else if (e.getSource() == MyFrame.this.btnDel)
                {
                    System.out.println("Del");
                    int index = MyFrame.this.listPoints.getSelectedIndex();
                    if (index != -1)
                        MyFrame.this.model.remove(index);
                    else
                        JOptionPane.showMessageDialog(MyFrame.this, "Не выбран элемент списка", "Ошибка",JOptionPane.ERROR_MESSAGE);
                } 
                else if (e.getSource() == MyFrame.this.btnEdt)
                {
                    System.out.println("Edit");
                    int index = MyFrame.this.listPoints.getSelectedIndex();
                    if (index != -1)
                    {
                        MyPoint P = MyFrame.this.model.get(index);
                        P.setX((int) (Math.random() * 100));
                        P.setY((int) (Math.random() * 100));
                        MyFrame.this.listPoints.repaint(); //'мгновенного' для обновления значения 
                    }
                    else
                        JOptionPane.showMessageDialog(MyFrame.this, "Не выбран элемент списка", "Ошибка",JOptionPane.ERROR_MESSAGE);

                }

            }
        };
        //--Кнопки для southPanel
        this.btnAdd = new JButton("Add");
        this.btnDel = new JButton("Delete");
        this.btnEdt = new JButton("Edit");

        southPanel.add(this.btnAdd);
        southPanel.add(this.btnDel);
        southPanel.add(this.btnEdt);

        this.btnAdd.addActionListener(AL);
        this.btnDel.addActionListener(AL);
        this.btnEdt.addActionListener(AL);

        //--создание модели
        this.model = new DefaultListModel<>();
        for (int i = 0; i < 50; i++)
        {
            MyPoint P = new MyPoint(i, i + 1);
            this.model.addElement(P);
        }
        this.listPoints = new JList(this.model);
        this.listPoints.setSelectionMode(ListSelectionModel.SINGLE_SELECTION); // что бы могли только 1 выбрать

        JScrollPane scrollPaneTwo = new JScrollPane(listPoints);

        rightPanel.add(scrollPaneTwo);
    }
}
