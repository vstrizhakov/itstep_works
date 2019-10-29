/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jtreehomework;

import java.awt.*;
import java.awt.event.*;
import java.io.File;
import javax.swing.*;
import javax.swing.event.TreeExpansionEvent;
import javax.swing.event.TreeWillExpandListener;
import javax.swing.tree.*;

/**
 *
 * @author PC
 */
public class Form extends JFrame {
    public Form()
    {
        setSize(1200, 600);
        setTitle("JTree");
        addWindowListener(new WindowAdapter()
        {
           @Override
           public void windowClosing(WindowEvent we)
           {
               System.exit(0);
           }
        });
        
        DefaultMutableTreeNode leftRoot = new DefaultMutableTreeNode();
        DefaultMutableTreeNode rightRoot = new DefaultMutableTreeNode();
        
        
        JTree leftJtree = new JTree(leftRoot);
        leftJtree.setRootVisible(false);

        JTree rightJtree = new JTree(rightRoot);
        rightJtree.setRootVisible(false);

        JScrollPane leftScrollPane = new JScrollPane(leftJtree);
        
        JScrollPane rightScrollPane = new JScrollPane(rightJtree);
        
        JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, leftScrollPane, rightScrollPane);
        this.setContentPane(splitPane);
        
        File[] roots = File.listRoots();
        for (File root : roots)
        {
            String rootName = root.getAbsolutePath();
            
            leftRoot.add(new DefaultMutableTreeNode(rootName));
            
            DefaultMutableTreeNode rootNode = new DefaultMutableTreeNode(rootName);
            rightRoot.add(rootNode);
            rootNode.add(new DefaultMutableTreeNode());
        }
        
        FillFullTreeNode((DefaultMutableTreeNode)leftRoot.getChildAt(1), roots[1]);
        
        rightJtree.addTreeWillExpandListener(new TreeWillExpandListener()
        {
            @Override
            public void treeWillCollapse(TreeExpansionEvent tee)
            {
                
            }
            
            @Override
            public void treeWillExpand(TreeExpansionEvent tee)
            {
                TreePath treePath = tee.getPath();
                DefaultMutableTreeNode treeNode = (DefaultMutableTreeNode)treePath.getLastPathComponent();
                FillTreeNode(treeNode);
            }
        });
        
        leftJtree.expandPath(new TreePath(leftRoot));
        rightJtree.expandPath(new TreePath(rightRoot));
    }
    
    private void FillTreeNode(DefaultMutableTreeNode treeNode, File file)
    {
        File[] files = file.listFiles();
        if (files == null) return;
        System.out.println("Count of files - " + files.length);
        for (File childFile : files)
        {
            DefaultMutableTreeNode childNode = new DefaultMutableTreeNode(childFile.getName());
            treeNode.add(childNode);
            if (childFile.isDirectory())
            {
                childNode.add(new DefaultMutableTreeNode());
            }
        }
    }
    
    private void FillTreeNode(DefaultMutableTreeNode treeNode)
    {
        if (treeNode.getChildCount() == 0) return;
        DefaultMutableTreeNode firstChildNode = (DefaultMutableTreeNode)treeNode.getChildAt(0);
        if (firstChildNode == null || firstChildNode.getUserObject() != null) return;
        treeNode.removeAllChildren();
        TreeNode[] nodes = treeNode.getPath();
        String[] pathes = new String[nodes.length];
        for (int i = 0; i < nodes.length; i++)
        {
            pathes[i] = nodes[i].toString();
        }
        String filePath = String.join(File.separator, pathes);
        File file = new File(filePath);
        if (file.isDirectory())
        {
            FillTreeNode(treeNode, file);
        }
    }
    
    private void FillFullTreeNode(DefaultMutableTreeNode treeNode, File file)
    {
        System.out.println(file.getAbsolutePath());
        File[] files = file.listFiles();
        if (files == null) return;
        for (File childFile : files)
        {
            DefaultMutableTreeNode childNode = new DefaultMutableTreeNode(childFile.getName());
            treeNode.add(childNode);
            if (childFile.isDirectory())
            {
                FillFullTreeNode(childNode, childFile);
            }
        }
    }
}
