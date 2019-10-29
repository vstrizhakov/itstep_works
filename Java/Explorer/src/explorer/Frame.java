/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package explorer;

import java.awt.*;
import java.awt.event.*;
import java.io.File;
import javax.swing.*;
import javax.swing.event.*;
import javax.swing.table.*;
import javax.swing.tree.*;

/**
 *
 * @author PC
 */
public class Frame extends JFrame {
    private DefaultMutableTreeNode selectedNode;
    private File selectedFile;
    private MyJTree tree;
    
    public Frame()
    {
        this.setSize(new Dimension(1200, 600));
        this.setTitle("Explorer");
        this.addWindowListener(new WindowAdapter()
        {
            @Override
            public void windowClosing(WindowEvent we)
            {
                System.exit(0);
            }
        });
        
        /* Right Panel */
        
        String[] headers = { "Имя файла" };
        
        JTable table = new JTable()
        {
            @Override
            public boolean isCellEditable(int row, int col)
            {
                return false;
            }
        };
        DefaultTableModel tableModel = new DefaultTableModel();
        table.setModel(tableModel);
        tableModel.setColumnIdentifiers(headers);
        JScrollPane scrollPaneTable = new JScrollPane(table);
        
        table.addMouseListener(new MouseAdapter()
        {
            @Override
            public void mousePressed(MouseEvent me)
            {
                if (me.getClickCount() < 2) return;
                Point point = me.getPoint();
                int rowIndex = table.rowAtPoint(point);
                if (rowIndex != -1)
                {
                    if (selectedFile != null && selectedFile.isDirectory())
                    {
                        String fileName = (String)tableModel.getValueAt(rowIndex, 0);
                        File newFile = new File(selectedFile.getPath() + File.separator + fileName);
                        if (newFile.isDirectory())
                        {
                            selectedFile = newFile;
                            for (int i = 0; i < selectedNode.getChildCount(); i++)
                            {
                                DefaultMutableTreeNode node = (DefaultMutableTreeNode)selectedNode.getChildAt(i);
                                if (((File)node.getUserObject()).getPath().equals(selectedFile.getPath()))
                                {
                                    selectedNode = node;
                                    break;
                                }
                            }
                            File[] files = selectedFile.listFiles();
                            ClearTableModel(tableModel);
                            FillTableModel(tableModel, files);
                            tree.getSelectionModel().setSelectionPath(new TreePath(selectedNode.getPath()));
                        }
                    }
                }
            }
        });
        
        /* Left Panel */
        
        DefaultMutableTreeNode rootNode = new DefaultMutableTreeNode();
        DefaultTreeModel model = new DefaultTreeModel(rootNode);
        tree = new MyJTree(model);
        JScrollPane scrollPane = new JScrollPane(tree);
        scrollPane.setPreferredSize(new Dimension(200, 200));
        
        File[] roots = File.listRoots();
        for (File root : roots)
        {
            DefaultMutableTreeNode childNode = new DefaultMutableTreeNode(root.getAbsolutePath());
            childNode.setUserObject(root);
            rootNode.add(childNode);
            childNode.add(new DefaultMutableTreeNode());
        }
        
        tree.setRootVisible(false);
        tree.expandPath(new TreePath(rootNode));
        
        tree.addTreeWillExpandListener(new TreeWillExpandListener()
        {
            @Override
            public void treeWillExpand(TreeExpansionEvent tee)
            {
                TreePath treePath = tee.getPath();
                DefaultMutableTreeNode treeNode = (DefaultMutableTreeNode)treePath.getLastPathComponent();
                File file = (File)treeNode.getUserObject();
                if (file.isFile()) return;
                FillTreeNode(model, treeNode);
            }
            
            @Override
            public void treeWillCollapse(TreeExpansionEvent tee)
            {
            }
        });
        
        tree.addTreeSelectionListener(new TreeSelectionListener()
        {
            @Override
            public void valueChanged(TreeSelectionEvent tse)
            {
                TreePath treePath = tse.getPath();
                DefaultMutableTreeNode treeNode = (DefaultMutableTreeNode)treePath.getLastPathComponent();
                if (treeNode == null) return;
                File file = (File)treeNode.getUserObject();
                selectedFile = file;
                selectedNode = treeNode;
                ClearTableModel(tableModel);
                if (file.isDirectory())
                {
                    FillTreeNode(model, treeNode);
                    File[] files = new File[treeNode.getChildCount()];
                    for (int i = 0; i < files.length; i++)
                    {
                        DefaultMutableTreeNode node = (DefaultMutableTreeNode)treeNode.getChildAt(i);
                        files[i] = (File)node.getUserObject();
                    }
                    FillTableModel(tableModel, files);
                }
            }
        });
        
        JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, scrollPane, scrollPaneTable);
        this.setContentPane(splitPane);
    }
    
    private void FillTreeNode(DefaultTreeModel model, DefaultMutableTreeNode treeNode)
    {
        if (treeNode.getChildCount() == 0) return;
        DefaultMutableTreeNode firstChildNode = (DefaultMutableTreeNode)treeNode.getChildAt(0);
        if (firstChildNode == null || firstChildNode.getUserObject() != null) return;
        treeNode.removeAllChildren();
        File file = (File)treeNode.getUserObject();
        if (file.isDirectory())
        {
            File[] files = file.listFiles();
            if (files == null) return;
            System.out.println("Count of files - " + files.length);
            int i = 0;
            for (File childFile : files)
            {
                DefaultMutableTreeNode childNode = new DefaultMutableTreeNode(childFile.getName());
                childNode.setUserObject(childFile);
                model.insertNodeInto(childNode, treeNode, i++);
                if (childFile.isDirectory())
                {
                    model.insertNodeInto(new DefaultMutableTreeNode(), childNode, 0);
                }
            }
        }
    }
    
    private void ClearTableModel(DefaultTableModel tableModel)
    {
        while (tableModel.getRowCount() > 0)
        {
            tableModel.removeRow(0);
        }
    }
    
    private void FillTableModel(DefaultTableModel tableModel, File[] files)
    {
        if (files == null) return;
        for (File childFile : files)
        {
            tableModel.addRow(new Object[] { childFile.getName() });
        }
    }
}
