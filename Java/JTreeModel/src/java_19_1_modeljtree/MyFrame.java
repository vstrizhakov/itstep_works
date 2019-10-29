/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package java_19_1_modeljtree;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.net.URL;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTabbedPane;
import javax.swing.JTable;
import javax.swing.JTree;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeCellRenderer;
import javax.swing.tree.DefaultTreeModel;
import javax.swing.tree.TreePath;

/**
 *
 * @author 09220
 */
public class MyFrame extends JFrame
{
        private JPanel mainPanel;
        private JTree tree;
        private DefaultTreeModel model;
        private JMenuItem miAdd, miDel, miEdit;
//        private JButton btnAdd, btnDel, btnEdit;
        
        public MyFrame()
        {
        //===============================================================
        //***************Главная панель
        this.mainPanel = new JPanel();

        
        this.mainPanel.setLayout(new BorderLayout());
        this.setLayout(new BorderLayout());
        this.setContentPane(this.mainPanel);
        
        //***************Общие настройки окна
        this.setTitle("JSplitPane");
        this.setSize(500, 300);
        this.addWindowListener(new WindowAdapter()
        {
            @Override
            public void windowClosing (WindowEvent we)
            {
                System.exit(0);
            }
        });
        //===============================================================
        this.tree = new JTree();
        JScrollPane scrollPane = new JScrollPane(this.tree);
        this.mainPanel.add(scrollPane, BorderLayout.CENTER);
        
        DefaultMutableTreeNode root = new DefaultMutableTreeNode("Корневой элемент");
         for(int i = 0; i < 10; i++)
        {
            DefaultMutableTreeNode node = new DefaultMutableTreeNode("Узел первого уровня " + i);
            root.add(node);

            for(int j = 0; j < 10; j++)
            {
                DefaultMutableTreeNode n2 = new DefaultMutableTreeNode("Узел второго уровня " + (i * 10 + j));
                node.add(n2);
            }
        }
        this.model = new DefaultTreeModel(root);
        this.tree.setModel(this.model);
        
        JMenuBar menuBar = new JMenuBar();
        this.setJMenuBar(menuBar);
        
        JMenu menuEdit = new JMenu("Edit");
        menuEdit.setMnemonic(KeyEvent.VK_E);
        menuBar.add(menuEdit);
        
        this.miAdd = new JMenuItem("Add");
        menuEdit.add(this.miAdd);
        
        this.miEdit = new JMenuItem("Edit");
        menuEdit.add(this.miEdit);
        
        this.miDel = new JMenuItem("Delete");
        menuEdit.add(this.miDel);
        
        ActionListener AL = new ActionListener()
        {
            @Override
            public void actionPerformed(ActionEvent e)
            {
                TreePath path = MyFrame.this.tree.getSelectionPath();
                if(path==null)
                {
                    JOptionPane.showMessageDialog(MyFrame.this, "не выбран узел дерева");
                    return;
                }
                Object[] arr = path.getPath();
                for(Object obj:arr)
                    System.out.println(obj.getClass().getName()+", "+obj.toString());
                
                DefaultMutableTreeNode parent = (DefaultMutableTreeNode) arr[arr.length-1];
                System.out.println(parent);
                
                if(e.getSource() == MyFrame.this.miAdd)
                {
                    System.out.println("Add");
                    MyFrame.this.model.insertNodeInto(new DefaultMutableTreeNode("Hello World "+(int)(Math.random()*100)), parent, 0);
                }
                else if(e.getSource() == MyFrame.this.miEdit)
                {
                    System.out.println("Edit");
                    parent.setUserObject("Hello World "+(int)(Math.random()*100));
                }
                else  if(e.getSource() == MyFrame.this.miDel)
                {
                    System.out.println("Del");
                    ((DefaultMutableTreeNode)parent.getParent()).remove(parent);
                    MyFrame.this.tree.updateUI();
                }
            }
        };
        miAdd.addActionListener(AL);
        miEdit.addActionListener(AL);
        miDel.addActionListener(AL);

    }
        
   
}
