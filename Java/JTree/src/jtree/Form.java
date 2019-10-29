/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jtree;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.*;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.TreePath;

/**
 *
 * @author PC
 */
public class Form extends JFrame {
    private javax.swing.JTree Tree;
    public Form()
    {
        this.setBackground(Color.BLACK);
        this.setSize(new Dimension(600, 1200));
        this.addWindowListener(new WindowAdapter()
        {
            @Override
            public void windowClosing(WindowEvent we)
            {
                System.exit(0);
            }
        });
        
        
        DefaultMutableTreeNode root = new DefaultMutableTreeNode("Корневой элемент");
        Tree = new javax.swing.JTree(root);
        JScrollPane scrollPane = new JScrollPane(Tree);
        JPanel rightPanel = new JPanel();
        rightPanel.setBackground(Color.YELLOW);

        JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, scrollPane, rightPanel);
        this.setContentPane(splitPane);
        
        for (int i = 0; i < 10; i++)
        {
            DefaultMutableTreeNode node = new DefaultMutableTreeNode("Узел первого уровня");
            root.add(node);
            for (int j = 0; j < 10; j++)
            {
               DefaultMutableTreeNode childNode = new DefaultMutableTreeNode("Узел первого уровня");
               node.add(childNode);
            }
        }
        
        Tree.setRootVisible(false);
        Tree.expandPath(new TreePath(new Object[] { root, root.children().nextElement() }));
        
        JButton btn = new JButton("Click");
        btn.setPreferredSize(new Dimension(200, 30));
        btn.addMouseListener(new MouseAdapter()
        {
           @Override
           public void mousePressed(MouseEvent me)
           {
               if (me.getSource() instanceof JButton)
               {
                   TreePath tp = Form.this.Tree.getSelectionPath();
                   JOptionPane.showMessageDialog(Form.this, ((tp != null) ? tp.toString() : "Узел не выбран"));
               }
           }
        });
        rightPanel.add(btn);
    }
}
