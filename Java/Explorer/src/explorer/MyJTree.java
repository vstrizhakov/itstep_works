/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package explorer;

import java.io.File;
import javax.swing.JTree;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeModel;

/**
 *
 * @author PC
 */
public class MyJTree extends JTree
{
    public MyJTree(DefaultTreeModel model)
    {
        super(model);
    }
    
    @Override
    public String convertValueToText(Object value, boolean selected, boolean expanded, boolean leaf, int row, boolean hasFocus)
    {
        if (value instanceof DefaultMutableTreeNode)
        {
            Object obj = ((DefaultMutableTreeNode)value).getUserObject();
            if (obj instanceof File)
            {
                File file = (File) obj;
                if (file.getName().equals(""))
                {
                    return file.getAbsolutePath();
                }
                else
                {
                    return file.getName();
                }
            }
        }
        return value.toString();
    }
}