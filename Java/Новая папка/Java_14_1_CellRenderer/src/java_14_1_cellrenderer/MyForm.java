/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_14_1_cellrenderer;

import java.awt.BorderLayout;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javafx.scene.control.SelectionMode;
import javax.swing.BoxLayout;
import javax.swing.DefaultListModel;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.ListSelectionModel;

/**
 *
 * @author 09220
 */
public class MyForm extends JFrame
{
    private JList list;
    private  DefaultListModel<Persona> model;
    private JPanel mainPanel;
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
        //--главная панель
        this.mainPanel = new JPanel();
        this.mainPanel.setLayout(new BoxLayout(this.mainPanel, BoxLayout.X_AXIS));
        this.setLayout(new BorderLayout());
        this.setContentPane(this.mainPanel);
        //
        this.model = new DefaultListModel<Persona>();
        this.model.addElement(new Persona("Gates", "Bill", 63, true));
        this.model.addElement(new Persona("King", "Steven", 70, true));
        this.model.addElement(new Persona("Kiti", "Friski", 25, false));

        this.list = new JList(this.model);
        this.list.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        
        JScrollPane scrollPane = new JScrollPane(this.list);
        this.mainPanel.add(scrollPane, BorderLayout.CENTER);
        
        this.list.setCellRenderer(new MyListCellRenderer());
    }
}
