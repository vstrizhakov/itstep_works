/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package products;

import java.sql.ResultSet;
import javax.swing.table.TableModel;

/**
 *
 * @author PC
 */
public class Category
{
    private int _id;
    private String _name;
    
    private Category() { }
    
    public Category(String name)
    {
        _name = name;
    }
    
    static public Category fromResultSet(ResultSet set)
    {
        try
        {
            Category category = new Category();
            category._id = set.getInt("id");
            category._name = set.getString("name");
            return category;
        }
        catch (Exception ex) {
            return null;
        }
    }
    
    static public Category fromTableModel(TableModel table, int row)
    {
        Category category = new Category();
        Object idObject = table.getValueAt(row, 0);
        if (idObject instanceof Integer)
        {
            category._id = (int)idObject;
        }
        category._name = (String)table.getValueAt(row, 1);
        return category;
    }
    
    public Object[] toArray()
    {
        return new Object[] { _id, _name };
    }
    
    public int getId()
    {
        return _id;
    }
    
    public String getName()
    {
        return _name;
    }
    
    @Override
    public String toString()
    {
        return _name;
    }
}
