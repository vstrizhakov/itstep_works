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
public class Product
{
    private int _id;
    private int _category_id;
    private String _name;
    private double _price;
    private double _weight;
    
    private Product() { }
    
    public Product(int categoryId, String name, double price, double weight)
    {
        _category_id = categoryId;
        _name = name;
        _price = price;
        _weight = weight;
    }
    
    static public Product fromResultSet(ResultSet set)
    {
        try
        {
            Product product = new Product();
            product._id = set.getInt("id");
            product._category_id = set.getInt("category_id");
            product._name = set.getString("name");
            product._weight = set.getDouble("weight");
            product._price = set.getDouble("price");
            return product;
        }
        catch (Exception ex) {
            return null;
        }
    }
    
    static public Product fromTableModel(TableModel table, int row)
    {
        Product product = new Product();
        Object idObject = table.getValueAt(row, 0);
        if (idObject instanceof Integer)
        {
            product._id = (int)idObject;
        }
        Object categoryIdObject = table.getValueAt(row, 1);
        if (categoryIdObject instanceof Category)
        {
            product._category_id = ((Category) categoryIdObject).getId();
        }
        else if (categoryIdObject instanceof Integer)
        {
            product._category_id = (int)categoryIdObject;
        }
        product._name = (String)table.getValueAt(row, 2);
        product._weight = Products.toDouble(table.getValueAt(row, 3));
        product._price = Products.toDouble(table.getValueAt(row, 4));
        return product;
    }
    
    public Object[] toArray()
    {
        return new Object[] { _id, _category_id, _name, _weight, _price };
    }
    
    public int getId()
    {
        return _id;
    }
    
    public String getName()
    {
        return _name;
    }
    
    public int getCategoryId()
    {
        return _category_id;
    }
    
    public double getPrice()
    {
        return _price;
    }
    
    public double getWeight()
    {
        return _weight;
    }
}
